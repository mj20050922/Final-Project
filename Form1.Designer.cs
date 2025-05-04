namespace 期末專題
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtAmount = new TextBox();
            txtCategory = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            btnAdd = new Button();
            dataGridView1 = new DataGridView();
            lblTotal = new Label();
            btnDelete = new Button();
            btnSave = new Button();
            btnCategorySum = new Button();
            labelName = new Label();
            labelAmount = new Label();
            labelCategory = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(30, 25);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 32);
            txtName.TabIndex = 0;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(140, 25);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 32);
            txtAmount.TabIndex = 1;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(250, 25);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(100, 32);
            txtCategory.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(360, 25);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 32);
            dateTimePicker1.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(580, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 30);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "新增";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Location = new Point(30, 70);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(630, 250);
            dataGridView1.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            lblTotal.Location = new Point(30, 352);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(179, 35);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "總花費: $0.00";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(140, 412);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 30);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "刪除記錄";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom;
            btnSave.Location = new Point(275, 410);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 32);
            btnSave.TabIndex = 7;
            btnSave.Text = "儲存到檔案";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCategorySum
            // 
            btnCategorySum.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCategorySum.Location = new Point(430, 410);
            btnCategorySum.Name = "btnCategorySum";
            btnCategorySum.Size = new Size(120, 30);
            btnCategorySum.TabIndex = 8;
            btnCategorySum.Text = "分類統計";
            btnCategorySum.UseVisualStyleBackColor = true;
            btnCategorySum.Click += btnCategorySum_Click;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(30, 5);
            labelName.Name = "labelName";
            labelName.Size = new Size(86, 24);
            labelName.TabIndex = 9;
            labelName.Text = "項目名稱";
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Location = new Point(140, 5);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(48, 24);
            labelAmount.TabIndex = 10;
            labelAmount.Text = "金額";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(250, 5);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(48, 24);
            labelCategory.TabIndex = 11;
            labelCategory.Text = "類別";
            // 
            // Form1
            // 
            ClientSize = new Size(709, 485);
            Controls.Add(txtName);
            Controls.Add(txtAmount);
            Controls.Add(txtCategory);
            Controls.Add(dateTimePicker1);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Controls.Add(lblTotal);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnCategorySum);
            Controls.Add(labelName);
            Controls.Add(labelAmount);
            Controls.Add(labelCategory);
            Name = "Form1";
            Text = "簡易記帳程式";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCategorySum;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelCategory;
    }
}