namespace PABMS
{
    partial class PackageForm
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
            label14 = new Label();
            btnNew = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnSave = new Button();
            txtReceiverContact = new TextBox();
            label15 = new Label();
            txtPackagePrice = new TextBox();
            label16 = new Label();
            label13 = new Label();
            txtPackageID = new TextBox();
            label11 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            label8 = new Label();
            txtTruckID = new TextBox();
            label9 = new Label();
            label10 = new Label();
            txtOrigin = new TextBox();
            label17 = new Label();
            txtDestination = new TextBox();
            label18 = new Label();
            txtSearch = new TextBox();
            gridPackage = new DataGridView();
            dtpDepartureDate = new DateTimePicker();
            dtpDeliveryDate = new DateTimePicker();
            txtPackageName = new TextBox();
            label19 = new Label();
            label2 = new Label();
            txtPackageValue = new TextBox();
            cmbTruckNumber = new ComboBox();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPackage).BeginInit();
            SuspendLayout();
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(255, 610);
            label14.Name = "label14";
            label14.Size = new Size(89, 29);
            label14.TabIndex = 46;
            label14.Text = "Search";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(192, 255, 255);
            btnNew.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnNew.Location = new Point(1054, 896);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(152, 50);
            btnNew.TabIndex = 45;
            btnNew.Text = "NEW";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 192, 128);
            btnUpdate.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdate.Location = new Point(802, 896);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(152, 50);
            btnUpdate.TabIndex = 44;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ActiveCaption;
            btnAdd.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(525, 896);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(152, 50);
            btnAdd.TabIndex = 43;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DeepSkyBlue;
            btnSave.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(259, 896);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(152, 50);
            btnSave.TabIndex = 42;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtReceiverContact
            // 
            txtReceiverContact.BorderStyle = BorderStyle.FixedSingle;
            txtReceiverContact.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtReceiverContact.Location = new Point(488, 542);
            txtReceiverContact.Multiline = true;
            txtReceiverContact.Name = "txtReceiverContact";
            txtReceiverContact.Size = new Size(718, 34);
            txtReceiverContact.TabIndex = 39;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(246, 545);
            label15.Name = "label15";
            label15.Size = new Size(196, 29);
            label15.TabIndex = 38;
            label15.Text = "Reciever Contact";
            // 
            // txtPackagePrice
            // 
            txtPackagePrice.BorderStyle = BorderStyle.FixedSingle;
            txtPackagePrice.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtPackagePrice.Location = new Point(488, 259);
            txtPackagePrice.Multiline = true;
            txtPackagePrice.Name = "txtPackagePrice";
            txtPackagePrice.Size = new Size(250, 34);
            txtPackagePrice.TabIndex = 37;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(251, 212);
            label16.Name = "label16";
            label16.Size = new Size(174, 29);
            label16.TabIndex = 36;
            label16.Text = "Package Value";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(246, 453);
            label13.Name = "label13";
            label13.Size = new Size(156, 29);
            label13.TabIndex = 34;
            label13.Text = "Delivery Date";
            // 
            // txtPackageID
            // 
            txtPackageID.BorderStyle = BorderStyle.FixedSingle;
            txtPackageID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtPackageID.Location = new Point(488, 161);
            txtPackageID.Multiline = true;
            txtPackageID.Name = "txtPackageID";
            txtPackageID.Size = new Size(250, 34);
            txtPackageID.TabIndex = 31;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(251, 163);
            label11.Name = "label11";
            label11.Size = new Size(136, 29);
            label11.TabIndex = 30;
            label11.Text = "Package ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(611, 66);
            label1.Name = "label1";
            label1.Size = new Size(241, 36);
            label1.TabIndex = 29;
            label1.Text = "Package's Form";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(cmbTruckNumber);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(txtTruckID);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(763, 161);
            panel3.Name = "panel3";
            panel3.Size = new Size(443, 227);
            panel3.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(6, 119);
            label8.Name = "label8";
            label8.Size = new Size(167, 29);
            label8.TabIndex = 10;
            label8.Text = "Truck Number";
            // 
            // txtTruckID
            // 
            txtTruckID.BorderStyle = BorderStyle.FixedSingle;
            txtTruckID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtTruckID.Location = new Point(178, 76);
            txtTruckID.Multiline = true;
            txtTruckID.Name = "txtTruckID";
            txtTruckID.Size = new Size(250, 34);
            txtTruckID.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(6, 81);
            label9.Name = "label9";
            label9.Size = new Size(103, 29);
            label9.TabIndex = 8;
            label9.Text = "Truck ID";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(248, 497);
            label10.Name = "label10";
            label10.Size = new Size(176, 29);
            label10.TabIndex = 47;
            label10.Text = "Departure Date";
            // 
            // txtOrigin
            // 
            txtOrigin.BorderStyle = BorderStyle.FixedSingle;
            txtOrigin.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrigin.Location = new Point(488, 309);
            txtOrigin.Multiline = true;
            txtOrigin.Name = "txtOrigin";
            txtOrigin.Size = new Size(250, 34);
            txtOrigin.TabIndex = 52;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(251, 311);
            label17.Name = "label17";
            label17.Size = new Size(79, 29);
            label17.TabIndex = 51;
            label17.Text = "Origin";
            // 
            // txtDestination
            // 
            txtDestination.BorderStyle = BorderStyle.FixedSingle;
            txtDestination.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtDestination.Location = new Point(488, 354);
            txtDestination.Multiline = true;
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(250, 34);
            txtDestination.TabIndex = 50;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(251, 354);
            label18.Name = "label18";
            label18.Size = new Size(133, 29);
            label18.TabIndex = 49;
            label18.Text = "Destination";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(350, 610);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(388, 34);
            txtSearch.TabIndex = 52;
            // 
            // gridPackage
            // 
            gridPackage.AllowUserToAddRows = false;
            gridPackage.AllowUserToDeleteRows = false;
            gridPackage.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPackage.Location = new Point(255, 672);
            gridPackage.Name = "gridPackage";
            gridPackage.ReadOnly = true;
            gridPackage.RowHeadersWidth = 51;
            gridPackage.RowTemplate.Height = 29;
            gridPackage.Size = new Size(951, 188);
            gridPackage.TabIndex = 53;
            gridPackage.CellClick += gridPackage_CellClick;
            // 
            // dtpDepartureDate
            // 
            dtpDepartureDate.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDepartureDate.Location = new Point(488, 492);
            dtpDepartureDate.Name = "dtpDepartureDate";
            dtpDepartureDate.Size = new Size(410, 34);
            dtpDepartureDate.TabIndex = 54;
            // 
            // dtpDeliveryDate
            // 
            dtpDeliveryDate.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDeliveryDate.Location = new Point(488, 451);
            dtpDeliveryDate.Name = "dtpDeliveryDate";
            dtpDeliveryDate.Size = new Size(410, 34);
            dtpDeliveryDate.TabIndex = 54;
            // 
            // txtPackageName
            // 
            txtPackageName.BorderStyle = BorderStyle.FixedSingle;
            txtPackageName.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtPackageName.Location = new Point(488, 405);
            txtPackageName.Multiline = true;
            txtPackageName.Name = "txtPackageName";
            txtPackageName.Size = new Size(718, 34);
            txtPackageName.TabIndex = 31;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(246, 407);
            label19.Name = "label19";
            label19.Size = new Size(178, 29);
            label19.TabIndex = 30;
            label19.Text = "Package Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(255, 259);
            label2.Name = "label2";
            label2.Size = new Size(169, 29);
            label2.TabIndex = 36;
            label2.Text = "Package Price";
            // 
            // txtPackageValue
            // 
            txtPackageValue.BorderStyle = BorderStyle.FixedSingle;
            txtPackageValue.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtPackageValue.Location = new Point(488, 212);
            txtPackageValue.Multiline = true;
            txtPackageValue.Name = "txtPackageValue";
            txtPackageValue.Size = new Size(250, 34);
            txtPackageValue.TabIndex = 37;
            // 
            // cmbTruckNumber
            // 
            cmbTruckNumber.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cmbTruckNumber.FormattingEnabled = true;
            cmbTruckNumber.Location = new Point(178, 117);
            cmbTruckNumber.Name = "cmbTruckNumber";
            cmbTruckNumber.Size = new Size(250, 37);
            cmbTruckNumber.TabIndex = 11;
            // 
            // PackageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1510, 972);
            Controls.Add(dtpDeliveryDate);
            Controls.Add(dtpDepartureDate);
            Controls.Add(gridPackage);
            Controls.Add(txtSearch);
            Controls.Add(txtOrigin);
            Controls.Add(label17);
            Controls.Add(txtDestination);
            Controls.Add(label18);
            Controls.Add(label10);
            Controls.Add(label14);
            Controls.Add(btnNew);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(txtReceiverContact);
            Controls.Add(label15);
            Controls.Add(txtPackageValue);
            Controls.Add(txtPackagePrice);
            Controls.Add(label2);
            Controls.Add(label16);
            Controls.Add(label13);
            Controls.Add(txtPackageName);
            Controls.Add(txtPackageID);
            Controls.Add(label19);
            Controls.Add(label11);
            Controls.Add(label1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PackageForm";
            Text = "BagageForm";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridPackage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label14;
        private Button btnNew;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnSave;
        private Label label15;
        private Label label16;
        private Label label13;
        private Label label12;

        private Label label11;
        private Label label1;
        private Panel panel3;

        private Label label8;

        private Label label9;
        private Label label10;
        private Label label17;
        private Label label18;


        private TextBox txtTruckNo;
        private TextBox txtTruckID;

        private TextBox txtPackageID;
        private TextBox txtOrigin;
        private TextBox txtDestination;
        private TextBox txtReceiverContact;
        private TextBox txtPackagePrice;

        private TextBox txtSearch;
        private DataGridView gridPackage;
        private DateTimePicker dtpDepartureDate;
        private DateTimePicker datePurchase;
        private DateTimePicker dtpDeliveryDate;
        private TextBox txtPackageName;
        private Label label19;
        private Button button1;
        private Label label2;
        private TextBox txtPackageValue;
        private ComboBox cmbTruckNumber;
    }
}