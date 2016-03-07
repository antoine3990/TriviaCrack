using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaCrack
{
    static class Program
    {
        public static int maxTextLength = 60;
        public static int nbAnswers = 4;
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
           // nbPlayers = 2;
           // players.Add(new Player("Antoine"));
           // players.Add(new Player("Samuel"));

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
                categories.Add(new Category("Science", 0));
                categories.Add(new Category("Divertissement", 1));
                categories.Add(new Category("Géographie", 2));
                categories.Add(new Category("Histoire", 3));
                categories.Add(new Category("Sport", 4));
                categories.Add(new Category("Art", 5));

                // Get les catégories de la BD --------------------------- GET BD
                // Get les questions pour tout les catégories
                // Get les réponses pour tout les questions
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
    }
}
