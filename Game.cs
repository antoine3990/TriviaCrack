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
    /// <summary>
    /// Classe principale du jeu. Représente la fenêtre de jeu.
    /// </summary>
    public partial class Game : Form
    {
        Random rand = new Random();

        private int rotation;
        private int currentRotation = 0;
        private bool wheelClicked = false;
        private bool answerClicked = false;

        public Game(int minPlayers, int maxPlayers, int minPointsToWin, int maxPointsToWin)
        {
            InitializeComponent();

            InitMain(minPlayers, maxPlayers, minPointsToWin, maxPointsToWin);
            PNL_main.BringToFront();
            //PNL_wheel.BringToFront();
            //PNL_wheel.Visible = true;
        }
        public void InitMain(int minPlayers, int maxPlayers, int minPointsToWin, int maxPointsToWin)
        {
            for (int i = minPlayers; i <= maxPlayers; i++) CB_nbJoueurs.Items.Add(i); // Ajout des nombres de joueurs dans le CB
            for (int i = minPointsToWin; i <= maxPointsToWin; i++) CB_nbPoints.Items.Add(i); // Ajout des nombre de trimestres dans le CB

            CB_nbJoueurs.SelectedIndex = 0; // Selectioner la valeur par defaut pour le CB
            CB_nbPoints.SelectedIndex = 0; // Selectioner la valeur par defaut pour le CB
        }

        #region MouseEnter

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

        #endregion

        #region MouseLeave

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
        private void BT_chooseCategory_MouseLeave(object send, EventArgs e)
        {
            Button sender = (Button)send;
            sender.FlatAppearance.BorderColor = sender.BackColor;
        }

        #endregion

        #region MouseDownUp

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

        #endregion

        #region On click

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
        private async void ShowNextTurn(bool correct)
        {
            await Task.Delay(3000);
            PNL_questions.BackColor = BT_nextTurn.BackColor;
            BT_nextTurn.Text = correct ? "Tourner la roulette à nouveau" : "Tour du prochain joueur";
            BT_nextTurn.Visible = true;
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
            addPlayer();
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

        #endregion

        #region Keypress

        private void TB_newName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((isAlpha(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == '-' || e.KeyChar == '\b') && filterSpaces(e.KeyChar));
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

        #endregion
        
        #region Fenetre de question

        private void ShowQuestionWindow()
        {
            PNL_wheel.Visible = false; // Cacher la fenetre de la roue
            PNL_questions.Enabled = true; // Activer le panel de la question/réponses

            PNL_questions.BringToFront();
            PNL_category.BringToFront();

            string category = LB_category.Text.ToLower().Replace('é', 'e'); // Nom de la catégorie
            if (category == "autre")
                PNL_category.Visible = true; // Afficher le choix de catégories
            else
            {
                PNL_questions.Visible = true; // Afficher la question et les réponses
                
                // Modifier l'image du picturebox selon la catégorie
                PB_question.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(category);

                try
                {
                    showAnswers(showQuestion(category)); // Afficher la question et les réponses
                }
                catch (NullReferenceException nre)
                {
                    MessageBox.Show(nre.Message.ToString());
                }
                
                LB_pointsCategory.Text = getCategoryPoints(category); // Afficher le score du joueur
            }
        }
        private Question showQuestion(string category)
        {
            try
            {
                Question question = Program.getCategory(category).getQuestion();
                LB_question.Text = question.name;
                return question;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Cette catégorie ne contient aucune question.");
            }

            return null;
        }
        private void showAnswers(Question question)
        {
            if (question == null)
                throw new NullReferenceException("La question est nulle. Impossible d'importer les réponses.");

            for (int i = 0; i < question.answers.Count; i++)
                this.PNL_questions.Controls["BT_answer" + (i + 1).ToString()].Text = question.answers[i].name;
        }

        private Button GetCorrectAnswer(string category)
        {
            List<Answer> answers = Program.getCategory(category).getQuestion().answers;
            for (int i = 0; i < answers.Count; i++)
                if (answers[i].correct)
                    return (Button)this.Controls["PNL_questions"].Controls["BT_answer" + i.ToString()];

            return null;
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

            Button correctAnswer = GetCorrectAnswer(LB_category.Text.Replace('é', 'e'));
            correctAnswer.FlatAppearance.BorderColor = Color.White;
        }

        #endregion

        #region Ajout d'un joueur

        private void addPlayer()
        {
            if (TB_newName.TextLength > 2 && nameIsValid(TB_newName.Text)) // Si le nom du joueur contient au moins 2 char et est valide.
            {
                try
                {
                    Program.players.Add(new Player(addUpperCase(filterName(TB_newName.Text)))); // Ajoute le nom à la liste.

                    if (Program.currentPlayer == Program.nbPlayers - 1) // Si le nombre de joueur choisi est atteint, stop.
                    {
                        PNL_nameSelection.Visible = false; // Fermer ce menu
                        showPlayerScores();
                        changePlayer();
                    }
                    else Program.changePlayer(); // Prochain Joueur
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show(ioe.Message.ToString());
                }

                DisableBT_addPlayer();
                TB_newName.Text = String.Empty; // Vide le TextBox
                
                string[] nums = { "premier", "deuxième", "troisième", "quatrième" };
                LB_nameCount.Text = "Nom du " + nums[Program.currentPlayer] + " joueur"; // Modification du label avec le bon # de joueur
            }
            else
            {
                LB_newName_error.Visible = true;
                ErrorBT_addPlayer();
            }
        }
        private void showPlayerScores()
        {
            for (int i = 1; i <= Program.nbPlayers; i++)
                this.PNL_scores.Controls["PNL_score_J" + i.ToString()].Visible = true;

            for (int i = 1; i <= Program.players.Count; i++)
                this.PNL_scores.Controls["PNL_score_J" + i.ToString()].Controls["LB_score_name" + i.ToString()].Text = Program.players[i - 1].name;
        }

        private bool nameIsValid(string name)
        {
            for (int i = 0; i < name.Length; i++)
                if (!(isAlpha(name[i]) || name[i] == ' ' || name[i] == '-'))
                    return false;

            return true;
        }
        private string addUpperCase(string s)
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
        private string filterName(string s)
        {
            if (s[0] == ' ' || s[0] == '-')
                s = s.Substring(1);
            if (s[s.Length - 1] == ' ' || s[s.Length - 1] == '-')
                s = s.Substring(0, s.Length - 2);

            return s;
        }

        private bool filterSpaces(char e)
        {
            if (TB_newName.TextLength > 0)
            {
                if ((e == ' ' || e == '-') && (TB_newName.Text[TB_newName.TextLength - 1] == ' ' || TB_newName.Text[TB_newName.TextLength - 1] == '-'))
                    return false;
            }
            return true;
        }
        private static bool isAlpha(char c)
        {
            String alphas = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return (alphas.IndexOf(c.ToString()) != -1);
        }

        private bool error_addPlayer = false;
        private void ErrorBT_addPlayer()
        {
            BT_addPlayer.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("addPlayer_red");
            BT_addPlayer.FlatAppearance.BorderColor = Color.FromArgb(205, 67, 67);
            error_addPlayer = true;
        }
        private void DisableBT_addPlayer()
        {
            BT_addPlayer.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("addPlayer_darkgrey");
            BT_addPlayer.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            BT_addPlayer.Enabled = false;
        }

        #endregion

        #region Animation de la roue

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

        #endregion

        #region Divers

        private List<int> GetRGBBackground(Button s, bool MouseClick)
        {
            double x = MouseClick ? 0.75 : 0.8;
            return new List<int>() { (int)(s.BackColor.R * x), (int)(s.BackColor.G * x), (int)(s.BackColor.B * x) };
        }

        private string getCategoryFromAngle(int deg)
        {
            deg %= 360;

            if (deg >= (int)Category.degrees.SCIENCE)
                return "Science";
            else if (deg >= (int)Category.degrees.ART)
                return "Divertissement";
            else if (deg >= (int)Category.degrees.SPORT)
                return "Géographie";
            else if (deg >= (int)Category.degrees.AUTRE)
                return "Histoire";
            else if (deg >= (int)Category.degrees.HISTOIRE)
                return "Autre";
            else if (deg >= (int)Category.degrees.GEOGRAPHIE)
                return "Sport";
            else if (deg >= (int)Category.degrees.DIVERTISSEMENT)
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

        private void changePlayer()
        {
            Program.changePlayer();
            LB_questions_playerName.Text = Program.players[Program.currentPlayer].name;
            LB_wheel_playerName.Text = Program.players[Program.currentPlayer].name;
            Update();
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

        #endregion
    }
}