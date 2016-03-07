﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaCrack
{
    /// <summary>
    /// Contient une réponse à une question; son nom et son état(bonne/mauvaise).
    /// </summary>
    class Answer
    {
        private string Name; // Texte de la réponse
        public bool correct { get; private set; } // L'état de la réponse (Bonne/mauvaise)

        // Accesseurs/Mutateurs
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

        /// <summary>
        /// Constructeur paramétrique d'une réponse.
        /// </summary>
        /// <param name="name_">Texte de la réponse</param>
        /// <param name="correct_">État de la question</param>
        public Answer(string name_, bool correct_ = false)
        {
            name = name_;
            correct = correct_;
        }

        /// <summary>
        /// Modifie le texte et l'état de la réponse.
        /// </summary>
        /// <param name="name_">Texte de la réponse à modifier</param>
        /// <param name="correct_">État, vrai si la réponse est bonne</param>
        public void modify(string name_, bool correct_)
        {
            name = name_;
            correct = correct_;
        }

        /// <summary>
        /// Modifie l'état de la réponse.
        /// </summary>
        /// <param name="correct_">État, vrai si la réponse est bonne</param>
        public void modify(bool correct_)
        {
            correct = correct_;
        }
    }
}
