namespace PABMS
{
    partial class StaffForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label15 = new Label();
            label16 = new Label();
            txtID = new TextBox();
            label11 = new Label();
            cbMale = new CheckBox();
            txtStaffPosition = new TextBox();
            label3 = new Label();
            pbStaffPhoto = new PictureBox();
            label14 = new Label();
            btnNew = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnSave = new Button();
            txtSearch = new TextBox();
            txtStaffSalary = new TextBox();
            label2 = new Label();
            bindingSource1 = new BindingSource(components);
            cbFemale = new CheckBox();
            dtpHiredDate = new DateTimePicker();
            label4 = new Label();
            gridStaff = new DataGridView();
            label12 = new Label();
            txtFullName = new TextBox();
            Address = new Label();
            txtStaffAddress = new TextBox();
            label6 = new Label();
            dtpBirthDate = new DateTimePicker();
            label5 = new Label();
            cbStoppedWork = new CheckBox();
            txtStaffTel = new TextBox();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)pbStaffPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridStaff).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(777, 49);
            label1.Name = "label1";
            label1.Size = new Size(184, 36);
            label1.TabIndex = 3;
            label1.Text = "Staff's Form";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(190, 327);
            label15.Name = "label15";
            label15.Size = new Size(118, 29);
            label15.TabIndex = 25;
            label15.Text = "Birth Date";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(190, 191);
            label16.Name = "label16";
            label16.Size = new Size(54, 29);
            label16.TabIndex = 23;
            label16.Text = "Sex";
            // 
            // txtID
            // 
            txtID.BorderStyle = BorderStyle.FixedSingle;
            txtID.Enabled = false;
            txtID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtID.Location = new Point(326, 140);
            txtID.Multiline = true;
            txtID.Name = "txtID";
            txtID.Size = new Size(250, 34);
            txtID.TabIndex = 20;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(190, 145);
            label11.Name = "label11";
            label11.Size = new Size(89, 29);
            label11.TabIndex = 19;
            label11.Text = "Staff ID";
            // 
            // cbMale
            // 
            cbMale.AutoSize = true;
            cbMale.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cbMale.Location = new Point(326, 187);
            cbMale.Name = "cbMale";
            cbMale.Size = new Size(88, 33);
            cbMale.TabIndex = 28;
            cbMale.Text = "Male";
            cbMale.UseVisualStyleBackColor = true;
            // 
            // txtStaffPosition
            // 
            txtStaffPosition.BorderStyle = BorderStyle.FixedSingle;
            txtStaffPosition.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtStaffPosition.Location = new Point(326, 230);
            txtStaffPosition.Multiline = true;
            txtStaffPosition.Name = "txtStaffPosition";
            txtStaffPosition.Size = new Size(250, 34);
            txtStaffPosition.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(190, 235);
            label3.Name = "label3";
            label3.Size = new Size(100, 29);
            label3.TabIndex = 30;
            label3.Text = "Position";
            // 
            // pbStaffPhoto
            // 
            pbStaffPhoto.BorderStyle = BorderStyle.FixedSingle;
            pbStaffPhoto.Image = Properties.Resources.Screenshot__116_;
            pbStaffPhoto.Location = new Point(1151, 140);
            pbStaffPhoto.Name = "pbStaffPhoto";
            pbStaffPhoto.Size = new Size(270, 310);
            pbStaffPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbStaffPhoto.TabIndex = 38;
            pbStaffPhoto.TabStop = false;
            pbStaffPhoto.Click += pbStaffPhoto_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(190, 516);
            label14.Name = "label14";
            label14.Size = new Size(89, 29);
            label14.TabIndex = 45;
            label14.Text = "Search";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(192, 255, 255);
            btnNew.Location = new Point(1269, 896);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(152, 51);
            btnNew.TabIndex = 44;
            btnNew.Text = "NEW";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 192, 128);
            btnUpdate.Location = new Point(924, 896);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(152, 51);
            btnUpdate.TabIndex = 43;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ActiveCaption;
            btnAdd.Location = new Point(559, 896);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(152, 51);
            btnAdd.TabIndex = 42;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(192, 192, 255);
            btnSave.Location = new Point(190, 896);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(152, 51);
            btnSave.TabIndex = 41;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(326, 514);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 34);
            txtSearch.TabIndex = 39;
            // 
            // txtStaffSalary
            // 
            txtStaffSalary.BorderStyle = BorderStyle.FixedSingle;
            txtStaffSalary.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtStaffSalary.Location = new Point(326, 279);
            txtStaffSalary.Multiline = true;
            txtStaffSalary.Name = "txtStaffSalary";
            txtStaffSalary.Size = new Size(250, 34);
            txtStaffSalary.TabIndex = 49;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(190, 281);
            label2.Name = "label2";
            label2.Size = new Size(80, 29);
            label2.TabIndex = 48;
            label2.Text = "Salary";
            // 
            // cbFemale
            // 
            cbFemale.AutoSize = true;
            cbFemale.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cbFemale.Location = new Point(459, 187);
            cbFemale.Name = "cbFemale";
            cbFemale.Size = new Size(117, 33);
            cbFemale.TabIndex = 51;
            cbFemale.Text = "Female";
            cbFemale.UseVisualStyleBackColor = true;
            // 
            // dtpHiredDate
            // 
            dtpHiredDate.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            dtpHiredDate.Location = new Point(326, 374);
            dtpHiredDate.Margin = new Padding(5);
            dtpHiredDate.Name = "dtpHiredDate";
            dtpHiredDate.Size = new Size(411, 34);
            dtpHiredDate.TabIndex = 53;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(190, 379);
            label4.Name = "label4";
            label4.Size = new Size(128, 29);
            label4.TabIndex = 52;
            label4.Text = "Hired Date";
            // 
            // gridStaff
            // 
            gridStaff.AllowUserToAddRows = false;
            gridStaff.AllowUserToDeleteRows = false;
            gridStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridStaff.Location = new Point(190, 570);
            gridStaff.Name = "gridStaff";
            gridStaff.ReadOnly = true;
            gridStaff.RowHeadersWidth = 51;
            gridStaff.RowTemplate.Height = 29;
            gridStaff.Size = new Size(1231, 289);
            gridStaff.TabIndex = 55;
            gridStaff.CellClick += gridStaff_CellClick;
            gridStaff.Scroll += gridStaff_Scroll;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(652, 145);
            label12.Name = "label12";
            label12.Size = new Size(124, 29);
            label12.TabIndex = 21;
            label12.Text = "Full Name";
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtFullName.Location = new Point(826, 140);
            txtFullName.Multiline = true;
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(250, 34);
            txtFullName.TabIndex = 22;
            // 
            // Address
            // 
            Address.AutoSize = true;
            Address.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            Address.Location = new Point(652, 233);
            Address.Name = "Address";
            Address.Size = new Size(102, 29);
            Address.TabIndex = 32;
            Address.Text = "Address";
            // 
            // txtStaffAddress
            // 
            txtStaffAddress.BorderStyle = BorderStyle.FixedSingle;
            txtStaffAddress.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtStaffAddress.Location = new Point(826, 231);
            txtStaffAddress.Multiline = true;
            txtStaffAddress.Name = "txtStaffAddress";
            txtStaffAddress.Size = new Size(250, 34);
            txtStaffAddress.TabIndex = 33;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(652, 186);
            label6.Name = "label6";
            label6.Size = new Size(49, 29);
            label6.TabIndex = 34;
            label6.Text = "Tel";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            dtpBirthDate.Location = new Point(326, 327);
            dtpBirthDate.Margin = new Padding(5);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(411, 34);
            dtpBirthDate.TabIndex = 46;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(652, 280);
            label5.Name = "label5";
            label5.Size = new Size(167, 29);
            label5.TabIndex = 36;
            label5.Text = "Stopped Work";
            // 
            // cbStoppedWork
            // 
            cbStoppedWork.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cbStoppedWork.Location = new Point(826, 287);
            cbStoppedWork.Name = "cbStoppedWork";
            cbStoppedWork.Size = new Size(18, 17);
            cbStoppedWork.TabIndex = 37;
            cbStoppedWork.UseVisualStyleBackColor = false;
            // 
            // txtStaffTel
            // 
            txtStaffTel.BorderStyle = BorderStyle.FixedSingle;
            txtStaffTel.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtStaffTel.Location = new Point(826, 186);
            txtStaffTel.Multiline = true;
            txtStaffTel.Name = "txtStaffTel";
            txtStaffTel.Size = new Size(250, 34);
            txtStaffTel.TabIndex = 35;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ActiveCaption;
            btnSearch.Location = new Point(596, 515);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(115, 34);
            btnSearch.TabIndex = 42;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // StaffForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1615, 1017);
            Controls.Add(gridStaff);
            Controls.Add(dtpHiredDate);
            Controls.Add(label4);
            Controls.Add(cbFemale);
            Controls.Add(txtStaffSalary);
            Controls.Add(label2);
            Controls.Add(dtpBirthDate);
            Controls.Add(label14);
            Controls.Add(btnNew);
            Controls.Add(btnUpdate);
            Controls.Add(btnSearch);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(txtSearch);
            Controls.Add(pbStaffPhoto);
            Controls.Add(cbStoppedWork);
            Controls.Add(label5);
            Controls.Add(txtStaffTel);
            Controls.Add(label6);
            Controls.Add(txtStaffAddress);
            Controls.Add(Address);
            Controls.Add(txtStaffPosition);
            Controls.Add(label3);
            Controls.Add(cbMale);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(txtFullName);
            Controls.Add(label12);
            Controls.Add(txtID);
            Controls.Add(label11);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StaffForm";
            Text = "StaffForm";
            WindowState = FormWindowState.Maximized;
            Load += StaffForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbStaffPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridStaff).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtDestination;
        private Label label15;
        private Label label16;
        private TextBox txtID;
        private Label label11;
        private CheckBox checkBox2;
        private CheckBox cbMale;
        private TextBox txtStaffPosition;
        private Label label3;
        private PictureBox pbStaffPhoto;
        private Label label14;
        private Button btnNew;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnSave;
        private TextBox txtSearch;
        private TextBox txtStaffSalary;
        private Label label2;
        private BindingSource bindingSource1;
        private CheckBox cbFemale;
        private DateTimePicker dtpHiredDate;
        private Label label4;
        private DataGridView gridStaff;
        private Label label12;
        private TextBox txtFullName;
        private Label Address;
        private TextBox txtStaffAddress;
        private Label label6;
        private DateTimePicker dtpBirthDate;
        private Label label5;
        private CheckBox cbStoppedWork;
        private TextBox txtStaffTel;
        private Button btnSearch;
    }
}