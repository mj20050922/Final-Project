namespace 期末專題
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCategorySum;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radioIncome;
        private System.Windows.Forms.RadioButton radioExpense;
        private System.Windows.Forms.GroupBox groupBox1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            txtName = new TextBox();
            txtAmount = new TextBox();
            txtCategory = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnCategorySum = new Button();
            lblTotal = new Label();
            dataGridView1 = new DataGridView();
            radioIncome = new RadioButton();
            radioExpense = new RadioButton();
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(14, 28);
            txtName.Margin = new Padding(2);
            txtName.Name = "txtName";
            txtName.Size = new Size(106, 23);
            txtName.TabIndex = 0;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(129, 28);
            txtAmount.Margin = new Padding(2);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(71, 23);
            txtAmount.TabIndex = 1;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(206, 28);
            txtCategory.Margin = new Padding(2);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(71, 23);
            txtCategory.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(280, 28);
            dateTimePicker1.Margin = new Padding(2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(106, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(400, 22);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(52, 30);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "新增";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(455, 22);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(52, 30);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "刪除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(511, 22);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(52, 30);
            btnSave.TabIndex = 6;
            btnSave.Text = "儲存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCategorySum
            // 
            btnCategorySum.Location = new Point(567, 22);
            btnCategorySum.Margin = new Padding(2);
            btnCategorySum.Name = "btnCategorySum";
            btnCategorySum.Size = new Size(70, 30);
            btnCategorySum.TabIndex = 7;
            btnCategorySum.Text = "分類統計";
            btnCategorySum.UseVisualStyleBackColor = true;
            btnCategorySum.Click += btnCategorySum_Click;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Microsoft JhengHei UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            lblTotal.Location = new Point(14, 279);
            lblTotal.Margin = new Padding(2, 0, 2, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(784, 46);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "收入: $0.00　支出: $0.00　結餘: $0.00";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(14, 76);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(750, 180);
            dataGridView1.TabIndex = 9;
            // 
            // radioIncome
            // 
            radioIncome.AutoSize = true;
            radioIncome.Location = new Point(74, 28);
            radioIncome.Margin = new Padding(2);
            radioIncome.Name = "radioIncome";
            radioIncome.Size = new Size(49, 19);
            radioIncome.TabIndex = 11;
            radioIncome.Text = "收入";
            radioIncome.UseVisualStyleBackColor = true;
            // 
            // radioExpense
            // 
            radioExpense.AutoSize = true;
            radioExpense.Location = new Point(10, 28);
            radioExpense.Margin = new Padding(2);
            radioExpense.Name = "radioExpense";
            radioExpense.Size = new Size(49, 19);
            radioExpense.TabIndex = 10;
            radioExpense.TabStop = true;
            radioExpense.Text = "支出";
            radioExpense.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioIncome);
            groupBox1.Controls.Add(radioExpense);
            groupBox1.Location = new Point(641, 12);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(120, 58);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "類型";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 11);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 13;
            label1.Text = "項目名稱";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(129, 11);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 14;
            label2.Text = "金額";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(206, 11);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 15;
            label3.Text = "類別";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(809, 393);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(txtAmount);
            Controls.Add(txtCategory);
            Controls.Add(dateTimePicker1);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnCategorySum);
            Controls.Add(lblTotal);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "記帳程式";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
    }
}
