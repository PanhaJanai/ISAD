namespace PABMS
{
    partial class PaymentPackageForm
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            datePayment = new DateTimePicker();
            gridSearch = new DataGridView();
            label14 = new Label();
            btnNew = new Button();
            btnUpdate = new Button();
            btnSearch = new Button();
            btnSave = new Button();
            txtSearch = new TextBox();
            panel1 = new Panel();
            txtCustomerID = new TextBox();
            label4 = new Label();
            cmCustomerTel = new ComboBox();
            txtCustomerName = new TextBox();
            label7 = new Label();
            label8 = new Label();
            cmbPackageName = new ComboBox();
            label3 = new Label();
            label6 = new Label();
            label2 = new Label();
            txtAmount = new TextBox();
            label16 = new Label();
            txtPaymentPackageID = new TextBox();
            label11 = new Label();
            label1 = new Label();
            label5 = new Label();
            txtPackageID = new TextBox();
            txtPackagePrice = new TextBox();
            ((System.ComponentModel.ISupportInitialize)gridSearch).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // datePayment
            // 
            datePayment.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            datePayment.Location = new Point(932, 199);
            datePayment.Name = "datePayment";
            datePayment.Size = new Size(422, 34);
            datePayment.TabIndex = 84;
            // 
            // gridSearch
            // 
            gridSearch.AllowUserToAddRows = false;
            gridSearch.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            gridSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            gridSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSearch.Location = new Point(306, 661);
            gridSearch.Name = "gridSearch";
            gridSearch.ReadOnly = true;
            gridSearch.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gridSearch.RowsDefaultCellStyle = dataGridViewCellStyle6;
            gridSearch.RowTemplate.Height = 29;
            gridSearch.Size = new Size(1053, 255);
            gridSearch.TabIndex = 83;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(306, 606);
            label14.Name = "label14";
            label14.Size = new Size(89, 29);
            label14.TabIndex = 82;
            label14.Text = "Search";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(192, 255, 255);
            btnNew.Location = new Point(1202, 954);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(152, 50);
            btnNew.TabIndex = 81;
            btnNew.Text = "NEW";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 192, 128);
            btnUpdate.Location = new Point(894, 954);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(152, 50);
            btnUpdate.TabIndex = 80;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ActiveCaption;
            btnSearch.Location = new Point(598, 954);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(152, 50);
            btnSearch.TabIndex = 79;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(192, 192, 255);
            btnSave.Location = new Point(297, 954);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(152, 50);
            btnSave.TabIndex = 78;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(419, 604);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 34);
            txtSearch.TabIndex = 77;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtPackagePrice);
            panel1.Controls.Add(txtPackageID);
            panel1.Controls.Add(txtCustomerID);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cmCustomerTel);
            panel1.Controls.Add(txtCustomerName);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(cmbPackageName);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label6);
            panel1.Location = new Point(301, 376);
            panel1.Name = "panel1";
            panel1.Size = new Size(1053, 172);
            panel1.TabIndex = 76;
            // 
            // txtCustomerID
            // 
            txtCustomerID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtCustomerID.Location = new Point(743, 25);
            txtCustomerID.Multiline = true;
            txtCustomerID.Name = "txtCustomerID";
            txtCustomerID.Size = new Size(250, 34);
            txtCustomerID.TabIndex = 61;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(542, 122);
            label4.Name = "label4";
            label4.Size = new Size(159, 29);
            label4.TabIndex = 60;
            label4.Text = "Customer Tel";
            // 
            // cmCustomerTel
            // 
            cmCustomerTel.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cmCustomerTel.FormattingEnabled = true;
            cmCustomerTel.Location = new Point(743, 116);
            cmCustomerTel.Name = "cmCustomerTel";
            cmCustomerTel.Size = new Size(250, 37);
            cmCustomerTel.TabIndex = 59;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtCustomerName.Location = new Point(743, 72);
            txtCustomerName.Multiline = true;
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(250, 34);
            txtCustomerName.TabIndex = 57;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(541, 72);
            label7.Name = "label7";
            label7.Size = new Size(188, 29);
            label7.TabIndex = 56;
            label7.Text = "Customer Name";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(542, 24);
            label8.Name = "label8";
            label8.Size = new Size(146, 29);
            label8.TabIndex = 55;
            label8.Text = "Customer ID";
            // 
            // cmbPackageName
            // 
            cmbPackageName.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cmbPackageName.FormattingEnabled = true;
            cmbPackageName.Location = new Point(215, 69);
            cmbPackageName.Name = "cmbPackageName";
            cmbPackageName.Size = new Size(250, 37);
            cmbPackageName.TabIndex = 53;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(26, 72);
            label3.Name = "label3";
            label3.Size = new Size(178, 29);
            label3.TabIndex = 0;
            label3.Text = "Package Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(26, 25);
            label6.Name = "label6";
            label6.Size = new Size(136, 29);
            label6.TabIndex = 0;
            label6.Text = "Package ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(749, 204);
            label2.Name = "label2";
            label2.Size = new Size(162, 29);
            label2.TabIndex = 75;
            label2.Text = "Payment Date";
            // 
            // txtAmount
            // 
            txtAmount.BorderStyle = BorderStyle.FixedSingle;
            txtAmount.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtAmount.Location = new Point(450, 261);
            txtAmount.Multiline = true;
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(250, 34);
            txtAmount.TabIndex = 74;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(301, 266);
            label16.Name = "label16";
            label16.Size = new Size(94, 29);
            label16.TabIndex = 73;
            label16.Text = "Amount";
            // 
            // txtPaymentPackageID
            // 
            txtPaymentPackageID.BorderStyle = BorderStyle.FixedSingle;
            txtPaymentPackageID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtPaymentPackageID.Location = new Point(450, 202);
            txtPaymentPackageID.Multiline = true;
            txtPaymentPackageID.Name = "txtPaymentPackageID";
            txtPaymentPackageID.ReadOnly = true;
            txtPaymentPackageID.Size = new Size(250, 34);
            txtPaymentPackageID.TabIndex = 72;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(301, 206);
            label11.Name = "label11";
            label11.Size = new Size(135, 29);
            label11.TabIndex = 71;
            label11.Text = "Payment ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(659, 79);
            label1.Name = "label1";
            label1.Size = new Size(372, 36);
            label1.TabIndex = 70;
            label1.Text = "Package Payment's Form";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(26, 119);
            label5.Name = "label5";
            label5.Size = new Size(169, 29);
            label5.TabIndex = 0;
            label5.Text = "Package Price";
            // 
            // txtPackageID
            // 
            txtPackageID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtPackageID.Location = new Point(215, 23);
            txtPackageID.Multiline = true;
            txtPackageID.Name = "txtPackageID";
            txtPackageID.Size = new Size(250, 34);
            txtPackageID.TabIndex = 61;
            // 
            // txtPackagePrice
            // 
            txtPackagePrice.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtPackagePrice.Location = new Point(215, 116);
            txtPackagePrice.Multiline = true;
            txtPackagePrice.Name = "txtPackagePrice";
            txtPackagePrice.Size = new Size(250, 34);
            txtPackagePrice.TabIndex = 61;
            // 
            // PaymentPackageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1437, 1102);
            Controls.Add(datePayment);
            Controls.Add(gridSearch);
            Controls.Add(label14);
            Controls.Add(btnNew);
            Controls.Add(btnUpdate);
            Controls.Add(btnSearch);
            Controls.Add(btnSave);
            Controls.Add(txtSearch);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(txtAmount);
            Controls.Add(label16);
            Controls.Add(txtPaymentPackageID);
            Controls.Add(label11);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PaymentPackageForm";
            Text = "PaymentForm";
            ((System.ComponentModel.ISupportInitialize)gridSearch).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label14;
        private Button btnNew;
        private Button btnUpdate;
        private Button btnSearch;
        private Button btnSave;
        private Panel panel1;
        private Label label4;
        private Label label7;
        private Label label8;
        private Label label6;
        private Label label2;
        private Label label16;
        private Label label11;
        private Label label1;

        private TextBox txtPaymentPackageID;
        private TextBox txtAmount;
        private DateTimePicker datePayment;

        private ComboBox cmCustomerTel;
        private TextBox txtCustomerName;
        private TextBox txtCustomerID;

        private TextBox txtSearch;
        private DataGridView gridSearch;
        private Label label3;
        private ComboBox cmbPackageName;
        private Label label5;
        private TextBox txtPackagePrice;
        private TextBox txtPackageID;
    }
}