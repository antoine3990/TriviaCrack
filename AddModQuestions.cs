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

        public AddModQuestions(string category, string question)
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

            List<string> answers = Answer.get(question);
            for (int i = 1; i < answers.Count; i++)
                Controls["TB_answer" + i.ToString()].Text = answers[i - 1];
        }

        private void BT_accept_Click(object sender, EventArgs e)
        {
            if (!answersNotEmpty())
                MessageBox.Show("Réponses manquantes.");
            else if (TB_question.Text == "")
                MessageBox.Show("Question manquante."); 
            else if (TB_question.Text.IndexOf('?') == -1)
                MessageBox.Show("La question entrée n'est pas une question.");
            else
            {
                if (BT_accept.Text == "Ajouter")
                    addQuestion();
                else
                    modQuestion();
            }
        }

        private bool answersNotEmpty()
        {
            for (int i = 1; i < Program.nbAnswers; i++)
                if (Controls["TB_answer" + i.ToString()].Text == "")
                    return false;

            return true;
        }

        private void addQuestion()
        {
            Question.add(TB_question.Text, "Histoire");
            addAnswers(TB_question.Text);
        }

        private void modQuestion()
        {
            Answer.deleteAll(originalQuestion);
            addAnswers(originalQuestion);
            
            Question.modify(originalQuestion, TB_question.Text);
        }

        private void addAnswers(string question)
        {
            for (int i = 0; i < Program.nbAnswers; i++)
                Answer.add(question, Controls["TB_answer" + i.ToString()].Text, ((RadioButton)Controls["CB_correct" + i.ToString()]).Checked ? 'o' : 'n');
        }
    }
}
