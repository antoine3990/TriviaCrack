using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaCrack
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            initDGV(DGV_questions, "Questions");
        }

        void initDGV(DataGridView dgv, string name)
        {
            dgv.ColumnCount = 1;
            dgv.Columns[0].Name = name.ToLower().Replace('é', 'e');
            dgv.Columns[0].HeaderText = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
        }

        void initListBox()
        {

        }
    }
}
