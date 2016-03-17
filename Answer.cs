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
        /// Recherche la liste de réponses d'une question.
        /// </summary>
        /// <param name="question">Texte de la question</param>
        /// <returns>Liste de réponses de la question</returns>
        public static List<string> get(string question)
        {
            List<Args> IN = new List<Args>() { new Args("PNUM", Question.getNum(question), OracleDbType.Int32) };
            Args OUT = new Args("REPONSES", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);

            // GET - Réponses à la question
            return BD.toList(BD.getDS(Program.conn, "REPONSE_PAKG.GET_REPONSE", IN, OUT));
        }

        /// <summary>
        /// Supprime tout les réponses de la question passée en paramètre.
        /// </summary>
        /// <param name="question">Texte de la question</param>
        public static void deleteAll(string question)
        {
            // DELETE - Tout les réponses à la question
            BD.delete(Program.conn, "REPONSE_PAKG.DELETE_REPONSE", new List<Args>() { new Args("NUMQ", Question.getNum(question), OracleDbType.Int32) });
        }

        /// <summary>
        /// Trouve la réponse valide d'une réponse.
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public static string getCorrect(string question)
        {
            List<Args> IN = new List<Args>() { new Args("PNUM", Question.getNum(question), OracleDbType.Int32) };
            Args OUT = new Args("REPONSE_R", null, OracleDbType.Varchar2, ParameterDirection.ReturnValue);

            // GET - Réponse valide de la question
            return BD.getString(Program.conn, "REPONSE_PAKG.GET_REPONSE_C", IN, OUT);
        }

        /// <summary>
        /// Modifie le texte d'une réponse.
        /// </summary>
        /// <param name="answer">Texte de la réponse</param>
        /// <param name="newAnswer">Nouveau texte de la réponse</param>
        public static void modify(string answer, string newAnswer)
        {
            List<Args> args = new List<Args>() {
                new Args("PNUMR", getNum(answer), OracleDbType.Int32),
                new Args("PENONCER", newAnswer, OracleDbType.Varchar2)
            };

            // UPDATE - Texte de la réponse
            BD.modify(Program.conn, "REPONSE_PAKG.UPDATE_REPONSE", args);
        }

        /// <summary>
        /// Modifie l'état de la réponse (correcte/incorrecte).
        /// </summary>
        /// <param name="answer">Texte de la réponse</param>
        public static void modify(string answer)
        {
            // UPDATE - État de la réponse
            BD.modify(Program.conn, "REPONSE_PAKG.UPDATE_REPONSE_C", new List<Args>() { new Args("PNUMR", getNum(answer), OracleDbType.Int32) });
        }

        /// <summary>
        /// Ajoute une réponse à la question passée en paramètre.
        /// </summary>
        /// <param name="question">Texte de la question</param>
        /// <param name="answer">Texte de la réponse</param>
        /// <param name="correct">L'état de la réponse (correcte/incorrecte)</param>
        public static void add(string question, string answer, char correct)
        {
            List<Args> args = new List<Args>() {
                new Args("PNUMQ", Question.getNum(question), OracleDbType.Int32),
                new Args("PCHECK", correct.ToString().ToLower(), OracleDbType.Char),
                new Args("PENONCER", answer, OracleDbType.Varchar2)
            };

            // INSERT - Réponse à la question
            BD.insert(Program.conn, "REPONSE_PAKG.ADD_REPONSE", args);
        }

        /// <summary>
        /// Compte le nombre de réponses à une question.
        /// </summary>
        /// <param name="question">Texte de la question</param>
        /// <returns>Nombre de réponses</returns>
        public static int count(string question)
        {
            List<Args> IN = new List<Args>() { new Args("PNUMQ", Question.getNum(question), OracleDbType.Int32) };
            Args OUT = new Args("NOMBRE_Q", null, OracleDbType.Int32, ParameterDirection.ReturnValue);

            // COUNT - Nombre de réponse à la question
            return BD.count(Program.conn, "REPONSE_PAKG.COUNT_REPONSE", IN, OUT);
        }

        /// <summary>
        /// Trouve le numéro unique dans la base de données de la réponse passée en paramètre.
        /// </summary>
        /// <param name="answer">Texte de la réponse</param>
        /// <returns>Numéro unique de la réponse</returns>
        public static string getNum(string answer)
        {
            return BD.getString(Program.conn, "REPONSE_PAKG.GET_NUM",
               new List<Args>() { new Args("PNOM", answer, OracleDbType.Varchar2) },
               new Args("PNUM", null, OracleDbType.Int32, ParameterDirection.ReturnValue));
        }
    }
}
