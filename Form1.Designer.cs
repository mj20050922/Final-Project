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
            txtName.Location = new Point(22, 44);
            txtName.Name = "txtName";
            txtName.Size = new Size(165, 32);
            txtName.TabIndex = 0;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(203, 44);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(110, 32);
            txtAmount.TabIndex = 1;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(324, 44);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(110, 32);
            txtCategory.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(440, 44);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(165, 32);
            dateTimePicker1.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(628, 35);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(81, 48);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "新增";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(715, 35);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(81, 48);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "刪除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(803, 35);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(81, 48);
            btnSave.TabIndex = 6;
            btnSave.Text = "儲存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCategorySum
            // 
            btnCategorySum.Location = new Point(891, 35);
            btnCategorySum.Name = "btnCategorySum";
            btnCategorySum.Size = new Size(110, 48);
            btnCategorySum.TabIndex = 7;
            btnCategorySum.Text = "分類統計";
            btnCategorySum.UseVisualStyleBackColor = true;
            btnCategorySum.Click += btnCategorySum_Click;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Microsoft JhengHei UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            lblTotal.Location = new Point(22, 446);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(440, 50);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "總花費: $0.00";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Location = new Point(22, 121);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(979, 288);
            dataGridView1.TabIndex = 9;
            // 
            // radioIncome
            // 
            radioIncome.AutoSize = true;
            radioIncome.Location = new Point(116, 45);
            radioIncome.Name = "radioIncome";
            radioIncome.Size = new Size(66, 28);
            radioIncome.TabIndex = 11;
            radioIncome.Text = "收入";
            radioIncome.UseVisualStyleBackColor = true;
            // 
            // radioExpense
            // 
            radioExpense.AutoSize = true;
            radioExpense.Location = new Point(15, 45);
            radioExpense.Name = "radioExpense";
            radioExpense.Size = new Size(66, 28);
            radioExpense.TabIndex = 10;
            radioExpense.TabStop = true;
            radioExpense.Text = "支出";
            radioExpense.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioIncome);
            groupBox1.Controls.Add(radioExpense);
            groupBox1.Location = new Point(1008, 19);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(188, 93);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "類型";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 17);
            label1.Name = "label1";
            label1.Size = new Size(86, 24);
            label1.TabIndex = 13;
            label1.Text = "項目名稱";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(203, 17);
            label2.Name = "label2";
            label2.Size = new Size(48, 24);
            label2.TabIndex = 14;
            label2.Text = "金額";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(324, 17);
            label3.Name = "label3";
            label3.Size = new Size(48, 24);
            label3.TabIndex = 15;
            label3.Text = "類別";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 629);
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
