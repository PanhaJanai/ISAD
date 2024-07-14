namespace PABMS
{
    partial class TicketForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel3 = new Panel();
            txtBusID = new TextBox();
            cmbBusNumber = new ComboBox();
            txtTicketPrice = new TextBox();
            label10 = new Label();
            label8 = new Label();
            label9 = new Label();
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            txtTicketID = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            txtDestination = new TextBox();
            label15 = new Label();
            txtOrigin = new TextBox();
            label16 = new Label();
            txtSearch = new TextBox();
            btnSave = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnNew = new Button();
            label14 = new Label();
            dtpDeparture = new DateTimePicker();
            dtpPurchase = new DateTimePicker();
            gridTicket = new DataGridView();
            btnSearch = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridTicket).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(txtBusID);
            panel3.Controls.Add(cmbBusNumber);
            panel3.Controls.Add(txtTicketPrice);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(779, 172);
            panel3.Name = "panel3";
            panel3.Size = new Size(513, 184);
            panel3.TabIndex = 1;
            // 
            // txtBusID
            // 
            txtBusID.BorderStyle = BorderStyle.FixedSingle;
            txtBusID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBusID.Location = new Point(262, 27);
            txtBusID.Multiline = true;
            txtBusID.Name = "txtBusID";
            txtBusID.ReadOnly = true;
            txtBusID.Size = new Size(178, 34);
            txtBusID.TabIndex = 29;
            // 
            // cmbBusNumber
            // 
            cmbBusNumber.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            cmbBusNumber.FormattingEnabled = true;
            cmbBusNumber.Location = new Point(262, 71);
            cmbBusNumber.Name = "cmbBusNumber";
            cmbBusNumber.Size = new Size(178, 37);
            cmbBusNumber.TabIndex = 28;
            cmbBusNumber.SelectedIndexChanged += cmbBusNumber_SelectedIndexChanged;
            // 
            // txtTicketPrice
            // 
            txtTicketPrice.BorderStyle = BorderStyle.FixedSingle;
            txtTicketPrice.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtTicketPrice.Location = new Point(262, 118);
            txtTicketPrice.Multiline = true;
            txtTicketPrice.Name = "txtTicketPrice";
            txtTicketPrice.ReadOnly = true;
            txtTicketPrice.Size = new Size(178, 34);
            txtTicketPrice.TabIndex = 13;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(224, 224, 224);
            label10.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(82, 123);
            label10.Name = "label10";
            label10.Size = new Size(141, 29);
            label10.TabIndex = 12;
            label10.Text = "Ticket Price";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(224, 224, 224);
            label8.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(82, 80);
            label8.Name = "label8";
            label8.Size = new Size(147, 29);
            label8.TabIndex = 10;
            label8.Text = "Bus Number";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(224, 224, 224);
            label9.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(82, 32);
            label9.Name = "label9";
            label9.Size = new Size(83, 29);
            label9.TabIndex = 8;
            label9.Text = "Bus ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(675, 58);
            label1.Name = "label1";
            label1.Size = new Size(204, 36);
            label1.TabIndex = 2;
            label1.Text = "Ticket's Form";
            // 
            // txtTicketID
            // 
            txtTicketID.BorderStyle = BorderStyle.FixedSingle;
            txtTicketID.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtTicketID.Location = new Point(484, 194);
            txtTicketID.Multiline = true;
            txtTicketID.Name = "txtTicketID";
            txtTicketID.ReadOnly = true;
            txtTicketID.Size = new Size(250, 34);
            txtTicketID.TabIndex = 10;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(253, 193);
            label11.Name = "label11";
            label11.Size = new Size(108, 29);
            label11.TabIndex = 9;
            label11.Text = "Ticket ID";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(251, 399);
            label12.Name = "label12";
            label12.Size = new Size(156, 29);
            label12.TabIndex = 11;
            label12.Text = "Purchas Date";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(251, 451);
            label13.Name = "label13";
            label13.Size = new Size(176, 29);
            label13.TabIndex = 13;
            label13.Text = "Departure Date";
            // 
            // txtDestination
            // 
            txtDestination.BorderStyle = BorderStyle.FixedSingle;
            txtDestination.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtDestination.Location = new Point(484, 300);
            txtDestination.Multiline = true;
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(250, 34);
            txtDestination.TabIndex = 18;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(253, 302);
            label15.Name = "label15";
            label15.Size = new Size(133, 29);
            label15.TabIndex = 17;
            label15.Text = "Destination";
            // 
            // txtOrigin
            // 
            txtOrigin.BorderStyle = BorderStyle.FixedSingle;
            txtOrigin.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrigin.Location = new Point(484, 249);
            txtOrigin.Multiline = true;
            txtOrigin.Name = "txtOrigin";
            txtOrigin.Size = new Size(250, 34);
            txtOrigin.TabIndex = 16;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(253, 249);
            label16.Name = "label16";
            label16.Size = new Size(79, 29);
            label16.TabIndex = 15;
            label16.Text = "Origin";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(359, 533);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 34);
            txtSearch.TabIndex = 19;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Lime;
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(213, 925);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(152, 51);
            btnSave.TabIndex = 21;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ActiveCaption;
            btnAdd.ForeColor = Color.Black;
            btnAdd.Location = new Point(551, 925);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(152, 51);
            btnAdd.TabIndex = 22;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 192, 128);
            btnUpdate.ForeColor = Color.Black;
            btnUpdate.Location = new Point(893, 925);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(152, 51);
            btnUpdate.TabIndex = 23;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(192, 255, 255);
            btnNew.ForeColor = Color.Black;
            btnNew.Location = new Point(1190, 925);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(152, 51);
            btnNew.TabIndex = 24;
            btnNew.Text = "NEW";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(213, 536);
            label14.Name = "label14";
            label14.Size = new Size(89, 29);
            label14.TabIndex = 25;
            label14.Text = "Search";
            // 
            // dtpDeparture
            // 
            dtpDeparture.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDeparture.Location = new Point(485, 449);
            dtpDeparture.Name = "dtpDeparture";
            dtpDeparture.Size = new Size(422, 34);
            dtpDeparture.TabIndex = 26;
            // 
            // dtpPurchase
            // 
            dtpPurchase.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            dtpPurchase.Location = new Point(484, 394);
            dtpPurchase.Name = "dtpPurchase";
            dtpPurchase.Size = new Size(423, 34);
            dtpPurchase.TabIndex = 27;
            // 
            // gridTicket
            // 
            gridTicket.AllowUserToAddRows = false;
            gridTicket.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridTicket.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridTicket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridTicket.DefaultCellStyle = dataGridViewCellStyle2;
            gridTicket.Location = new Point(213, 598);
            gridTicket.Name = "gridTicket";
            gridTicket.ReadOnly = true;
            gridTicket.RowHeadersWidth = 51;
            gridTicket.RowTemplate.Height = 29;
            gridTicket.Size = new Size(1129, 304);
            gridTicket.TabIndex = 28;
            gridTicket.Scroll += gridTicket_Scroll;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ActiveCaption;
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(628, 531);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(106, 38);
            btnSearch.TabIndex = 22;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // TicketForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1597, 1060);
            Controls.Add(gridTicket);
            Controls.Add(dtpPurchase);
            Controls.Add(dtpDeparture);
            Controls.Add(label14);
            Controls.Add(btnNew);
            Controls.Add(btnUpdate);
            Controls.Add(btnSearch);
            Controls.Add(btnAdd);
            Controls.Add(txtSearch);
            Controls.Add(txtDestination);
            Controls.Add(label15);
            Controls.Add(txtOrigin);
            Controls.Add(label16);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(txtTicketID);
            Controls.Add(label11);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(btnSave);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "TicketForm";
            Text = "TicketForm";
            WindowState = FormWindowState.Maximized;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridTicket).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel3;
        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox txtTicketPrice;
        private Label label10;
        private Label label8;
        private Label label9;
        private TextBox txtTicketID;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox txtDestination;
        private Label label15;
        private TextBox txtOrigin;
        private Label label16;
        private TextBox txtSearch;
        private Button btnSave;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnNew;
        private Label label14;
        private DateTimePicker dtpDeparture;
        private DateTimePicker dtpPurchase;
        private ComboBox cmbBusNumber;
        private TextBox txtBusID;
        private DataGridView gridTicket;
        private Button btnSearch;
    }
}