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
        // 資料表，用於存儲記錄
        private DataTable table;

        // 自動儲存檔案的路徑
        private string autoSavePath = "autosave.csv";



        public Form1()
        {
            InitializeComponent();

            AutoScaleHelper scaler = new AutoScaleHelper(this);

            // 初始化資料表結構
            table = new DataTable();
            table.Columns.Add("項目名稱"); // 名稱欄位
            table.Columns.Add("金額", typeof(decimal)); // 金額欄位
            table.Columns.Add("類別"); // 類別欄位
            table.Columns.Add("日期", typeof(DateTime)); // 日期欄位
            table.Columns.Add("類型"); // 收入或支出
            table.Columns.Add("備註"); // 備註欄位

            // 將資料表綁定到 DataGridView
            dataGridView1.DataSource = table;

            // 設定 DataGridView 的格式化事件
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

            // 設定所有欄位自動調整填滿整個 DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 自動調整欄位標題高度，避免最上面那行顯示不完全
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // 若有多行或長文字要顯示，啟用自動換行
            //dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // 自動依據內容調整行高
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // 調整選取樣式：與預設樣式保持一致
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;

            // 如果自動儲存檔案存在，則載入資料
            if (File.Exists(autoSavePath))
                LoadFromFile(autoSavePath);

            // 更新總計資訊
            UpdateTotal();
        }

        // 新增記錄按鈕的事件處理
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 驗證輸入是否正確
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAmount.Text) ||
                !decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("請正確輸入名稱和金額");
                return;
            }

            // 判斷是收入還是支出
            string type = radioIncome.Checked ? "收入" : "支出";

            // 新增一筆記錄到資料表
            DataRow row = table.NewRow();
            row["項目名稱"] = txtName.Text;
            row["金額"] = amount;
            row["類別"] = txtCategory.Text;
            row["日期"] = dateTimePicker1.Value;
            row["類型"] = type;
            row["備註"] = ""; // 可日後加入 UI 欄位填入

            table.Rows.Add(row);

            // 清空輸入欄位
            txtName.Clear();
            txtAmount.Clear();
            txtCategory.Clear();
            radioExpense.Checked = true;

            // 更新總計資訊並自動儲存
            UpdateTotal();
            AutoSave();
        }

        // 刪除選中記錄按鈕的事件處理
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 刪除選中的 DataGridView 行
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                    dataGridView1.Rows.Remove(row);
            }

            // 更新總計資訊並自動儲存
            UpdateTotal();
            AutoSave();
        }

        // 儲存至檔案按鈕的事件處理
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv"; // 設定檔案過濾器
            sfd.FileName = "expenses.csv"; // 預設檔案名稱

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveToFile(sfd.FileName); // 儲存至選定的檔案
                MessageBox.Show("已儲存至檔案。");
            }
        }

        // 顯示分類統計按鈕的事件處理
        private void btnCategorySum_Click(object sender, EventArgs e)
        {
            // 如果沒有記錄，顯示提示訊息
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("尚無記錄可統計。");
                return;
            }

            // 按類別分組並計算金額總和  
            // 1. 使用 LINQ 的 GroupBy 方法，將資料表中的記錄按 "類別" 欄位進行分組。  
            //    每個分組包含相同類別的所有記錄。  
            // 2. 對每個分組計算其 "金額" 欄位的總和，並將結果格式化為字串。  
            //    格式為 "類別名稱: $金額"，金額保留兩位小數。  
            // 3. 將所有分組結果轉換為 List<string>，以便後續顯示。  
            var result = table.AsEnumerable()
               .GroupBy(r => r.Field<string>("類別")) // 按 "類別" 欄位分組  
               .Select(g => $"{g.Key}: ${g.Sum(r => r.Field<decimal>("金額")):0.00}") // 計算每組的金額總和並格式化  
               .ToList(); // 將結果轉換為 List<string>  

            // 顯示統計結果
            MessageBox.Show("分類統計：\n" + string.Join("\n", result));
        }

        // 更新總計資訊
        private void UpdateTotal()
        {
            // 計算收入總和
            decimal income = table.AsEnumerable()
                .Where(r => r.Field<string>("類型") == "收入")
                .Sum(r => r.Field<decimal>("金額"));

            // 計算支出總和
            decimal expense = table.AsEnumerable()
                .Where(r => r.Field<string>("類型") == "支出")
                .Sum(r => r.Field<decimal>("金額"));

            // 計算結餘
            decimal balance = income - expense;

            // 更新標籤文字
            lblTotal.Text = $"收入: ${income:0.00}　支出: ${expense:0.00}　結餘: ${balance:0.00}";

            // 如果結餘為負，顯示紅色文字
            if (balance < 0)
                lblTotal.ForeColor = Color.Red;
            else
                lblTotal.ForeColor = Color.Black;
        }

        // 自動儲存資料
        private void AutoSave()
        {
            SaveToFile(autoSavePath);
        }

        // 儲存資料至檔案
        private void SaveToFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                // 寫入欄位名稱
                var headers = table.Columns.Cast<DataColumn>().Select(col => col.ColumnName);
                writer.WriteLine(string.Join(",", headers));

                // 寫入每一筆記錄
                foreach (DataRow row in table.Rows)
                {
                    var fields = row.ItemArray.Select(field => field.ToString());
                    writer.WriteLine(string.Join(",", fields));
                }
            }
        }

        // 從檔案載入資料
        private void LoadFromFile(string path)
        {
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                // 讀取欄位名稱
                string[] headers = reader.ReadLine().Split(',');

                // 讀取每一筆記錄
                while (!reader.EndOfStream)
                {
                    string[] fields = reader.ReadLine().Split(',');
                    if (fields.Length >= headers.Length)
                    {
                        DataRow row = table.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            // 根據欄位類型轉換資料
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

        // DataGridView 格式化事件，用於設定行的背景顏色
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 確保 "類型" 欄位存在且目前行索引有效  
            if (dataGridView1.Columns["類型"] != null && e.RowIndex >= 0)
            {
                // 取得目前行的 "類型" 欄位值  
                var type = dataGridView1.Rows[e.RowIndex].Cells["類型"].Value?.ToString();

                // 根據 "類型" 設定行的背景顏色  
                if (type == "收入")
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                else if (type == "支出")
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
            }
        }

        // 名稱輸入框的文字改變事件（目前未實作任何邏輯）
        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // 確保不是標題行或無效的儲存格
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                MessageBox.Show($"使用者修改了第 {e.RowIndex + 1} 行的 '{columnName}' 欄位。");
                UpdateTotal(); // 更新總計資訊
            }
        }
    }
}
