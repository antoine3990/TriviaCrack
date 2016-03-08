using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess;

namespace TriviaCrack
{
    static class Program
    {
        public static int maxTextLength = 60; // Longeur maximale des questions/réponses
        public const int nbAnswers = 4; // Nombre de questions

        public static List<Player> players = new List<Player>();
        public static List<Category> categories = new List<Category>();

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
            categories = getCategories();

            // TEST
            //nbPlayers = 2;
            //players.Add(new Player("Antoine"));
            //players.Add(new Player("Samuel"));

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

        private static List<Category> getCategories()
        {
            List<Category> categories = new List<Category>();

            try
            {
                categories.Add(new Category("Science", (int)Category.colors.blue));
                categories.Add(new Category("Divertissement", (int)Category.colors.pink));
                categories.Add(new Category("Géographie", (int)Category.colors.green));
                categories.Add(new Category("Histoire", (int)Category.colors.purple));
                categories.Add(new Category("Sport", (int)Category.colors.red));
                categories.Add(new Category("Art", (int)Category.colors.orange));

                // Get les catégories de la BD --------------------------- GET BD
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message.ToString());
            }

            return categories;
        }

        public static Category getCategory(string name_)
        {
            foreach (Category c in categories)
                if (c.name == name_)
                    return c;

            return null;
        }

        public static List<string> getPlayers()
        {
            List<string> names = new List<string>();

            // Get la liste de tout les joueurs dans la bd ---------------------- GET BD

            return names;
        }

        public static int getPosPlayer(string name_)
        {
            for (int i = 0; i < players.Count; i++)
                if (players[i].name == name_)
                    return i;

            return -1;
        }
    }
}
