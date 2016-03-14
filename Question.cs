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
        public static string getNum(string question)
        {
            return BD.getInt(Program.conn, "QUESTION_PAKG.GET_NUM",
                  new List<Args>() { new Args("PNOM", question, OracleDbType.Varchar2) },
                  new Args("PNUM", null, OracleDbType.Int32, ParameterDirection.ReturnValue)).ToString();
        }

        public static string get(string category)
        {
            List<Args> IN = new List<Args>() { new Args("PCATEGORIE", category, OracleDbType.Varchar2) };
            Args OUT = new Args("enonce", null, OracleDbType.Varchar2, ParameterDirection.ReturnValue);
            
            // GET - Question au hasard
            return BD.getString(Program.conn, "QUESTION_PAKG.QUESTION_HASARD", IN, OUT); 
        }
        
        public static string getCategory(string question)
        {
            List<Args> IN = new List<Args>() { new Args("PNUM", getNum(question), OracleDbType.Int32) };
            Args OUT = new Args("CATEGORIE_Q", null, OracleDbType.Varchar2, ParameterDirection.ReturnValue);

            // GET - Catégorie de la question
            return BD.getString(Program.conn, "QUESTION_PAKG.GET_CATEGORIE", IN, OUT);
        }
        // -------------------------------------------------------------------------------------------------------------------------- TO DO (DOWN)
        public static List<string> getAll(string category)
        {
            List<Args> IN = new List<Args>() { new Args("", category, OracleDbType.Varchar2) };
            Args OUT = new Args("", null, OracleDbType.RefCursor, ParameterDirection.ReturnValue);

            // GET - Tout les questions de la catégorie
            return BD.toList(BD.getDS(Program.conn, "QUESTION_PAKG.GET_ALL", IN, OUT));
        }

        public static int count(string category)
        {
            List<Args> IN = new List<Args>() { new Args("PCATEGORIE", category, OracleDbType.Varchar2) };
            Args OUT = new Args("COUNT_C", null, OracleDbType.Int32, ParameterDirection.ReturnValue);
            
            // GET - Compte du nombre de question de la catégorie
            return BD.count(Program.conn, "QUESTION_PAKG.COUNT_CATEGORIE", IN, OUT);
        }

        /// <summary>
        /// Modifie le texte OU/ET la catégorie de la question.
        /// </summary>
        /// <param name="question">Texte actuel de la question</param>
        /// <param name="newName">Nouveau texte de la question</param>
        /// <param name="category">Nouvelle catégorie de la question</param>
        public static void modify(string question, string newName = null, string category = null)
        {
            // if (newName != null) ---------------------------------------------------------------- UPDATE BD (modifier le texte de la question)
            // if (category != null) --------------------------------------------------------------- UPDATE BD (modifier la catégorie de la question)
        }

        /// <summary>
        /// Ajoute une question à la catégorie.
        /// </summary>
        /// <param name="name">Texte de la question à ajouter</param>
        /// <param name="category">Catégorie de la question</param>
        public static void add(string name, string category)
        {
            // insert into question ------------------------------------------------------------ ADD BD (ajout question à la catégorie)
        }

        /// <summary>
        /// Supprime une question.
        /// </summary>
        /// <param name="question">Texte de la question</param>
        public static void delete(string question)
        {
            if (count(getCategory(question)) > 0)
            {
                // DELETE - Question 
                BD.delete(Program.conn, "QUESTION_PAKG.DELETE", new List<Args>() { new Args("PNUM", getNum(question), OracleDbType.Int32) });
            }
            else
                throw new InvalidOperationException("La catégorie ne comporte aucune questions.");
        }
    }
}
