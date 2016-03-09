using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaCrack
{
    /// <summary>
    /// Contient les informations d'un joueur; son nom et ses points.
    /// </summary>
    static class Player
    {
        public static void add(string name)
        {
            // -------------------------------------------------------------------------- INSERT BD (nom du joueur)
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public static void remove(string name)
        {
            // -------------------------------------------------------------------------- DELETE BD (nom du joueur)
        }

        public static List<string> get()
        {
            // -------------------------------------------------------------------------- GET BD (joueurs)

            return new List<string>();
        }

        /// <summary>
        /// Réinitialise les points du joueur à zéro.
        /// </summary>
        /// <param name="name"></param>
        public static void resetPoints(string name)
        {
            for (int i = 0; i < Program.categories.Count; i++)
                Points.reset(Program.categories[i], name);
        }
    }
}