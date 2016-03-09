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
    public partial class AddModQuestions : Form
    {
        private string originalQuestion;

        public AddModQuestions()
        {
            InitializeComponent();
        }

        public AddModQuestions(string category, string question, List<string>answers)
        {
            InitializeComponent();

            originalQuestion = question;
            PB_category.Image = (Image)Properties.Resources.ResourceManager.GetObject(category + "_bg");

            TB_question.Location = new Point(TB_question.Location.X + 31, TB_question.Location.Y);
            TB_question.Size = new Size(TB_question.Size.Width - 31, TB_question.Size.Height);
            PB_category.Visible = true;

            LB_title.Text = LB_title.Text.Replace("Ajout", "Modification");
            BT_accept.Text = "Modifier";

            TB_question.Text = question;
            for (int i = 1; i < answers.Count; i++)
                Controls["TB_answer" + i.ToString()].Text = answers[i - 1];
        }

        private void BT_accept_Click(object sender, EventArgs e)
        {
            if (BT_accept.Text == "Ajouter")
                addPlayer();
            else
                modPlayer();
        }

        private void addPlayer()
        {

        }

        private void modPlayer()
        {

        }
    }
}
