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
        private string Name;

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

        private List<Answer> answers = new List<Answer>();

        public Question(string name_)
        {
            name = name_;
        }

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

        public void modifyAnswer(string oldName_, string newName_, bool correct_)
        {
            if (answers.Count > 0)
            {
                int pos = answerPos(oldName_);

                if (pos != -1)
                {
                    answers[pos].modify(newName_, correct_);
                    // update answer where name = oldName_ -------------------------------------- UPDATE BD
                    if (correct_)
                    {
                        // rendre tout les autres réponses à cette question incorrectes ------------ UPDATE BD
                    }
                }
                else
                    throw new InvalidOperationException("La réponse à modifier est introuvable.");
            }
            else
                throw new InvalidOperationException("La question ne comporte aucune réponse.");
        }

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
        
        public void modify(string oldName_, string newName_)
        {
            name = newName_;
        }
    }
}
