using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 期末專題
{
    public partial class Form1 : Form
    {
        private DataTable table;

        public Form1()
        {
            InitializeComponent();

            // 初始化 DataTable 作為資料來源
            table = new DataTable();
            table.Columns.Add("項目名稱");
            table.Columns.Add("金額", typeof(decimal));
            table.Columns.Add("類別");
            table.Columns.Add("日期", typeof(DateTime));

            dataGridView1.DataSource = table;
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

            DataRow row = table.NewRow();
            row["項目名稱"] = txtName.Text.Trim();
            row["金額"] = amount;
            row["類別"] = txtCategory.Text.Trim();
            row["日期"] = dateTimePicker1.Value;
            table.Rows.Add(row);

            txtName.Clear();
            txtAmount.Clear();
            txtCategory.Clear();

            UpdateTotal();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
            UpdateTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            sfd.FileName = "expenses.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    var headers = table.Columns.Cast<DataColumn>().Select(col => col.ColumnName);
                    writer.WriteLine(string.Join(",", headers));

                    foreach (DataRow row in table.Rows)
                    {
                        var fields = row.ItemArray.Select(field => field.ToString());
                        writer.WriteLine(string.Join(",", fields));
                    }
                }
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
            decimal sum = table.AsEnumerable()
                .Sum(r => r.Field<decimal>("金額"));
            lblTotal.Text = $"總花費: ${sum:0.00}";
        }
    }
}
