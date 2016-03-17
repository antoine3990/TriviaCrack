using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace TriviaCrack
{
    public partial class AdminQuestions : Form
    {
        public AdminQuestions()
        {
            InitializeComponent();
            initListBox();
            initDGV(DGV_questions, "Questions");
        }

        void initDGV(DataGridView dgv, string name)
        {
            dgv.Columns[0].Name = name.ToLower().Replace('é', 'e');
            dgv.Columns[0].HeaderText = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
        }
        void initListBox()
        {
            foreach (string c in Program.categories)
                LB_categories.Items.Add(c);

            LB_categories.SelectedIndex = 0;
        }
        private void fillDGV()
        {
            string category = LB_categories.GetItemText(LB_categories.SelectedItem).ToLower().Replace("é", "e");
            category = category.Substring(0, 1).ToUpper() + category.Substring(1);

            try
            {
                DataSet ds = Question.getAll(category);
                BindingSource bs = new BindingSource(ds, ds.Tables[0].TableName);
                DGV_questions.DataSource = bs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Update();
        }

        private void BT_addMod_Click(object sender, EventArgs e)
        {
            AddModQuestions form;

            string category = LB_categories.GetItemText(LB_categories.SelectedItem).ToLower().Replace("é", "e");
            category = category.Substring(0, 1).ToUpper() + category.Substring(1);

            if (((Button)sender).Name.Substring(3) == "modify")
                form = new AddModQuestions(category, DGV_questions.CurrentRow.Cells[0].Value.ToString());
            else
                form = new AddModQuestions();

            form.ShowDialog();

            fillDGV();
        }
        private void BT_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string question = DGV_questions.CurrentRow.Cells[0].Value.ToString();

                Answer.deleteAll(question);
                Question.delete(question);

                fillDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void DGV_questions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string question = DGV_questions.CurrentRow.Cells[0].Value.ToString();
            AddModQuestions form = new AddModQuestions(Question.getCategory(question), question);
            form.ShowDialog();

            fillDGV();
        }

        private void LB_categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDGV();
        }
    }
}
