using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaCrack
{
    /// <summary>
    /// Contient les informations d'une catégorie; son nom, sa couleur et une liste de question.
    /// </summary>
    class Category
    {
        public enum colors { blue, pink, green, purple, red, orange }
        private string Name; // Nom de la catégorie
        private int Color; // Couleur de la catégorie
        private List<Question> questions = new List<Question>(); // Liste de question pour cette catégorie

        // Accesseurs/Mutateurs
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
            private set
            {
                if (value < Enum.GetNames(typeof(colors)).Length)
                    Color = value;
                else
                    throw new InvalidOperationException("Couleur invalide.");
            }
        }

        // Constructeur paramétrique
        public Category(string name_, int color_)
        {
            name = name_;
            color = color_;
        }

        /// <summary>
        /// Ajoute une question à la catégorie.
        /// </summary>
        /// <param name="name_">Texte de la question à ajouter</param>
        public void addQuestion(string name_)
        {
            questions.Add(new Question(name_));

            // insert into question ------------------------------------------------------------ ADD BD
        }

        /// <summary>
        /// Ajoute une question à la catégorie.
        /// </summary>
        /// <param name="question">Question à ajouter</param>
        public void addQuestion(Question question)
        {
            questions.Add(question);

            // si la question existe
            // update question where name = question.name_ -------------------------------------- UPDATE BD
            // else
            // insert into question ------------------------------------------------------------ ADD BD
        }

        /// <summary>
        /// Supprime une question de la catégorie.
        /// </summary>
        /// <param name="name_">Texte de la question</param>
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

        /// <summary>
        /// Modifie le texte de la question.
        /// </summary>
        /// <param name="oldName_">Le texte actuel de la question</param>
        /// <param name="newName_">Le nouveau texte de la question</param>
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

        /// <summary>
        /// Modifier la catégorie de la question.
        /// </summary>
        /// <param name="name_">Le texte de la question</param>
        /// <param name="category">La nouvelle catégorie de la question</param>
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

        /// <summary>
        /// Trouve la position d'une question dans la liste de questions pour cette catégorie.
        /// </summary>
        /// <param name="name_">Texte de la question</param>
        /// <returns>La position de la question</returns>
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

       
        /// <summary>
        /// Prend une question au hasard dans la liste de questions.
        /// </summary>
        /// <returns>La question prise au hasard</returns>
        public Question getQuestion()
        {
            Random rand = new Random();

            Question question;
            do question = questions[rand.Next(0, questions.Count - 1)]; while (question.answered == true);

            return question;
        }
    }
}
