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
    class Player
    {
        private string Name; // Nom du joueur
        public List<Points> points { get; private set; } // Liste de pointage des catégories

        // Accesseurs/Mutateurs
        public string name {
            get { return Name; }
            private set
            {
                if (value.Length <= Program.maxTextLength)
                    Name = value;
                else
                    throw new InvalidOperationException("Le nom du joueur contient trop de caractères.");
            }
        }

        // Constructeur paramétrique
        public Player(string name_)
        {
            name = name_;

            points = new List<Points>();
            for (int i = 0; i < Program.categories.Count; i++)
                points.Add(new Points(Program.categories[i]));

            // insert into joueur ---------------------------------------------------- INSERT BD
        }

        /// <summary>
        /// Ajoute un point dans la catégorie passée en paramètre.
        /// </summary>
        /// <param name="category_">La catégorie du point à ajouter</param>
        public void addPoint(Category category_)
        {
            int pos = categoryPos(category_.name);

            if (pos != -1)
            {
                points[pos].addPoint();
                // update points du joueur ------------------------------------------- UPDATE BD
            }
            else
                throw new InvalidOperationException("La catégorie entrée est invalide.");
        }

        /// <summary>
        /// Trouve la position d'une catégorie, selon son nom, dans la liste de catégories.
        /// </summary>
        /// <param name="name_">Nom de la catégorie</param>
        /// <returns>Position (index) de la catégorie</returns>
        private int categoryPos(string name_)
        {
            int exists = -1;

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].category.name == name_)
                {
                    exists = i;
                    break;
                }
            }

            return exists;
        }
    }
}