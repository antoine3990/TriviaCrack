using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaCrack
{
    /// <summary>
    /// Contient le pointage pour une catégorie.
    /// </summary>
    class Points
    {
        public int points { get;  private set; } // Nombre de points
        public Category category { get; private set; } // Catégorie

        /// <summary>
        /// Constructeur paramétrique d'un pointage d'une catégorie.
        /// </summary>
        /// <param name="category_">Nom de la catégorie</param>
        /// <param name="points_">Nombre de points</param>
        public Points(Category category_, int points_ = 0)
        {
            category = category_;
            points = points_;
        }

        /// <summary>
        /// Incrémente de un(1) le nombre de points de la catégorie.
        /// </summary>
        public void addPoint() { points++; }

        /// <summary>
        /// Réinitialise les points de la catégorie à zéro.
        /// </summary>
        public void resetPoint() { points = 0; }
    }
}
