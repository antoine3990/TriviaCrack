using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

/*
wheel degrees (360/7)
51.4 = 25.7
102.8 = 77.1
154.2 = 128.5
205.6 = 179.9
257 = 231.3
308.4 = 282.7
334.1
*/

namespace TriviaCrack
{
    public partial class Game : Form
    {
        // Position des catégories (en degrées) sur la roue
        enum categoriesWheel : int { SCIENCE=334, DIVERTISSEMENT=26, GEOGRAPHIE=77, HISTOIRE=128, AUTRE=180, SPORT=231, ART=283 };
        Random rand = new Random();

        private int rotation;
        private int currentRotation = 0;
        private bool wheelClicked = false;
        private bool answerClicked = false;

        public Game(int minPlayers, int maxPlayers, int minPointsToWin, int maxPointsToWin)
        {
            InitializeComponent();

            InitMain(minPlayers, maxPlayers, minPointsToWin, maxPointsToWin);
            //PNL_main.BringToFront();
            PNL_wheel.BringToFront();
            PNL_wheel.Visible = true;
        }

        public void InitMain(int minPlayers, int maxPlayers, int minPointsToWin, int maxPointsToWin)
        {
            for (int i = minPlayers; i <= maxPlayers; i++) CB_nbJoueurs.Items.Add(i); // Ajout des nombres de joueurs dans le CB
            for (int i = minPointsToWin; i <= maxPointsToWin; i++) CB_nbPoints.Items.Add(i); // Ajout des nombre de trimestres dans le CB

            CB_nbJoueurs.SelectedIndex = 0; // Selectioner la valeur par defaut pour le CB
            CB_nbPoints.SelectedIndex = 0; // Selectioner la valeur par defaut pour le CB
        }

        private void ShowPlayerScore()
        {
            for (int i = 1; i <= Program.nbPlayers; i++)
                this.PNL_scores.Controls["PNL_score_J" + i.ToString()].Visible = true;
            
            List<string> players = GetPlayerNames();

            for (int i = 1; i <= players.Count; i++)
                this.PNL_scores.Controls["PNL_score_J" + i.ToString()].Controls["LB_score_name" + i.ToString()].Text = players[i - 1];
        }

        private List<string> GetPlayerNames()
        {
            List<string> names = new List<string>();

            foreach (Player j in Program.players)
                names.Add(j.name);

            return names;
        }

        // MouseEnter
        private void BT_answer_MouseEnter(object send, EventArgs e)
        {
            if (!answerClicked)
                ((Button)send).FlatAppearance.BorderColor = Color.White;
        }
        private void BT_accept_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).FlatAppearance.BorderColor = Color.FromArgb(67, 205, 80);
        }
        private void BT_MouseEnter(object send, EventArgs e)
        {
            if (!error_addPlayer)
            {
                Button sender = (Button)send;
                string name = sender.Name.Substring(3) + "_white";
                sender.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(name);
                sender.FlatAppearance.BorderColor = Color.White;
            }
        }
        private void BT_chooseCategory_MouseEnter(object send, EventArgs e)
        {
            Button sender = (Button)send;
            List<int> col = GetRGBBackground(sender, false);
            sender.FlatAppearance.MouseOverBackColor = Color.FromArgb(col[0], col[1], col[2]);
            sender.FlatAppearance.BorderColor = Color.FromArgb(col[0], col[1], col[2]);
        }

        // MouseLeave
        private void BT_answer_MouseLeave(object send, EventArgs e)
        {
            if (!answerClicked)
                ((Button)send).FlatAppearance.BorderColor = Color.FromArgb(120, 120, 120);
        }
        private void BT_MouseLeave(object send, EventArgs e)
        {
            if (!error_addPlayer)
            {
                Button sender = (Button)send;
                string name = sender.Name.Substring(3) + "_grey";
                sender.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(name);
                sender.FlatAppearance.BorderColor = Color.FromArgb(65, 65, 65);
            }
        }

        // OnClick
        private void PB_wheel_Click(object sender, EventArgs e)
        {
            if (!wheelClicked)
            {
                PB_wheel.Cursor = Cursors.WaitCursor;
                wheelClicked = true;

                BW_rotateWheel.RunWorkerAsync();
            }
        }
        private void BT_answer_Click(object send, EventArgs e)
        {
            Button sender = (Button)send;

            for (int i = 1; i <= Program.nbAnswers; i++)
                this.Controls["PNL_questions"].Controls["BT_answer" + i.ToString()].Cursor = Cursors.Default;

            bool correct = sender.Tag.ToString() == "correct";
            if (!answerClicked)
            {
                if (correct)
                    CorrectAnswer(sender);
                else
                    IncorrectAnswer(sender);
            }
            answerClicked = true;

            ShowNextTurn(correct);
        }
        private void BT_start_Click(object sender, EventArgs e)
        {
            PNL_main.Visible = false;

            Program.nbPlayers = int.Parse(CB_nbJoueurs.Text);
            Program.pointsToWin = int.Parse(CB_nbPoints.Text);

            PNL_nameSelection.Visible = true;
            PNL_nameSelection.BringToFront();
        }
        private void BT_showScore_Click(object sender, EventArgs e)
        {
            PNL_scores.Visible = true;
            PNL_scores.BringToFront();
        }
        private void BT_quitScores_Click(object sender, EventArgs e)
        {
            PNL_scores.Visible = false;
        }
        private void BT_addPlayer_Click(object sender, EventArgs e)
        {
            AddPlayer();
        }
        private void BT_chooseCategory_Click(object sender, EventArgs e)
        {
            LB_category.Text = ((Button)sender).Text;
            ShowQuestionWindow();
            PNL_category.Visible = false;
        }
        private void BT_nextTurn_Click(object sender, EventArgs e)
        {
            // UPDATE BD si la réponse est bonne
            //if (BT_nextTurn.Text == "Tourner la roulette à nouveau")
            BT_nextTurn.Visible = false;
            ResetApp();
        }

        private async void ShowNextTurn(bool correct)
        {
            await Task.Delay(3000);
            PNL_questions.BackColor = BT_nextTurn.BackColor;
            BT_nextTurn.Text = correct ? "Tourner la roulette à nouveau" : "Tour du prochain joueur";
            BT_nextTurn.Visible = true;
        }

        private void CorrectAnswer(Button sender)
        {
            sender.FlatAppearance.BorderColor = Color.FromArgb(67, 205, 80);
            Program.players[Program.currentPlayer].addPoint(Program.categories[getCategoryPos(getCategoryFromAngle(currentRotation))]);
            
            LB_pointsCategory.Text = getCategoryPoints(getCategoryFromAngle(currentRotation));
            LB_pointsCategory.ForeColor = Color.FromArgb(67, 205, 80);
            Update();
        }
        private void IncorrectAnswer(Button sender)
        {
            sender.FlatAppearance.BorderColor = Color.FromArgb(205, 67, 67);

            Button correctAnswer = GetCorrectAnswer();
            correctAnswer.FlatAppearance.BorderColor = Color.White;
        }
        
        // Questions/Réponses
        private string GetQuestion(string category)
        {
            string question = "";

            // Sélectionner une question au hasard dans la liste de question de la catégorie
            // passée en paramètre + qui n'a pas déja été répondu. Si toute les questions ont
            // étés répondues, en prendre une au hasard de celles qui n'a pas été répondu
            // correctement.

            return question;
        }
        private List<string> GetAnswers(string question)
        {
            List<string> answers = new List<string>();

            // Temporaire
            answers.Add("Answer 1");
            answers.Add("Answer 2");
            answers.Add("Answer 3");
            answers.Add("Answer 4");
            SetCorrectAnswer(question, answers);

            // Sélectionner la liste de réponses à la question passée en paramètre

            return answers;
        }

        private void SetCorrectAnswer(string question, List<string> answers)
        {
            // string correctAnswerTxt = Prendre la réponse à la question ayant la valeur EstBonne à Y
            // int correctAnswer = answers.IndexOf(correctAnswerTxt) + 1;
            int correctAnswer = 3;
            
            ((Button)this.Controls["PNL_questions"].Controls["BT_answer" + correctAnswer.ToString()]).Tag = "correct";
        }

        private Button GetCorrectAnswer()
        {
            if (BT_answer1.Tag.ToString() == "correct")
                return BT_answer1;
            else if (BT_answer2.Tag.ToString() == "correct")
                return BT_answer2;
            else if (BT_answer3.Tag.ToString() == "correct")
                return BT_answer3;
            else
                return BT_answer4;
        }
        
        // Apparences
        private void ShowQuestionWindow()
        {
            PNL_questions.Enabled = true;
            PNL_questions.BringToFront();
            PNL_category.BringToFront();
            PNL_wheel.Visible = false;

            string category = LB_category.Text.ToLower().Replace('é', 'e');
            if (category == "autre")
                PNL_category.Visible = true;
            else
            {
                PNL_questions.Visible = true;

                // Modifier l'image du picturebox selon la catégorie
                PB_question.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(category);

                // Afficher la question et les réponses
                ShowAnswers(ShowQuestion(category));

                // Afficher le score du joueur
                LB_pointsCategory.Text = getCategoryPoints(category);
            }
        }
        private string ShowQuestion(string category)
        {
            string question = GetQuestion(category);
            LB_question.Text = question;
            return question;
        }
        private void ShowAnswers(string question)
        {
            List<string> answers = GetAnswers(question);

            for (int i = 0; i < answers.Count; i++)
                this.PNL_questions.Controls["BT_answer" + (i + 1).ToString()].Text = answers[i];
        }

        private void flashText()
        {
            int flashes = 5;
            for (int i = 0; i < flashes; i++)
            {
                Color textColor = LB_category.ForeColor;
                LB_category.ForeColor = textColor == Color.White ? Color.FromArgb(90, 90, 90) : Color.White;
                Invoke(new Action(() => this.Update()));
                System.Threading.Thread.Sleep(500);
            }
            System.Threading.Thread.Sleep(500);
        }
        
        private void rotate()
        {
            currentRotation += rotation;
            LB_category.Invoke(new Action(() => LB_category.Text = getCategoryFromAngle(currentRotation)));

            PB_wheel.Image = Properties.Resources.wheel;
            PB_wheel.Invoke(new Action(() => PB_wheel.Image = RotateImage(PB_wheel.Image, currentRotation)));
        }

        private Image RotateImage(Image img, float rotationAngle)
        {
            // Bitmap de la taille de l'image
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            // Graphics pour effecter les opérations sur l'image
            Graphics gfx = Graphics.FromImage(bmp);

            // Mettre le point de rotation au centre de l'image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            // Éffectuer la rotation de l'image
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            gfx.DrawImage(img, new Point(0, 0)); // Dessiner l'image

            gfx.Dispose();

            return bmp;
        }

        private List<int> GetRotatingTimes()
        {
            List<int> times = new List<int>();
            int limit = 125;

            for (int i = 0; limit > 0; i++)
            {
                int t = rand.Next(5, 25);
                limit -= t;
                times.Add(t);
            }
            times.Sort();

            return times;
        }
        private List<int> GetDegrees(List<int> times)
        {
            List<int> degrees = new List<int>();
            int max = 25;
            decimal steps = Decimal.Divide(max, times.Count);

            for (decimal i = max; i > 0; i -= steps)
                degrees.Add((int)i);

            return degrees;
        }

        private string getCategoryFromAngle(int deg)
        {
            deg %= 360;

            if (deg >= (int)categoriesWheel.SCIENCE)
                return "Science";
            else if (deg >= (int)categoriesWheel.ART)
                return "Divertissement";
            else if (deg >= (int)categoriesWheel.SPORT)
                return "Géographie";
            else if (deg >= (int)categoriesWheel.AUTRE)
                return "Histoire";
            else if (deg >= (int)categoriesWheel.HISTOIRE)
                return "Autre";
            else if (deg >= (int)categoriesWheel.GEOGRAPHIE)
                return "Sport";
            else if (deg >= (int)categoriesWheel.DIVERTISSEMENT)
                return "Art";
            else
                return "Science";
        }
        private string getCategoryPoints(string category)
        {
            int posCategory = getCategoryPos(category);

            if (posCategory != -1)
                return Program.players[Program.currentPlayer].points[posCategory].points.ToString();

            return "0";
        }
        private int getCategoryPos(string name_)
        {
            for (int i = 0; i < Program.categories.Count; i++)
                if (Program.categories[i].name.ToLower() == name_.ToLower()) return i;

            return -1;
        }


        private void DrawWinnerScore(string playerName)
        {
            Control pName = this.PNL_scores.Controls["PNL_score_J1"].Controls["LB_score_name1"];
            for (int i = 2; i <= Program.nbPlayers; i++)
            {
                if (playerName == pName.Text)
                    break;
                pName = this.PNL_scores.Controls["PNL_score_J" + i.ToString()].Controls["LB_score_name" + i.ToString()];
            }

            pName.ForeColor = Color.White;
            PB_score.Location = new Point(PB_score.Location.X, pName.Parent.Location.Y + pName.Location.Y + 10);
            PB_score.Visible = true;
            PB_score.BringToFront();
        }


        private string AddUppercases(string s)
        {
            // Mettre la première lettre en MAJ.
            s = s[0].ToString().ToUpper() + s.Substring(1);

            for (int i = 0; i < s.Length - 1; i++)
            {
                // Si le char est un espace, changer la prochaine lettre pour une majuscule.
                if (s[i] == ' ')
                    s = s.Substring(0, i) + ' ' + s[i + 1].ToString().ToUpper() + (i + 2 < s.Length ? s.Substring(i + 2) : "");
            }

            return s;
        }

        private string FilterName(string s)
        {
            if (s[0] == ' ' || s[0] == '-')
                s = s.Substring(1);
            if (s[s.Length - 1] == ' ' || s[s.Length - 1] == '-')
                s = s.Substring(0, s.Length - 2);

            return s;
        }

        private void AddPlayer()
        {
            if (TB_newName.TextLength > 2 && NameIsValid(TB_newName.Text)) // Si le nom du joueur a au moins 2 char.
            {
                Program.players.Add(new Player(AddUppercases(FilterName(TB_newName.Text)))); // Ajoute le nom à la liste.
                //Program.players.Add(TB_newName.Text);
                TB_newName.Text = String.Empty; // Vide le TxtBox.

                if (Program.currentPlayer == Program.nbPlayers - 1) // Si le nombre de joueur choisi est atteint, stop.
                {
                    PNL_nameSelection.Visible = false; // Fermer ce menu.
                    ShowPlayerScore();
                }
                else Program.changePlayer(); // Prochain Joueur

                string[] nums = { "premier", "deuxième", "troisième", "quatrième" };
                LB_nameCount.Text = "Nom du " + nums[Program.currentPlayer] + " joueur"; // Modification du label avec le bon # de joueur.
            }
            else
            {
                LB_newName_error.Visible = true;
                ErrorBT_addPlayer();
            }
        }

        private bool NameIsValid(string name)
        {
            for (int i = 0; i < name.Length; i++)
                if (!(IsAlpha(name[i]) || name[i] == ' ' || name[i] == '-'))
                    return false;

            return true;
        }

        private void TB_newName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((IsAlpha(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == '-' || e.KeyChar == '\b') && FilterSpaces(e.KeyChar));
        }
        private static bool IsAlpha(char c)
        {
            String AjoutMultiplications = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return (AjoutMultiplications.IndexOf(c.ToString()) != -1);
        }

        private bool FilterSpaces(char e)
        {
            if (TB_newName.TextLength > 0)
            {
                if ((e == ' ' || e == '-') && (TB_newName.Text[TB_newName.TextLength - 1] == ' ' || TB_newName.Text[TB_newName.TextLength - 1] == '-'))
                    return false;
            }
            return true;
        }

        private void DisableBT_addPlayer()
        {
            BT_addPlayer.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("addPlayer_darkgrey");
            BT_addPlayer.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            BT_addPlayer.Enabled = false;
        }

        private bool error_addPlayer = false;
        private void ErrorBT_addPlayer()
        {
            BT_addPlayer.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("addPlayer_red");
            BT_addPlayer.FlatAppearance.BorderColor = Color.FromArgb(205, 67, 67);
            error_addPlayer = true;
        }


        private void BT_chooseCategory_MouseLeave(object send, EventArgs e)
        {
            Button sender = (Button)send;
            sender.FlatAppearance.BorderColor = sender.BackColor;
        }


        private void TB_newName_TextChanged(object sender, EventArgs e)
        {
            error_addPlayer = false;
            LB_newName_error.Visible = false;

            if (TB_newName.TextLength > 2)
            {
                BT_addPlayer.Enabled = true;
                BT_MouseLeave(BT_addPlayer, new EventArgs());
            }
            else
                DisableBT_addPlayer();
        }




        private List<int> GetRGBBackground(Button s, bool MouseClick)
        {
            double x = MouseClick ? 0.75 : 0.8;
            return new List<int>() { (int)(s.BackColor.R * x), (int)(s.BackColor.G * x), (int)(s.BackColor.B * x) };
        }

        private void BT_chooseCategory_MouseDown(object send, MouseEventArgs e)
        {
            Button sender = (Button)send;
            List<int> col = GetRGBBackground(sender, true);
            sender.FlatAppearance.MouseDownBackColor = Color.FromArgb(col[0], col[1], col[2]);
            sender.FlatAppearance.BorderColor = Color.FromArgb(col[0], col[1], col[2]);
        }

        private void BT_chooseCategory_MouseUp(object send, MouseEventArgs e)
        {
            Button sender = (Button)send;
            BT_chooseCategory_MouseEnter(send, new EventArgs());
            sender.ForeColor = Color.White;
        }


        private void ResetApp()
        {
            PNL_questions.BackColor = PNL_scores.BackColor;

            for (int i = 1; i <= Program.nbAnswers; i++)
            {
                Button BT = (Button)this.Controls["PNL_questions"].Controls["BT_answer" + i.ToString()];
                BT.Cursor = Cursors.Hand;
                BT.FlatAppearance.BorderColor = Color.FromArgb(120, 120, 120);
            }
            LB_pointsCategory.ForeColor = Color.White;
            PNL_questions.Enabled = false;
            PNL_wheel.BringToFront();
            PNL_wheel.Visible = true;
            PB_wheel.Cursor = Cursors.Hand;
            wheelClicked = false;
            answerClicked = false;
            currentRotation = 0;
            PB_wheel.Image = Properties.Resources.wheel;
        }

        private void BW_rotateWheel_DoWork(object sender, DoWorkEventArgs e)
        {
            List<int> times = GetRotatingTimes();
            List<int> degrees = GetDegrees(times);

            for (int i = 0; i < times.Count; i++)
            {
                rotation = degrees[i];
                for (int j = 0; j < times[i]; j++)
                {
                    rotate();
                    Invoke(new Action(() => this.Update()));
                    System.Threading.Thread.Sleep(20);
                }
            }

            flashText();
        }

        private void BW_rotateWheel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowQuestionWindow();
        }
    }
}