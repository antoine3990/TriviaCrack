using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
wheel degrees (360/7):
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
        Random rand = new Random(); // Générateur de nombre aléatoire
        
        private int currentRotation = 0; // Rotation (en degrées) de la roue
        private bool wheelClicked = false; // Vrai si la roue a été cliquée
        private bool answerClicked = false; // Vrai si une réponse a été cliquée

        /// <summary>
        /// Constructeur paramétrique de la fenêtre principale de jeu.
        /// </summary>
        /// <param name="minPlayers">Nombre minimal de joueurs</param>
        /// <param name="maxPlayers">Nombre maximal de joueurs</param>
        /// <param name="minPointsToWin">Nombre minimal de points pour gagner</param>
        /// <param name="maxPointsToWin">Nombre maximal de points pour gagner</param>
        public Game(int minPlayers, int maxPlayers, int minPointsToWin, int maxPointsToWin)
        {
            InitializeComponent();

            InitMain(minPlayers, maxPlayers, minPointsToWin, maxPointsToWin);
            PNL_main.BringToFront();
        }

        /// <summary>
        /// Initialisation de la fenêtre de sélection du nombre de joueurs/points pour gagner.
        /// </summary>
        /// <param name="minPlayers">Nombre minimal de joueurs</param>
        /// <param name="maxPlayers">Nombre maximal de joueurs</param>
        /// <param name="minPointsToWin">Nombre minimal de points pour gagner</param>
        /// <param name="maxPointsToWin">Nombre maximal de points pour gagner</param>
        public void InitMain(int minPlayers, int maxPlayers, int minPointsToWin, int maxPointsToWin)
        {
            for (int i = minPlayers; i <= maxPlayers; i++) CB_nbJoueurs.Items.Add(i); // Ajout des nombres de joueurs dans le CB
            for (int i = minPointsToWin; i <= maxPointsToWin; i++) CB_nbPoints.Items.Add(i); // Ajout des nombre de trimestres dans le CB

            CB_nbJoueurs.SelectedIndex = 0; // Selectioner la valeur par defaut pour le CB
            CB_nbPoints.SelectedIndex = 2; // Selectioner la valeur par defaut pour le CB
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
            List<int> col = getRGBBackground(sender, false);
            sender.FlatAppearance.MouseOverBackColor = Color.FromArgb(col[0], col[1], col[2]);
            sender.FlatAppearance.BorderColor = Color.FromArgb(col[0], col[1], col[2]);
        }
        private void LB_existPlayer_MouseEnter(object sender, EventArgs e)
        {
            LB_existPlayer.Font = new Font(LB_existPlayer.Font.Name, LB_existPlayer.Font.SizeInPoints, FontStyle.Underline);
            LB_existPlayer.ForeColor = Color.White;
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
            if ((!error_addPlayer && (PNL_nameSelection.Visible == true && TB_newName.TextLength > 2)) || PNL_main.Visible == true || PNL_nameSelection_Exists.Visible == true)
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
        private void LB_existPlayer_MouseLeave(object sender, EventArgs e)
        {
            LB_existPlayer.Font = new Font(LB_existPlayer.Font.Name, LB_existPlayer.Font.SizeInPoints, FontStyle.Regular);
            LB_existPlayer.ForeColor = Color.FromArgb(120, 120, 120);
        }

        #endregion

        #region MouseDownUp

        private void BT_chooseCategory_MouseDown(object send, MouseEventArgs e)
        {
            Button sender = (Button)send;
            List<int> col = getRGBBackground(sender, true);
            sender.FlatAppearance.MouseDownBackColor = Color.FromArgb(col[0], col[1], col[2]);
            sender.FlatAppearance.BorderColor = Color.FromArgb(col[0], col[1], col[2]);
        }
        private void BT_chooseCategory_MouseUp(object send, MouseEventArgs e)
        {
            Button sender = (Button)send;
            BT_chooseCategory_MouseEnter(send, new EventArgs());
            sender.ForeColor = Color.White;
        }
        private void LB_existPlayer_MouseDown(object sender, MouseEventArgs e)
        {
            LB_existPlayer.ForeColor = Color.FromArgb(160, 160, 160);
        }
        private void LB_existPlayer_MouseUp(object sender, MouseEventArgs e)
        {
            LB_existPlayer.ForeColor = Color.White;
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

            try
            {
                Button correct = getCorrectAnswer(LB_question.Text);

                if (correct == null)
                    throw new InvalidOperationException("Aucune réponse correcte.");

                if (!answerClicked)
                {
                    for (int i = 1; i <= Program.nbAnswers; i++)
                        Controls["PNL_questions"].Controls["BT_answer" + i.ToString()].Cursor = Cursors.Default;

                    ShowNextTurn(correct.Name == sender.Name);

                    Question.answered(LB_question.Text);

                    if (correct.Name == sender.Name)
                        correctAnswer(sender);
                    else
                        incorrectAnswer(sender, correct);
                }

                Refresh();

                answerClicked = true;
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message.ToString());
            }
        }
        private async void ShowNextTurn(bool correct)
        {
            await Task.Delay(4000);
            PNL_questions.BackColor = BT_nextTurn.BackColor;
            BT_nextTurn.Text = correct ? "Tourner la roulette à nouveau" : "Tour du prochain joueur";
            BT_nextTurn.Visible = true;
        }

        private void BT_start_Click(object sender, EventArgs e)
        {
            PNL_main.Visible = false;

            Program.nbPlayers = int.Parse(CB_nbJoueurs.Text);
            Program.pointsToWin = int.Parse(CB_nbPoints.Text);

            string[] indexes = { "deux", "trois", "quatre" };
            LB_nameSelectionNote.Text = string.Format(LB_nameSelectionNote.Text, indexes[Program.nbPlayers - 2]);

            int nbPlayers = 0;
            try { nbPlayers = Player.get().Count; }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            if (nbPlayers < Program.nbPlayers)
            {
                PNL_nameSelection.Visible = true;
                PNL_nameSelection.BringToFront();
            }
            else
            {
                PNL_nameSelectionMethod.Visible = true;
                PNL_nameSelectionMethod.BringToFront();
            }
        }
        private void BT_showOptions_Click(object sender, EventArgs e)
        {
            Admin adminPanel = new Admin();
            adminPanel.ShowDialog();
        }
        private void BT_showScore_Click(object sender, EventArgs e)
        {
            showPlayerScores();
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
            showQuestionWindow();
            PNL_category.Visible = false;
        }
        private void BT_nextTurn_Click(object sender, EventArgs e)
        {
            BT_nextTurn.Visible = false;
            resetApp();
        }

        private void BT_newPlayer_Click(object sender, EventArgs e)
        {
            PNL_nameSelectionMethod.Visible = false;
            PNL_nameSelection.Visible = true;
            PNL_nameSelection.BringToFront();
        }
        private void LB_existPlayer_Click(object sender, EventArgs e)
        {
            PNL_nameSelectionMethod.Visible = false;
            PNL_nameSelection_Exists.Visible = true;
            PNL_nameSelection_Exists.BringToFront();

            fillCBplayers();
        }
        private void BT_selectPlayer_Click(object sender, EventArgs e)
        {
            try
            {
                Program.players.Add(CB_namePlayer.Text); // Ajoute le nom à la liste.

                if (Program.currentPlayer == Program.nbPlayers - 1) // Si le nombre de joueur choisi est atteint, stop.
                {
                    PNL_nameSelection_Exists.Visible = false; // Fermer ce menu
                    showPlayerScores();
                    changePlayer();
                }
                else Program.changePlayer(); // Prochain Joueur
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            string[] nums = { "premier", "deuxième", "troisième", "quatrième" };
            LB_nameCount_Exists.Text = "Nom du " + nums[Program.currentPlayer] + " joueur"; // Modification du label avec le bon # de joueur

            fillCBplayers();
        }

        private void BT_info_Click(object sender, EventArgs e)
        {
            LB_nameSelectionNote.Visible = !LB_nameSelectionNote.Visible;
            BT_info.Location = new Point(95, 576);

            if (LB_nameSelectionWarning.Visible)
                LB_nameSelectionWarning.Visible = false;
        }
        private void BT_warning_Click(object sender, EventArgs e)
        {
            if (!LB_nameSelectionWarning.Visible)
                BT_info.Location = new Point(395, 576);
            else
                BT_info.Location = new Point(95, 576);

            LB_nameSelectionWarning.Visible = !LB_nameSelectionWarning.Visible;

            if (LB_nameSelectionNote.Visible)
                LB_nameSelectionNote.Visible = false;
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

        /// <summary>
        /// S'exécute lorsque la roue arrête de tourner.
        /// Affiche la fenêtre où sont afficher la question et les réponses .
        /// OU La fenêtre de choix de catégories.
        /// </summary>
        private void showQuestionWindow()
        {
            PNL_wheel.Visible = false; // Cacher la fenetre de la roue
            PNL_questions.Enabled = true; // Activer le panel de la question/réponses

            PNL_questions.BringToFront();
            PNL_category.BringToFront();

            string category = LB_category.Text.ToLower().Replace('é', 'e'); // Nom de la catégorie
            category = category.Substring(0, 1).ToUpper() + category.Substring(1);

            if (category == "Autre")
                PNL_category.Visible = true; // Afficher le choix de catégories
            else
            {
                PNL_questions.Visible = true; // Afficher la question et les réponses
                
                // Modifier l'image du picturebox selon la catégorie
                PB_question.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(category.ToLower());

                try
                {
                    showAnswers(showQuestion(category)); // Afficher la question et les réponses
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                try
                {
                    LB_pointsCategory.Text = Points.get(category, Program.players[Program.currentPlayer]).ToString(); // Afficher le score du joueur
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Affiche la question dans la fenêtre du questionnaire (PNL_question).
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <returns>
        /// La question choisie au hasard selon la catégorie 
        /// OU null (si la catégorie est inexistante)
        /// </returns>
        private string showQuestion(string category)
        {
            try
            {
                string question = Question.get(category);
                LB_question.Text = question;
                return question;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Cette catégorie ne contient aucune question.");
            }

            return null;
        }

        /// <summary>
        /// Affiche les réponses à la question dans les boutons de la fenêtre du questionnaire (PNL_question).
        /// </summary>
        /// <param name="question">La question à retrouver les réponses</param>
        private void showAnswers(string question)
        {
            if (question == null)
                throw new NullReferenceException("La question est nulle. Impossible d'importer les réponses.");

            List<string> answers = Answer.get(question);
            answers.Shuffle();

            for (int i = 0; i < Program.nbAnswers && i < answers.Count; i++)
                this.PNL_questions.Controls["BT_answer" + (i + 1).ToString()].Text = answers[i];
        }

        /// <summary>
        /// Trouve le bouton qui contient la bonne réponse.
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <param name="question">Texte de la question</param>
        /// <returns></returns>
        private Button getCorrectAnswer(string question)
        {
            try
            {
                for (int i = 1; i <= Answer.count(question); i++)
                    if (this.Controls["PNL_questions"].Controls["BT_answer" + i.ToString()].Text == Answer.getCorrect(question))
                        return (Button)this.Controls["PNL_questions"].Controls["BT_answer" + i.ToString()];
            }
            catch (InvalidOperationException ioe)
            {
                throw ioe;
            }

            return null;
        }

        /// <summary>
        /// S'active lorsque l'usager clique sur le bouton de la bonne réponse.
        /// Modifie l'apparence de la fenêtre du questionnaire (PNL_question).
        /// </summary>
        /// <param name="sender">Le bouton cliqué</param>
        private void correctAnswer(Button sender)
        {
            sender.FlatAppearance.BorderColor = Color.FromArgb(67, 205, 80);
            Points.add(LB_category.Text.Replace('é', 'e'), Program.players[Program.currentPlayer]);

            LB_pointsCategory.Text = Points.get(LB_category.Text.Replace('é','e'), Program.players[Program.currentPlayer]).ToString();
            LB_pointsCategory.ForeColor = Color.FromArgb(67, 205, 80);
            Update();
        }

        /// <summary>
        /// S'active lorsque l'usager clique sur le bouton d'une mauvaise réponse.
        /// Modifie l'apparence de la fenêtre du questionnaire (PNL_question).
        /// </summary>
        /// <param name="sender">Le bouton cliqué</param>
        private void incorrectAnswer(Button sender, Button correct)
        {
            sender.FlatAppearance.BorderColor = Color.FromArgb(205, 67, 67);
            correct.FlatAppearance.BorderColor = Color.White;
            changePlayer();
        }

        #endregion
        
        #region Ajout d'un joueur

        /// <summary>
        /// Ajoute un joueur à la liste de joueurs.
        /// </summary>
        private void addPlayer()
        {
            if (TB_newName.TextLength > 2 && TB_newName.TextLength <= Program.maxPlayerLength && nameIsValid(TB_newName.Text)) // Si le nom du joueur contient au moins 2 char et est valide.
            {
                try
                {
                    string name = addUpperCase(filterName(TB_newName.Text));
                    Player.add(name);
                    Program.players.Add(name); // Ajoute le nom à la liste.

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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                TB_newName.Text = String.Empty; // Vide le TextBox
                
                string[] nums = { "premier", "deuxième", "troisième", "quatrième" };
                LB_nameCount.Text = "Nom du " + nums[Program.currentPlayer] + " joueur"; // Modification du label avec le bon # de joueur

                DisableBT_addPlayer();
            }
            else
            {
                LB_newName_error.Visible = true;
                ErrorBT_addPlayer();
            }
        }

        /// <summary>
        /// Modifie l'apparence de la fenêtre des scores (PNL_scores) selon le nombre de joueurs.
        /// </summary>
        private void showPlayerScores()
        {
            try
            {
                for (int i = 1; i <= Program.players.Count; i++)
                {
                    this.PNL_scores.Controls["PNL_score_J" + i.ToString()].Visible = true;
                    this.PNL_scores.Controls["PNL_score_J" + i.ToString()].Controls["LB_score_name" + i.ToString()].Text = Program.players[i - 1];

                    for (int j = 1; j <= Program.categories.Count; j++)
                        this.PNL_scores.Controls["PNL_score_J" + i.ToString()].Controls["LB_score_" + i.ToString() + j.ToString()].Text = Points.get(Program.categories[j - 1], Program.players[i - 1]).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        
        /// <summary>
        /// Détermine si le nom en paramètre est valide.
        /// </summary>
        /// <param name="name">Nom du joueur</param>
        /// <returns>L'état du nom</returns>
        private bool nameIsValid(string name)
        {
            for (int i = 0; i < name.Length; i++)
                if (!(isAlpha(name[i]) || name[i] == ' ' || name[i] == '-'))
                    return false;

            return true;
        }

        /// <summary>
        /// Ajoute une majuscule aux premières lettres des mots.
        /// </summary>
        /// <param name="s">Nom du joueur</param>
        /// <returns>Le nom, avec majuscules</returns>
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

        /// <summary>
        /// Retire les espaces/tirets au début/fin du nom.
        /// </summary>
        /// <param name="s">Nom du joueur</param>
        /// <returns>Le nom validé</returns>
        private string filterName(string s)
        {
            if (s[0] == ' ' || s[0] == '-')
                s = s.Substring(1);
            if (s[s.Length - 1] == ' ' || s[s.Length - 1] == '-')
                s = s.Substring(0, s.Length - 2);

            return s;
        }

        /// <summary>
        /// Filtre l'entrée du nom d'un joueur pour éviter la répétition d'espaces ou de tirets.
        /// </summary>
        /// <param name="e">Le nom du joueur</param>
        /// <returns>Le nom filtré</returns>
        private bool filterSpaces(char e)
        {
            if (TB_newName.TextLength > 0)
            {
                if ((e == ' ' || e == '-') && (TB_newName.Text[TB_newName.TextLength - 1] == ' ' || TB_newName.Text[TB_newName.TextLength - 1] == '-'))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Indique si le caractère en paramètre est une lettre.
        /// </summary>
        /// <param name="c">Le caractère à valider</param>
        /// <returns>Le caractère est une lettre ou non</returns>
        private static bool isAlpha(char c)
        {
            String alphas = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return (alphas.IndexOf(c.ToString()) != -1);
        }

        private bool error_addPlayer = false;

        /// <summary>
        /// Modifie l'apparence du bouton d'ajout de joueur (BT_addPlayer) en cas d'erreur dans le nom.
        /// </summary>
        private void ErrorBT_addPlayer()
        {
            BT_addPlayer.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("addPlayer_red");
            BT_addPlayer.FlatAppearance.BorderColor = Color.FromArgb(205, 67, 67);
            error_addPlayer = true;
        }

        /// <summary>
        /// Modifie l'apparence du bouton d'ajout de joueur (BT_addPlayer) en cas d'un nom contenant moins de 3 caractères.
        /// </summary>
        private void DisableBT_addPlayer()
        {
            BT_addPlayer.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("addPlayer_darkgrey");
            BT_addPlayer.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            BT_addPlayer.Enabled = false;
        }

        /// <summary>
        /// Rempli le combobox contenant le nom des joueurs présents dans la base de données.
        /// </summary>
        private void fillCBplayers()
        {
            List<string> names = Player.get();

            CB_namePlayer.Items.Clear();
            for (int i = 0; i < names.Count; i++)
                if (Program.players.IndexOf(names[i]) == -1)
                    CB_namePlayer.Items.Add(names[i]);
        }

        #endregion

        #region Animation de la roue

        /// <summary>
        /// BackgroundWorker. S'exécute sur un thread secondaire.
        /// Fait tourner la roue puis modifie l'apparence du texte.
        /// </summary>
        private void BW_rotateWheel_DoWork(object sender, DoWorkEventArgs e)
        {
            List<int> times = getRotatingTimes();
            List<int> degrees = getDegrees(times);

            for (int i = 0; i < times.Count; i++)
            {
                int rotation = degrees[i];
                for (int j = 0; j < times[i]; j++)
                {
                    rotate(rotation);
                    Invoke(new Action(() => this.Refresh()));
                    Invoke(new Action(() => this.Update()));
                    System.Threading.Thread.Sleep(20);
                }
            }

            flashText();
        }

        /// <summary>
        /// BackgroundWorker. S'exécute quand le backgroundWorker a complété son exécution.
        /// Affiche la fenêtre du questionnaire.
        /// </summary>
        private void BW_rotateWheel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            showQuestionWindow();
        }

        /// <summary>
        /// Fait tourner la roue d'un certain nombre de degrées (passé en paramètre)
        /// puis modifie le texte de la catégorie selon le degrée de rotation.
        /// </summary>
        /// <param name="rotation">Rotation de la roue en degrées</param>
        private void rotate(int rotation)
        {
            currentRotation += rotation;
            LB_category.Invoke(new Action(() => LB_category.Text = getCategoryFromAngle(currentRotation)));

            PB_wheel.Image = Properties.Resources.wheel;
            PB_wheel.Invoke(new Action(() => PB_wheel.Image = rotateImage(PB_wheel.Image, currentRotation)));
        }

        /// <summary>
        /// Modifie l'image(1) selon le degrée(2). C'est cette fonction qui effectue réellement la rotation de l'image.
        /// </summary>
        /// <param name="img"></param>
        /// <param name="rotationAngle"></param>
        /// <returns></returns>
        private Image rotateImage(Image img, float rotationAngle)
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

        /// <summary>
        /// S'exécute lorsque la roue arrête de tourner. Fait "flasher" le texte de la catégorie en blanc/gris.
        /// </summary>
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

        /// <summary>
        /// Obtient une liste de temps de rotation choisi au hasard. Permet à la roue de s'arrêter à différentes positions.
        /// </summary>
        /// <returns>La liste de temps chosi au hasard</returns>
        private List<int> getRotatingTimes()
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

        /// <summary>
        /// Obtient une liste de degrées de rotation selon le nombre de temps dans la liste passée en paramètre.
        /// </summary>
        /// <param name="times">Liste de temps de rotation</param>
        /// <returns>La liste de degrées de rotation</returns>
        private List<int> getDegrees(List<int> times)
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

        /// <summary>
        /// Retourne le BackColor du bouton passé en paramètre, mais plus foncé, pour donner une indication de Hover/Click.
        /// </summary>
        /// <param name="s">Le bouton survolé/cliqué</param>
        /// <param name="MouseClick">Vrai si le bouton est cliqué (!survolé)</param>
        /// <returns>La nouvelle couleur</returns>
        private List<int> getRGBBackground(Button s, bool MouseClick)
        {
            double x = MouseClick ? 0.75 : 0.8;
            return new List<int>() { (int)(s.BackColor.R * x), (int)(s.BackColor.G * x), (int)(s.BackColor.B * x) };
        }

        /// <summary>
        /// Trouve le nom de la catégorie selon l'angle de rotation de la roue.
        /// </summary>
        /// <param name="deg">L'angle de rotation</param>
        /// <returns>Le nom de la catégorie</returns>
        private string getCategoryFromAngle(int deg)
        {
            deg %= 360;

            if (deg >= (int)Program.degrees.SCIENCE)
                return "Science";
            else if (deg >= (int)Program.degrees.ART)
                return "Divertissement";
            else if (deg >= (int)Program.degrees.SPORT)
                return "Géographie";
            else if (deg >= (int)Program.degrees.AUTRE)
                return "Histoire";
            else if (deg >= (int)Program.degrees.HISTOIRE)
                return "Autre";
            else if (deg >= (int)Program.degrees.GEOGRAPHIE)
                return "Sport";
            else if (deg >= (int)Program.degrees.DIVERTISSEMENT)
                return "Art";
            else
                return "Science";
        }

        /// <summary>
        /// Change de joueur. S'exécute lorsqu'un joueur sélectionne une mauvaise réponse.
        /// </summary>
        private void changePlayer()
        {
            Program.changePlayer();
            LB_questions_playerName.Text = Program.players[Program.currentPlayer];
            LB_wheel_playerName.Text = Program.players[Program.currentPlayer];

            try
            {
                if (Player.isAdmin(Program.players[Program.currentPlayer]))
                    BT_showOptions.Visible = true;
                else
                    BT_showOptions.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            Update();
        }

        /// <summary>
        /// Réinitialise la fenêtre de jeu à son état d'origine. S'exécute quand un joueur clique une réponse.
        /// </summary>
        private void resetApp()
        {
            PNL_questions.BackColor = PNL_scores.BackColor;
            LB_pointsCategory.ForeColor = Color.White;
            PNL_questions.Enabled = false;
            PNL_wheel.BringToFront();
            PNL_wheel.Visible = true;
            PB_wheel.Cursor = Cursors.Hand;
            wheelClicked = false;
            answerClicked = false;
            currentRotation = 0;
            PB_wheel.Image = Properties.Resources.wheel;
            LB_category.ForeColor = Color.FromArgb(90, 90, 90);

            for (int i = 1; i <= Program.nbAnswers; i++)
            {
                Controls["PNL_questions"].Controls["BT_answer" + i.ToString()].MouseClick += BT_answer_Click;
                Controls["PNL_questions"].Controls["BT_answer" + i.ToString()].MouseEnter += BT_answer_MouseEnter;
                Controls["PNL_questions"].Controls["BT_answer" + i.ToString()].MouseLeave += BT_answer_MouseLeave;

                Button BT = (Button)Controls["PNL_questions"].Controls["BT_answer" + i.ToString()];
                BT.Cursor = Cursors.Hand;
                BT.FlatAppearance.BorderColor = Color.FromArgb(120, 120, 120);
            }
        }


        #endregion

        private void BT_admin_Click(object sender, EventArgs e)
        {

        }
    }
}