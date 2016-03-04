using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaCrack
{
    class Category
    {
        public enum colors { blue, pink, green, purple, red, orange }

        public string Name;
        public int Color;

        public string name
        {
            get { return Name; }
            private set
            {
                if (value.Length <= Program.maxTextLength)
                    Name = value;
                else
                    throw new InvalidOperationException("Le nom de la catégorie contient trop de caractères.");
            }
        }

        public int color
        {
            get { return Color; }
            set
            {
                if (value < Enum.GetNames(typeof(colors)).Length)
                    Color = value;
                else
                    throw new InvalidOperationException("Couleur invalide.");
            }
        }

        private List<Question> questions = new List<Question>();

        public Category(string name_, int color_)
        {
            name = name_;
            color = color_;
        }

        public void addQuestion(string name_)
        {
            questions.Add(new Question(name_));
            // insert into question ------------------------------------------------------------ ADD BD
        }
        public void addQuestion(Question question)
        {
            questions.Add(question);
            // si la question existe
            // update question where name = question.name_ -------------------------------------- UPDATE BD
            // else
            // insert into question ------------------------------------------------------------ ADD BD
        }

        public void deleteQuestion(string name_)
        {
            if (questions.Count > 0)
            {
                int pos = questionPos(name_);

                if (pos != -1)
                {
                    // delete question where name = name_ -------------------------------------- DELETE BD
                    questions.RemoveAt(pos);
                }
                else
                    throw new InvalidOperationException("La question à supprimer est introuvable.");
            }
            else
                throw new InvalidOperationException("La catégorie ne comporte aucune questions.");
        }

        public void modifyQuestion(string oldName_, string newName_)
        {
            if (questions.Count > 0)
            {
                int pos = questionPos(oldName_);

                if (pos != -1)
                {
                    questions[pos].modify(oldName_, newName_);
                    // update question where name = oldName_ -------------------------------------- UPDATE BD
                }
                else
                    throw new InvalidOperationException("La question à modifier est introuvable.");
            }
            else
                throw new InvalidOperationException("La catégorie ne comporte aucune questions.");
        }

        public void modifyQuestion(string name_, Category category)
        {
            if (questions.Count > 0)
            {
                int pos = questionPos(name_);

                if (pos != -1)
                {
                    // Game.categories[x].addQuestion(questions[pos]);
                    questions.RemoveAt(pos);
                }
                else
                    throw new InvalidOperationException("La question à modifier est introuvable.");
            }
            else
                throw new InvalidOperationException("La catégorie ne comporte aucune questions.");
        }

        private int questionPos(string name_)
        {
            int exists = -1;

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].name == name_)
                {
                    exists = i;
                    break;
                }
            }

            return exists;
        }
    }
}
