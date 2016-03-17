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
        private ToolTip toolTip_question = new ToolTip();

        public AddModQuestions()
        {
            InitializeComponent();
            fillComboBox(null);
        }

        public AddModQuestions(string category, string question)
        {
            InitializeComponent();
            fillComboBox(category);

            originalQuestion = question;
            toolTip_question.SetToolTip(TB_question, question);
            Text = "Modifier une question";

            LB_title.Text = LB_title.Text.Replace("Ajout", "Modification");
            BT_accept.Text = "Modifier";
            TB_question.Text = question;
            TB_question.SelectionStart = 0;
            TB_question.SelectionLength = 0;

            List<string> answers = new List<string>();
            int correctAnswer = 1;

            try
            {
                answers = Answer.get(question);
                correctAnswer = answers.IndexOf(Answer.getCorrect(question)) + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            for (int i = 1; i <= answers.Count; i++)
                Controls["TB_answer" + i.ToString()].Text = answers[i - 1];

            ((RadioButton)Controls["RB_correct" + correctAnswer.ToString()]).Checked = true;
        }

        private void fillComboBox(string category)
        {
            foreach (string cat in Program.categories)
                CB_category.Items.Add(cat.ToLower().Replace('é', 'e'));

            if (category == null)
                CB_category.SelectedIndex = 0;
            else
                CB_category.SelectedIndex = Program.categories.IndexOf(category);
        }

        private void BT_accept_Click(object sender, EventArgs e)
        {
            if (answersEmpty())
                MessageBox.Show("Réponses manquantes.");
            else if (TB_question.Text == "")
                MessageBox.Show("Question invalide.");
            else if (TB_question.Text.IndexOf('?') != TB_question.TextLength - 1)
                MessageBox.Show("La question entrée n'est pas une question.");
            else if (!RadioBoxChecked())
                MessageBox.Show("Aucune bonne réponse n'a été sélectionnée.");
            else
            {
                if (BT_accept.Text == "Ajouter")
                    addQuestion();
                else
                    modQuestion();

                this.Close();
            }
        }
        private void RB_correct_CheckedChanged(object send, EventArgs e)
        {
            RadioButton rb = (RadioButton)send;

            for (int i = 1; i <= Program.nbAnswers; i++)
                Controls["RB_correct" + i.ToString()].BackgroundImage = Properties.Resources.incorrect;

            rb.BackgroundImage = Properties.Resources.correct;
        }

        private void CB_category_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 45)), e.Bounds);

            e.Graphics.DrawImage((Image)Properties.Resources.ResourceManager.GetObject(CB_category.Items[e.Index].ToString() + "_small"), e.Bounds.Left, e.Bounds.Top);
        }

        private bool RadioBoxChecked()
        {
            for (int i = 1; i <= Program.nbAnswers; i++)
                if (((RadioButton)Controls["RB_correct" + i.ToString()]).Checked)
                    return true;

            return false;
        }
        private bool answersEmpty()
        {
            for (int i = 1; i < Program.nbAnswers; i++)
                if (Controls["TB_answer" + i.ToString()].Text == "")
                    return true;

            return false;
        }

        private void addQuestion()
        {
            try
            {
                Question.add(TB_question.Text, Program.categories[CB_category.SelectedIndex]);
                addAnswers(TB_question.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void modQuestion()
        {
            try
            {
                Answer.deleteAll(originalQuestion);
                addAnswers(originalQuestion);
                
                Question.modify(originalQuestion, TB_question.Text, Program.categories[CB_category.SelectedIndex]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void addAnswers(string question)
        {
            try
            {
                for (int i = 1; i <= Program.nbAnswers; i++)
                {
                    char correct = ((RadioButton)Controls["RB_correct" + i.ToString()]).Checked ? 'o' : 'n';
                    Answer.add(question, Controls["TB_answer" + i.ToString()].Text, correct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
