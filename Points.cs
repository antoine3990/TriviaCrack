﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaCrack
{
    /// <summary>
    /// Contient le pointage pour une catégorie.
    /// </summary>
    static class Points
    {
        /// <summary>
        /// Réinitialise les points de la catégorie à zéro.
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <param name="playerName">Nom du joueur</param>
        public static void reset(string playerName)
        {
            // --------------------------------------------------------- UPDATE BD (point de tout les catégories = 0)
        }

        /// <summary>
        /// Incrémente de un(1) le nombre de points de la catégorie.
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <param name="playerName">Nom du joueur</param>
        public static void add(string category, string playerName)
        {
            // --------------------------------------------------------- UPDATE BD (point de la catégorie + 1)
        }

        /// <summary>
        /// Cherche le pointage du joueur selon la catégorie passée en paramètre.
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <param name="playerName">Nom du joueur</param>
        /// <returns>Le pointage de la catégorie</returns>
        public static int get(string category, string playerName)
        {
            // --------------------------------------------------------- GET BD (point de la catégorie)

            return -1;
        }
    }
}
