using System;

namespace 期末專題
{
    // 基本帳務資料類別
    public class Record
    {
        public string Type { get; set; }      // 收入 / 支出
        public string Name { get; set; }      // 項目名稱
        public decimal Amount { get; set; }   // 金額
        public string Category { get; set; }  // 分類
        public DateTime Date { get; set; }    // 日期
        public string Note { get; set; }      // 備註

        public Record(string type, string name, decimal amount, string category, DateTime date, string note)
        {
            Type = type;
            Name = name;
            Amount = amount;
            Category = category;
            Date = date;
            Note = note;
        }
    }

    // 可選：支出與收入分類繼承（如果你老師想看到繼承）
    public class IncomeRecord : Record
    {
        public IncomeRecord(string name, decimal amount, string category, DateTime date, string note)
            : base("收入", name, amount, category, date, note) { }
    }

    public class ExpenseRecord : Record
    {
        public ExpenseRecord(string name, decimal amount, string category, DateTime date, string note)
            : base("支出", name, amount, category, date, note) { }
    }
}
