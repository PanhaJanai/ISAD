using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PABMS
{
    public partial class SavingDialogue : Form
    {
        public DataTable save_table = new DataTable();
        public SavingDialogue(DataTable table)
        {
            InitializeComponent();
            gridDialogue.DataSource = table;
            save_table = table;
            this.FormClosing += new FormClosingEventHandler(SavingDialogue_FormClosing);
        }

        private void SavingDialogue_FormClosing(object sender, FormClosingEventArgs e)
        {
            save_table = (DataTable)gridDialogue.DataSource;
            
        }
    }
}
