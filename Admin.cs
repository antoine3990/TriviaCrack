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
            initListBox();
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
            foreach (string c in Program.categories)
                LB_categories.Items.Add(c);
        }

        private void BT_addMod_Click(object sender, EventArgs e)
        {
            AddModQuestions form;

            if (((Button)sender).Name.Substring(3) == "modify")
                form = new AddModQuestions(LB_categories.GetItemText(LB_categories.SelectedItem).ToLower().Replace("é", "e"), DGV_questions.SelectedRows[0].Cells[0].Value.ToString());
            else
                form = new AddModQuestions();

            form.ShowDialog();
        }

        private void BT_delete_Click(object sender, EventArgs e)
        {
            string question = DGV_questions.SelectedRows[0].Cells[0].Value.ToString();

            Answer.deleteAll(question);
            Question.delete(question);
        }
    }
}
