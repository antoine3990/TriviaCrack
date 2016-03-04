using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaCrack
{
    class Answer
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
                    throw new InvalidOperationException("La réponse contient trop de caractères.");
            }
        }
        public bool correct
        {
            get { return correct; }
            private set { correct = value; }
        }

        public Answer(string name_, bool correct_ = false)
        {
            name = name_;
            correct = correct_;
        }

        public void modify(string name_, bool correct_)
        {
            name = name_;
            correct = correct_;
        }
    }
}
