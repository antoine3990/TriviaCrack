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
        public static string get(string category, string question = null)
        {
            //if (question == null)
            // ------------------------------------------------------------------------------------- GET BD (question au hasard dans la catégorie)
            //else
            // ------------------------------------------------------------------------------------- GET BD (question indiquée en paramètre)

            return "";
        }
        
        public static string getCategory(string question)
        {
            // ------------------------------------------------------------------------------------- GET BD (catégorie de la question)

            return "";
        }

        public static List<string> getAll(string category)
        {
            // ------------------------------------------------------------------------------------- GET BD (tout les questions de la catégorie)

            return new List<string>();
        }

        public static int count(string category)
        {
            // ------------------------------------------------------------------------------------- GET BD (count du nombre de questions de la catégorie)

            return 0;
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
                // --------------------------------------------------------------------------------- DELETE BD (supprimer question)
            }
            else
                throw new InvalidOperationException("La catégorie ne comporte aucune questions.");
        }
    }
}
