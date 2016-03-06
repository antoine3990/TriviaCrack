using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TriviaCrack
{
    class Question
    {
        private string Name; // Texte de la question
        private List<Answer> answers = new List<Answer>(); // Liste de réponse à la question

        // Accesseurs/Mutateurs
        public string name
        {
            get { return Name; }
            private set
            {
                if (value.Length <= Program.maxTextLength)
                    Name = value;
                else
                    throw new InvalidOperationException("La question contient trop de caractères.");
            }
        }
        
        // Constructeur paramétrique
        public Question(string name_) { name = name_; }

        /// <summary>
        /// Ajoute une réponse à la question.
        /// </summary>
        /// <param name="name_">Texte de la réponse</param>
        /// <param name="correct_">État de la réponse</param>
        public void addAnswer(string name_, bool correct_ = false)
        {
            if (answers.Count < Program.nbAnswers)
            {
                answers.Add(new Answer(name_, correct_));
                // insert into answer ------------------------------------------------------- ADD BD
            }
            else
                throw new InvalidOperationException("Nombre maximal de réponses atteint. Impossible d'en ajouter une nouvelle.");
        }

        /// <summary>
        /// Supprime une réponse à la question.
        /// </summary>
        /// <param name="name_">Texte de la réponse</param>
        public void deleteAnswer(string name_)
        {
            if (answers.Count > 0)
            {
                int pos = answerPos(name_);

                if (pos != -1)
                {
                    // delete answer where name = name_ -------------------------------------- DELETE BD
                    answers.RemoveAt(pos);
                }
                else
                    throw new InvalidOperationException("La réponse à supprimer est introuvable.");
            }
            else
                throw new InvalidOperationException("La question ne comporte aucune réponse.");
        }

        /// <summary>
        /// Modifie une réponse à la question.
        /// </summary>
        /// <param name="name_">Texte actuel de la réponse</param>
        /// <param name="newName_">Nouveau texte de la réponse</param>
        /// <param name="correct_">État de la réponse</param>
        public void modifyAnswer(string name_, string newName_, bool correct_)
        {
            if (answers.Count > 0)
            {
                int pos = answerPos(name_);

                if (pos != -1)
                {
                    answers[pos].modify(newName_, correct_);
                    // update answer where name = oldName_ -------------------------------------- UPDATE BD

                    if (correct_)
                    {
                        for (int i = 0; i < answers.Count; i++)
                        {
                            if (i != pos)
                                answers[i].modify(false);
                            else
                                answers[i].modify(true);
                        }

                        // rendre tout les autres réponses à cette question incorrectes ------------ UPDATE BD
                    }
                }
                else
                    throw new InvalidOperationException("La réponse à modifier est introuvable.");
            }
            else
                throw new InvalidOperationException("La question ne comporte aucune réponse.");
        }

        /// <summary>
        /// Trouve la position d'une réponse, selon son nom, dans la liste de question.
        /// </summary>
        /// <param name="name_">Texte de la réponse</param>
        /// <returns>La position de la réponse</returns>
        private int answerPos(string name_)
        {
            int exists = -1;

            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i].name == name_)
                {
                    exists = i;
                    break;
                }
            }

            return exists;
        }
        
        /// <summary>
        /// Modifie le texte la question.
        /// </summary>
        /// <param name="oldName_">Texte actuel de la question</param>
        /// <param name="newName_">Nouveau texte de la question</param>
        public void modify(string oldName_, string newName_)
        {
            name = newName_;
        }
    }
}
