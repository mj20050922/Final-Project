using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace 期末專題
{
    public partial class Form1 : Form
    {
        private DataTable table;
        private string autoSavePath = "autosave.csv";

        public Form1()
        {
            InitializeComponent();

            table = new DataTable();
            table.Columns.Add("項目名稱");
            table.Columns.Add("金額", typeof(decimal));
            table.Columns.Add("類別");
            table.Columns.Add("日期", typeof(DateTime));
            table.Columns.Add("類型");
            table.Columns.Add("備註");

            dataGridView1.DataSource = table;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

            if (File.Exists(autoSavePath))
                LoadFromFile(autoSavePath);

            UpdateTotal();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAmount.Text) ||
                !decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("請正確輸入名稱和金額");
                return;
            }

            string type = radioIncome.Checked ? "收入" : "支出";

            DataRow row = table.NewRow();
            row["項目名稱"] = txtName.Text;
            row["金額"] = amount;
            row["類別"] = txtCategory.Text;
            row["日期"] = dateTimePicker1.Value;
            row["類型"] = type;
            row["備註"] = ""; // 可日後加入 UI 欄位填入

            table.Rows.Add(row);

            txtName.Clear();
            txtAmount.Clear();
            txtCategory.Clear();
            radioExpense.Checked = true;

            UpdateTotal();
            AutoSave();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                    dataGridView1.Rows.Remove(row);
            }
            UpdateTotal();
            AutoSave();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            sfd.FileName = "expenses.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveToFile(sfd.FileName);
                MessageBox.Show("已儲存至檔案。");
            }
        }

        private void btnCategorySum_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("尚無記錄可統計。");
                return;
            }

            var result = table.AsEnumerable()
                .GroupBy(r => r.Field<string>("類別"))
                .Select(g => $"{g.Key}: ${g.Sum(r => r.Field<decimal>("金額")):0.00}")
                .ToList();

            MessageBox.Show("分類統計：\n" + string.Join("\n", result));
        }

        private void UpdateTotal()
        {
            decimal income = table.AsEnumerable()
                .Where(r => r.Field<string>("類型") == "收入")
                .Sum(r => r.Field<decimal>("金額"));

            decimal expense = table.AsEnumerable()
                .Where(r => r.Field<string>("類型") == "支出")
                .Sum(r => r.Field<decimal>("金額"));

            decimal balance = income - expense;
            lblTotal.Text = $"收入: ${income:0.00}　支出: ${expense:0.00}　結餘: ${balance:0.00}";

            if (balance < 0)
                lblTotal.ForeColor = Color.Red;
            else
                lblTotal.ForeColor = Color.Black;
        }

        private void AutoSave()
        {
            SaveToFile(autoSavePath);
        }

        private void SaveToFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                var headers = table.Columns.Cast<DataColumn>().Select(col => col.ColumnName);
                writer.WriteLine(string.Join(",", headers));

                foreach (DataRow row in table.Rows)
                {
                    var fields = row.ItemArray.Select(field => field.ToString());
                    writer.WriteLine(string.Join(",", fields));
                }
            }
        }

        private void LoadFromFile(string path)
        {
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                string[] headers = reader.ReadLine().Split(',');

                while (!reader.EndOfStream)
                {
                    string[] fields = reader.ReadLine().Split(',');
                    if (fields.Length >= headers.Length)
                    {
                        DataRow row = table.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            if (table.Columns[headers[i]].DataType == typeof(decimal))
                                row[i] = decimal.TryParse(fields[i], out decimal d) ? d : 0;
                            else if (table.Columns[headers[i]].DataType == typeof(DateTime))
                                row[i] = DateTime.TryParse(fields[i], out DateTime dt) ? dt : DateTime.Now;
                            else
                                row[i] = fields[i];
                        }
                        table.Rows.Add(row);
                    }
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns["類型"] != null && e.RowIndex >= 0)
            {
                var type = dataGridView1.Rows[e.RowIndex].Cells["類型"].Value?.ToString();
                if (type == "收入")
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                else if (type == "支出")
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
            }
        }
    }
}
