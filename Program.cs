using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TriviaCrack
{
    static class Program
    {
        /// <summary>
        /// Position des catégories (en degrées) sur la roue.
        /// </summary>
        public enum degrees : int { SCIENCE = 334, DIVERTISSEMENT = 26, GEOGRAPHIE = 77, HISTOIRE = 128, AUTRE = 180, SPORT = 231, ART = 283 };
        public static int maxTextLength = 60; // Longeur maximale des questions/réponses
        public const int nbAnswers = 4; // Nombre de questions

        public static List<string> players = new List<string>();
        public static List<string> categories = new List<string>();

        public static int nbPlayers { get; set; }
        public static int pointsToWin { get; set; }
        public static int currentPlayer { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            currentPlayer = 0;

            // TEST
            //nbPlayers = 2;
            //players.Add("Antoine");
            //players.Add("Samuel");

            int minPlayers = 2;
            int maxPlayers = 4;
            int minPoints = 2;
            int maxPoints = 5;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Game(minPlayers, maxPlayers, minPoints, maxPoints));
        }

        public static void changePlayer()
        {
            currentPlayer = currentPlayer != nbPlayers - 1? currentPlayer + 1 : 0;
        }

        private static List<string> getCategories()
        {
            List<string> categories = new List<string>();

            try
            {
                categories.Add("Science");
                categories.Add("Divertissement");
                categories.Add("Géographie");
                categories.Add("Histoire");
                categories.Add("Sport");
                categories.Add("Art");

                // Get les catégories de la BD --------------------------------------------------------------------------------- GET BD
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message.ToString());
            }

            return categories;
        }
    }
}
