namespace PABMS
{
    partial class BusForm
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
            label1 = new Label();
            txtTicketPrice = new TextBox();
            label16 = new Label();
            txtBusID = new TextBox();
            label11 = new Label();
            txtBusNo = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            txtDriverID = new TextBox();
            cmbDriverTel = new ComboBox();
            label5 = new Label();
            txtDriverName = new TextBox();
            label3 = new Label();
            label6 = new Label();
            label14 = new Label();
            btnNew = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnSave = new Button();
            txtSearch = new TextBox();
            gridBus = new DataGridView();
            label4 = new Label();
            txtBusTypeID = new TextBox();
            panel2 = new Panel();
            label7 = new Label();
            cmbBusTypeName = new ComboBox();
            btnSearch = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridBus).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(697, 79);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(174, 36);
            label1.TabIndex = 3;
            label1.Text = "Bus's Form";
            // 
            // txtTicketPrice
            // 
            txtTicketPrice.BorderStyle = BorderStyle.FixedSingle;
            txtTicketPrice.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtTicketPrice.Location = new Point(529, 264);
            txtTicketPrice.Margin = new Padding(5, 4, 5, 4);
            txtTicketPrice.Multiline = true;
            txtTicketPrice.Name = "txtTicketPrice";
            txtTicketPrice.Size = new Size(250, 34);
            txtTicketPrice.TabIndex = 30;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(338, 269);
            label16.Margin = new Padding(5, 0, 5, 0);
            label16.Name = "label16";
            label16.Size = new Size(141, 29);
            label16.TabIndex = 29;
            label16.Text = "Ticket Price";
            // 
            // txtBusID
            // 
            txtBusID.BorderStyle = BorderStyle.FixedSingle;
            txtBusID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBusID.Location = new Point(529, 209);
            txtBusID.Margin = new Padding(5, 4, 5, 4);
            txtBusID.Multiline = true;
            txtBusID.Name = "txtBusID";
            txtBusID.ReadOnly = true;
            txtBusID.Size = new Size(250, 34);
            txtBusID.TabIndex = 26;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(338, 214);
            label11.Margin = new Padding(5, 0, 5, 0);
            label11.Name = "label11";
            label11.Size = new Size(83, 29);
            label11.TabIndex = 25;
            label11.Text = "Bus ID";
            // 
            // txtBusNo
            // 
            txtBusNo.BorderStyle = BorderStyle.FixedSingle;
            txtBusNo.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBusNo.Location = new Point(1077, 208);
            txtBusNo.Margin = new Padding(5, 4, 5, 4);
            txtBusNo.Multiline = true;
            txtBusNo.Name = "txtBusNo";
            txtBusNo.Size = new Size(250, 34);
            txtBusNo.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(864, 213);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(147, 29);
            label2.TabIndex = 31;
            label2.Text = "Bus Number";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtDriverID);
            panel1.Controls.Add(cmbDriverTel);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtDriverName);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label6);
            panel1.Location = new Point(305, 329);
            panel1.Margin = new Padding(5, 4, 5, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(510, 207);
            panel1.TabIndex = 33;
            // 
            // txtDriverID
            // 
            txtDriverID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtDriverID.Location = new Point(223, 31);
            txtDriverID.Margin = new Padding(5, 4, 5, 4);
            txtDriverID.Multiline = true;
            txtDriverID.Name = "txtDriverID";
            txtDriverID.ReadOnly = true;
            txtDriverID.Size = new Size(250, 34);
            txtDriverID.TabIndex = 54;
            // 
            // cmbDriverTel
            // 
            cmbDriverTel.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDriverTel.FormattingEnabled = true;
            cmbDriverTel.Location = new Point(223, 146);
            cmbDriverTel.Margin = new Padding(5, 4, 5, 4);
            cmbDriverTel.Name = "cmbDriverTel";
            cmbDriverTel.Size = new Size(250, 37);
            cmbDriverTel.TabIndex = 53;
            cmbDriverTel.SelectedIndexChanged += cmbDriverTel_SelectedIndexChanged_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(30, 150);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(119, 29);
            label5.TabIndex = 7;
            label5.Text = "Driver Tel";
            // 
            // txtDriverName
            // 
            txtDriverName.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtDriverName.Location = new Point(223, 88);
            txtDriverName.Margin = new Padding(5, 4, 5, 4);
            txtDriverName.Multiline = true;
            txtDriverName.Name = "txtDriverName";
            txtDriverName.ReadOnly = true;
            txtDriverName.Size = new Size(250, 34);
            txtDriverName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(30, 92);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(148, 29);
            label3.TabIndex = 2;
            label3.Text = "Driver Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(30, 34);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(106, 29);
            label6.TabIndex = 0;
            label6.Text = "Driver ID";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(305, 563);
            label14.Margin = new Padding(5, 0, 5, 0);
            label14.Name = "label14";
            label14.Size = new Size(89, 29);
            label14.TabIndex = 52;
            label14.Text = "Search";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(192, 255, 255);
            btnNew.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnNew.Location = new Point(1187, 934);
            btnNew.Margin = new Padding(5, 4, 5, 4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(163, 50);
            btnNew.TabIndex = 51;
            btnNew.Text = "NEW";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 192, 128);
            btnUpdate.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdate.Location = new Point(893, 934);
            btnUpdate.Margin = new Padding(5, 4, 5, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(198, 50);
            btnUpdate.TabIndex = 50;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ActiveCaption;
            btnAdd.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(602, 934);
            btnAdd.Margin = new Padding(5, 4, 5, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(177, 50);
            btnAdd.TabIndex = 49;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(192, 192, 255);
            btnSave.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(308, 934);
            btnSave.Margin = new Padding(5, 4, 5, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(182, 50);
            btnSave.TabIndex = 48;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(433, 561);
            txtSearch.Margin = new Padding(5, 4, 5, 4);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 34);
            txtSearch.TabIndex = 46;
            // 
            // gridBus
            // 
            gridBus.AllowUserToAddRows = false;
            gridBus.AllowUserToDeleteRows = false;
            gridBus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridBus.Location = new Point(305, 623);
            gridBus.Margin = new Padding(5, 4, 5, 4);
            gridBus.Name = "gridBus";
            gridBus.ReadOnly = true;
            gridBus.RowHeadersWidth = 51;
            gridBus.RowTemplate.Height = 29;
            gridBus.Size = new Size(1045, 277);
            gridBus.TabIndex = 53;
            gridBus.CellClick += gridBus_CellClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(32, 113);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(180, 29);
            label4.TabIndex = 29;
            label4.Text = "BusType Name";
            // 
            // txtBusTypeID
            // 
            txtBusTypeID.BorderStyle = BorderStyle.FixedSingle;
            txtBusTypeID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBusTypeID.Location = new Point(236, 62);
            txtBusTypeID.Margin = new Padding(5, 4, 5, 4);
            txtBusTypeID.Multiline = true;
            txtBusTypeID.Name = "txtBusTypeID";
            txtBusTypeID.ReadOnly = true;
            txtBusTypeID.Size = new Size(250, 34);
            txtBusTypeID.TabIndex = 30;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(cmbBusTypeName);
            panel2.Controls.Add(txtBusTypeID);
            panel2.Location = new Point(840, 329);
            panel2.Margin = new Padding(5, 4, 5, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(510, 207);
            panel2.TabIndex = 33;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(32, 63);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(138, 29);
            label7.TabIndex = 29;
            label7.Text = "BusType ID";
            // 
            // cmbBusTypeName
            // 
            cmbBusTypeName.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cmbBusTypeName.FormattingEnabled = true;
            cmbBusTypeName.Location = new Point(236, 111);
            cmbBusTypeName.Margin = new Padding(5, 4, 5, 4);
            cmbBusTypeName.Name = "cmbBusTypeName";
            cmbBusTypeName.Size = new Size(250, 37);
            cmbBusTypeName.TabIndex = 53;
            cmbBusTypeName.SelectedIndexChanged += cmbBusTypeName_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(255, 192, 128);
            btnSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(697, 561);
            btnSearch.Margin = new Padding(5, 4, 5, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(118, 34);
            btnSearch.TabIndex = 50;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // BusForm
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(label2);
            Controls.Add(gridBus);
            Controls.Add(label14);
            Controls.Add(btnNew);
            Controls.Add(txtBusNo);
            Controls.Add(btnSearch);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(txtSearch);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(txtTicketPrice);
            Controls.Add(label16);
            Controls.Add(txtBusID);
            Controls.Add(label11);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 4, 5, 4);
            Name = "BusForm";
            Text = "BusForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridBus).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label16;
        private Label label11;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label6;
        private Label label14;
        private Label label7;
        private Button btnNew;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnSave;
        private Panel panel1;
        private TextBox txtTicketPrice;
        private TextBox txtBusID;
        private TextBox txtBusNo;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private TextBox txtDriverName;
        private TextBox txtSearch;
        private ComboBox cmbDriverTel;
        private TextBox txtDriverID;
        private DataGridView gridBus;
        private TextBox txtBusTypeID;
        private ComboBox cmbBusTypeName;
        private Panel panel2;
        private Button btnSearch;
    }
}