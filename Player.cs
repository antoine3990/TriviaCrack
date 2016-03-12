using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;

namespace TriviaCrack
{
    /// <summary>
    /// Contient les informations d'un joueur; son nom et ses points.
    /// </summary>
    static class Player
    {
        /// <summary>
        /// Insère un nouveau joueur dans la base de données.
        /// </summary>
        /// <param name="name">Nom du joueur</param>
        public static void add(string name)
        {
            // INSERT - joueur "name"
            BD.insert(Program.conn, "JOUEUR_PAKG.INSERT_JOUEUR", new List<Args>() { new Args("PNOM", name, OracleDbType.Varchar2) });
        }

        /// <summary>
        /// Supprime un joueur de la base de données.
        /// </summary>
        /// <param name="name">Nom du joueur</param>
        public static void remove(string name)
        {
            string num = Program.getNumPlayer(name);

            // DELETE - joueur "name"
            BD.delete(Program.conn, "JOUEUR_PAKG.DELETE_JOUEUR", new List<Args>() { new Args("PNUM", num, OracleDbType.Int32) });
        }

        /// <summary>
        /// Recherche la liste de tout les joueurs présent dans la base de données.
        /// </summary>
        /// <returns>Liste de joueurs existants</returns>
        public static List<string> get()
        {
            // GET - tout les joueurs
            return BD.toList(BD.getDS(Program.conn, "JOUEUR_PAKG.GET_ALL", null, new Args("pALL_JOUEUR", null, OracleDbType.Int32, ParameterDirection.Output)));
        }
    }
}