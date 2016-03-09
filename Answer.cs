using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaCrack
{
    /// <summary>
    /// Contient une réponse à une question; son nom et son état(bonne/mauvaise).
    /// </summary>
    static class Answer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public static List<string> get(string question)
        {
            // -------------------------------------------------------------------- GET BD (réponses)

            return new List<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public static string getCorrect(string question)
        {
            // -------------------------------------------------------------------- GET BD (réponse correcte)

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <param name="newAnswer"></param>
        public static void modify(string question, string answer, string newAnswer)
        {
            // -------------------------------------------------------------------- UPDATE BD (modifier réponse de question)
        }

        /// <summary>
        /// Modifie l'état de la question (correcte/incorrecte).
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        public static void modify(string question, string answer)
        {
            // -------------------------------------------------------------------- UPDATE BD (modifier état réponse)
        }

        public static void removeCorrect(string question)
        {
            // -------------------------------------------------------------------- UPDATE BD (modifier l'état de la réponse qui a 'O' comme état)
        }

        public static void add(string question, string answer, char correct)
        {
            if (correct == 'O')
                removeCorrect(question);

            // -------------------------------------------------------------------- INSERT BD (ajout réponse à la question)
        }

        public static int count(string question)
        {
            // -------------------------------------------------------------------- GET BD (count du nombre de réponse de la question)

            return 0;
        }
    }
}
