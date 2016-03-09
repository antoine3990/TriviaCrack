using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TriviaCrack
{
    /// <summary>
    /// Contient les informations d'une question; son texte, ses réponses et son status (répondue ou non)
    /// </summary>
    class Question
    {
        private string Name; // Texte de la question
        public bool answered { get; set; } // La question a été répondue
        public List<string> answers { get; private set; } // Liste de réponse à la question
        public string answerCorrect { get; private set; } // Bonne réponse

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
        
        /// <summary>
        /// Constructeur paramétrique d'une question.
        /// </summary>
        /// <param name="name_">Texte de la question</param>
        /// <param name="answered_">La question est répondue ou non</param>
        public Question(string name_, bool answered_)
        {
            name = name_;
            answered = answered_;
            answers = Answer.get(name);
            answerCorrect = Answer.getCorrect(name);
        }

        /// <summary>
        /// Ajoute une réponse à la question.
        /// </summary>
        /// <param name="name_">Texte de la réponse</param>
        /// <param name="correct_">État de la réponse</param>
        public void addAnswer(string name_)
        {
            if (answers.Count < Program.nbAnswers)
            {
                Answer.add(name, name_, correct_);
                answers.Add(name_);
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
                if (questions[i].name.ToLower().Trim() == name_.ToLower().Trim())
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
            if (questions.Count > 0)
            {
                Random rand = new Random();

                Question question;
                do question = questions[rand.Next(0, questions.Count - 1)]; while (question.answered == true);

                return question;
            }
            else
                throw new InvalidOperationException("La catégorie ne contient aucune questions.");
        }

        /// <summary>
        /// Prend la question qui a le même texte que celui passé en paramètre.
        /// </summary>
        /// <param name="name_">Texte de la question</param>
        /// <returns>La question recherchée</returns>
        public Question getQuestion(string name_)
        {
            if (questions.Count > 0)
                return questions[questionPos(name_)];
            else
                throw new InvalidOperationException("La catégorie ne contient aucune questions.");
        }
    }
}
