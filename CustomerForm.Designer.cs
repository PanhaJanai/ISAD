namespace PABMS
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridCustomer = new DataGridView();
            label14 = new Label();
            btnNew = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnSave = new Button();
            txtSearch = new TextBox();
            txtCustomerName = new TextBox();
            label16 = new Label();
            txtCusID = new TextBox();
            label11 = new Label();
            label1 = new Label();
            cbFemale = new CheckBox();
            cbMale = new CheckBox();
            label3 = new Label();
            label4 = new Label();
            txtCusTel = new TextBox();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)gridCustomer).BeginInit();
            SuspendLayout();
            // 
            // gridCustomer
            // 
            gridCustomer.AllowUserToAddRows = false;
            gridCustomer.AllowUserToDeleteRows = false;
            gridCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCustomer.Location = new Point(287, 475);
            gridCustomer.Name = "gridCustomer";
            gridCustomer.ReadOnly = true;
            gridCustomer.RowHeadersWidth = 51;
            gridCustomer.RowTemplate.Height = 29;
            gridCustomer.Size = new Size(1064, 261);
            gridCustomer.TabIndex = 68;
            gridCustomer.CellClick += gridCustomer_CellClick;
            gridCustomer.Scroll += gridCustomer_Scroll;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(287, 425);
            label14.Name = "label14";
            label14.Size = new Size(89, 29);
            label14.TabIndex = 67;
            label14.Text = "Search";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(192, 255, 255);
            btnNew.Location = new Point(1199, 767);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(152, 51);
            btnNew.TabIndex = 66;
            btnNew.Text = "NEW";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 192, 128);
            btnUpdate.Location = new Point(886, 767);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(152, 51);
            btnUpdate.TabIndex = 65;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ActiveCaption;
            btnAdd.Location = new Point(564, 767);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(152, 51);
            btnAdd.TabIndex = 64;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(192, 192, 255);
            btnSave.Location = new Point(281, 767);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(152, 51);
            btnSave.TabIndex = 63;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(481, 425);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 34);
            txtSearch.TabIndex = 62;
            // 
            // txtCustomerName
            // 
            txtCustomerName.BorderStyle = BorderStyle.FixedSingle;
            txtCustomerName.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtCustomerName.Location = new Point(481, 255);
            txtCustomerName.Multiline = true;
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(250, 34);
            txtCustomerName.TabIndex = 58;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(287, 257);
            label16.Name = "label16";
            label16.Size = new Size(188, 29);
            label16.TabIndex = 57;
            label16.Text = "Customer Name";
            // 
            // txtCusID
            // 
            txtCusID.BorderStyle = BorderStyle.FixedSingle;
            txtCusID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtCusID.Location = new Point(481, 211);
            txtCusID.Multiline = true;
            txtCusID.Name = "txtCusID";
            txtCusID.ReadOnly = true;
            txtCusID.Size = new Size(250, 34);
            txtCusID.TabIndex = 56;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(287, 213);
            label11.Name = "label11";
            label11.Size = new Size(146, 29);
            label11.TabIndex = 55;
            label11.Text = "Customer ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(737, 88);
            label1.Name = "label1";
            label1.Size = new Size(254, 36);
            label1.TabIndex = 54;
            label1.Text = "Customer's Form";
            // 
            // cbFemale
            // 
            cbFemale.AutoSize = true;
            cbFemale.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cbFemale.Location = new Point(1131, 257);
            cbFemale.Name = "cbFemale";
            cbFemale.Size = new Size(117, 33);
            cbFemale.TabIndex = 71;
            cbFemale.Text = "Female";
            cbFemale.UseVisualStyleBackColor = true;
            // 
            // cbMale
            // 
            cbMale.AutoSize = true;
            cbMale.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cbMale.Location = new Point(1004, 256);
            cbMale.Name = "cbMale";
            cbMale.Size = new Size(88, 33);
            cbMale.TabIndex = 70;
            cbMale.Text = "Male";
            cbMale.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(805, 257);
            label3.Name = "label3";
            label3.Size = new Size(54, 29);
            label3.TabIndex = 69;
            label3.Text = "Sex";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(804, 213);
            label4.Name = "label4";
            label4.Size = new Size(125, 29);
            label4.TabIndex = 57;
            label4.Text = "Phone Tel";
            // 
            // txtCusTel
            // 
            txtCusTel.BorderStyle = BorderStyle.FixedSingle;
            txtCusTel.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtCusTel.Location = new Point(998, 208);
            txtCusTel.Multiline = true;
            txtCusTel.Name = "txtCusTel";
            txtCusTel.Size = new Size(250, 34);
            txtCusTel.TabIndex = 58;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ActiveCaption;
            btnSearch.Location = new Point(747, 425);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(152, 34);
            btnSearch.TabIndex = 64;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1414, 1013);
            ControlBox = false;
            Controls.Add(cbFemale);
            Controls.Add(cbMale);
            Controls.Add(label3);
            Controls.Add(gridCustomer);
            Controls.Add(label14);
            Controls.Add(btnNew);
            Controls.Add(btnUpdate);
            Controls.Add(btnSearch);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(txtSearch);
            Controls.Add(txtCusTel);
            Controls.Add(txtCustomerName);
            Controls.Add(label4);
            Controls.Add(label16);
            Controls.Add(txtCusID);
            Controls.Add(label11);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerForm";
            Text = "CustomerForm";
            ((System.ComponentModel.ISupportInitialize)gridCustomer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridCustomer;
        private Label label14;
        private Button btnNew;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnSave;
        private TextBox txtSearch;
        private TextBox txtCustomerName;
        private Label label16;
        private TextBox txtCusID;
        private Label label11;
        private Label label1;
        private CheckBox cbFemale;
        private CheckBox cbMale;
        private Label label3;
        private Label label4;
        private TextBox txtCusTel;
        private Button button1;
        private Button btnSearch;
    }
}