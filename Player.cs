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

        /// <summary>
        /// Constructeur paramétrique d'un joueur.
        /// </summary>
        /// <param name="name_">Nom du joueur</param>
        public Player(string name_)
        {
            name = name_;

            // ---------------------------------------------------------------------------------------------- INSERT BD (Insert into joueur)
        }

        /// <summary>
        /// Ajoute un point dans la catégorie passée en paramètre.
        /// </summary>
        /// <param name="category">La catégorie du point à ajouter</param>
        public void addPoint(string category)
        {
            int pos = Program.categories.IndexOf(category);

            if (pos != -1)
                Points.add(category, name);
            else
                throw new InvalidOperationException("La catégorie entrée est invalide.");
        }

        /// <summary>
        /// Réinitialise les points du joueur à zéro.
        /// </summary>
        public void resetPoints()
        {
            for (int i = 0; i < Program.categories.Count; i++)
                Points.reset(Program.categories[i], name);
        }
    }
}