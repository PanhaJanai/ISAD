namespace PABMS
{
    partial class SavingDialogue
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
            gridDialogue = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridDialogue).BeginInit();
            SuspendLayout();
            // 
            // gridDialogue
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridDialogue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridDialogue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDialogue.Dock = DockStyle.Fill;
            gridDialogue.Location = new Point(0, 0);
            gridDialogue.Name = "gridDialogue";
            gridDialogue.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gridDialogue.RowsDefaultCellStyle = dataGridViewCellStyle2;
            gridDialogue.RowTemplate.Height = 29;
            gridDialogue.Size = new Size(1304, 633);
            gridDialogue.TabIndex = 84;
            // 
            // SavingDialogue
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1304, 633);
            Controls.Add(gridDialogue);
            Name = "SavingDialogue";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)gridDialogue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridDialogue;
    }
}