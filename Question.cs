using System;
using System.Data;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

namespace TriviaCrack
{
    /// <summary>
    /// Contient les informations d'une question; son texte, ses réponses et son status (répondue ou non)
    /// </summary>
    static class Question
    {
        /// <summary>
        /// Trouve le numéro unique dans la base de données de la question passée en paramètre.
        /// </summary>
        /// <param name="question">Texte de la question</param>
        /// <returns>Numéro unique de la question</returns>
        public static string getNum(string question)
        {
            return BD.getString(Program.conn, "QUESTION_PAKG.GET_NUM",
                  new List<Args>() { new Args("PNOM", question, OracleDbType.Varchar2) },
                  new Args("PNUM", null, OracleDbType.Int32, ParameterDirection.ReturnValue));
        }

        /// <summary>
        /// Trouve une question au hasard dans la liste de question de la catégorie passée en paramètre.
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <returns>Question au hasard</returns>
        public static string get(string category)
        {
            List<Args> IN = new List<Args>() { new Args("PCATEGORIE", category, OracleDbType.Varchar2) };
            Args OUT = new Args("enonce", null, OracleDbType.Varchar2, ParameterDirection.ReturnValue);
            
            // GET - Question au hasard
            return BD.getString(Program.conn, "QUESTION_PAKG.QUESTION_HASARD", IN, OUT); 
        }
        
        /// <summary>
        /// Trouve la catégorie de la question passée en paramètre.
        /// </summary>
        /// <param name="question">Texte de la question</param>
        /// <returns>Catégorie de la question</returns>
        public static string getCategory(string question)
        {
            List<Args> IN = new List<Args>() { new Args("PNUM", getNum(question), OracleDbType.Int32) };
            Args OUT = new Args("CATEGORIE_Q", null, OracleDbType.Varchar2, ParameterDirection.ReturnValue);

            // GET - Catégorie de la question
            return BD.getString(Program.conn, "QUESTION_PAKG.GET_CATEGORIE", IN, OUT);
        }

        /// <summary>
        /// Recherche la liste de questions selon la catégorie passée en paramètre.
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <returns>La liste de question</returns>
        public static DataSet getAll(string category)
        {
            List<Args> IN = new List<Args>() { new Args("PCATEGORIE", category, OracleDbType.Varchar2) };
            Args OUT = new Args("PALL_Q", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);

            // GET - Tout les questions de la catégorie
            return BD.getDS(Program.conn, "QUESTION_PAKG.GET_ALL", IN, OUT);
        }

        /// <summary>
        /// Modifie le texte OU/ET la catégorie de la question.
        /// </summary>
        /// <param name="question">Texte actuel de la question</param>
        /// <param name="newName">Nouveau texte de la question</param>
        /// <param name="category">Nouvelle catégorie de la question</param>
        public static void modify(string question, string newName = null, string category = null)
        {
            List<Args> args = new List<Args>() { new Args("PNUM", getNum(question), OracleDbType.Int32) };

            if (newName != null)
            {
                args.Add(new Args("PNEW_ENONCER", newName, OracleDbType.Varchar2));
                BD.modify(Program.conn, "QUESTION_PAKG.UPDATE_ENONCER", args);
                args.RemoveAt(args.Count - 1);
            }
            if (category != null)
            {
                args.Add(new Args("PNEW_CATEGORIE", category, OracleDbType.Varchar2));
                BD.modify(Program.conn, "QUESTION_PAKG.UPDATE_CATEGORIE", args);
            }
        }

        /// <summary>
        /// Ajoute une question à la catégorie.
        /// </summary>
        /// <param name="name">Texte de la question à ajouter</param>
        /// <param name="category">Catégorie de la question</param>
        public static void add(string name, string category)
        {
            List<Args> args = new List<Args>() {
                new Args("PENONCER", name, OracleDbType.Varchar2),
                new Args("PCATEGORIE", category, OracleDbType.Varchar2)
            };

            // INSERT - Question dans la catégorie
            BD.insert(Program.conn, "QUESTION_PAKG.ADD_QUESTION", args);
        }

        /// <summary>
        /// Supprime une question.
        /// </summary>
        /// <param name="question">Texte de la question</param>
        public static void delete(string question)
        {
            // DELETE - Question 
            BD.delete(Program.conn, "QUESTION_PAKG.DELETE_QUESTION", new List<Args>() { new Args("PNUM", getNum(question), OracleDbType.Int32) });
        }

        /// <summary>
        /// Modifie l'état d'une question à 'répondue'.
        /// </summary>
        /// <param name="question">Texte de la question</param>
        public static void answered(string question)
        {
            // UPDATE - La question est répondue
            BD.modify(Program.conn, "QUESTION_PAKG.REPONDUE", new List<Args>() { new Args("PNUM", getNum(question), OracleDbType.Int32) });
        }

        /// <summary>
        /// Réinitialise les questions à leurs état original (non-répondues).
        /// </summary>
        public static void reset()
        {
            BD.modify(Program.conn, "QUESTION_PAKG.RESET_QUESTION", null);
        }
    }
}
