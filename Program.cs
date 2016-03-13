using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;

namespace TriviaCrack
{
    static class Program
    {
        /// <summary>
        /// Position des catégories (en degrées) sur la roue.
        /// </summary>
        public enum degrees : int { SCIENCE = 334, DIVERTISSEMENT = 26, GEOGRAPHIE = 77, HISTOIRE = 128, AUTRE = 180, SPORT = 231, ART = 283 };
        public static int maxTextLength = 200; // Longeur maximale des questions/réponses
        public static int maxPlayerLength = 40; // Longueur maximale du nom des joueurs
        public const int nbAnswers = 4; // Nombre de questions

        public static List<string> players = new List<string>();
        public static List<string> categories = new List<string>();

        public static int nbPlayers { get; set; }
        public static int pointsToWin { get; set; }
        public static int currentPlayer { get; private set; }

        public static OracleConnection conn = new OracleConnection();
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            BD.initConnect(conn, "bonnevil", "ORACLE1");
            categories = getCategories();

            currentPlayer = 0;
            
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
            currentPlayer = currentPlayer != nbPlayers - 1 ? currentPlayer + 1 : 0;
        }

        private static List<string> getCategories()
        {
            List<string> categories = new List<string>();

            try
            {
                //categories.AddRange(new string[] { "Science", "Divertissement", "Géographie", "Histoire", "Sport", "Art" });
                categories = BD.toList(BD.getDS(conn, "QUESTION_PAKG.GET_CATEGORIES", null, new Args("PALL_CATEGORIE", null, OracleDbType.RefCursor, ParameterDirection.Output)));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            return categories;
        }
    }
}
