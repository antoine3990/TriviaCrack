using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;

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
            string num = Question.getNum(question);
            List<Args> IN = new List<Args>() { new Args("PNUM", num, OracleDbType.Int32) };
            Args OUT = new Args("REPONSES", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);

            // GET - Réponses à la question
            return BD.toList(BD.getDS(Program.conn, "REPONSE_PAKG.GET_REPONSE", IN, OUT));
        }

        public static void deleteAll(string question)
        {
            string num = Question.getNum(question);

            // DELETE - Tout les réponses à la question
            BD.delete(Program.conn, "REPONSE_PAKG.DELETE_REPONSE", new List<Args>() { new Args("NUMQ", num, OracleDbType.Int32) });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public static string getCorrect(string question)
        {
            string num = Question.getNum(question);
            List<Args> IN = new List<Args>() { new Args("PNUM", num, OracleDbType.Int32) };
            Args OUT = new Args("CORRECT", null, OracleDbType.Varchar2, ParameterDirection.ReturnValue);

            // GET - Réponse valide de la question
            return BD.getString(Program.conn, "REPONSE_PAKG.GET_REPONSE_C", IN, OUT);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <param name="newAnswer"></param>
        public static void modify(string question, string answer, string newAnswer)
        {
            List<Args> args = new List<Args>() { new Args()}
            // -------------------------------------------------------------------- UPDATE BD (modifier réponse de question)
            BD.modify(Program.conn, "REPONSE_PAKG.UPDATE_REPONSE", args);
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
