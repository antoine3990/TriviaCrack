using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaCrack
{
    class Player
    {
        private string Name;
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
        public List<Points> points { get; private set; }

        public Player(string name_)
        {
            name = name_;

            points = new List<Points>();
            for (int i = 0; i < Program.categories.Count; i++)
                points.Add(new Points(Program.categories[i])); // MODIFIER CETTE LIGNE (new Category())
            // insert into joueur ---------------------------------------------------- INSERT BD
        }

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
