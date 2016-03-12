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
        /// <summary>
        /// Insère un nouveau joueur dans la base de données.
        /// </summary>
        /// <param name="name">Nom du joueur</param>
        public static void add(string name)
        {
            //BD.insert();
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
    }
}