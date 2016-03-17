using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;

namespace TriviaCrack
{
    /// <summary>
    /// Contient le pointage pour une catégorie.
    /// </summary>
    static class Points
    {
        /// <summary>
        /// Réinitialise les points de tout les catégories du joueur.
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <param name="playerName">Nom du joueur</param>
        public static void reset(string playerName)
        {
            // UPDATE - Points du joueur = 0
            BD.modify(Program.conn, "POINTS_PAKG.RESET_POINT", new List<Args>() { new Args("PNUM", Player.getNum(playerName), OracleDbType.Int32) });
        }

        /// <summary>
        /// Incrémente de un(1) le nombre de points de la catégorie.
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <param name="playerName">Nom du joueur</param>
        public static void add(string category, string playerName)
        {
            category = (category.Substring(0, 1).ToUpper() + category.Substring(1)).Replace('é', 'e');
            List<Args> args = new List<Args>() {
                new Args("PNUM", Player.getNum(playerName), OracleDbType.Int32),
                new Args("PCATEGORIE", category, OracleDbType.Varchar2)
            };

            // UPDATE - Point de la catégorie du joueur +1
            BD.modify(Program.conn, "POINTS_PAKG.INCREMENT_POINT", args);
        }

        /// <summary>
        /// Cherche le pointage du joueur selon la catégorie passée en paramètre.
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <param name="playerName">Nom du joueur</param>
        /// <returns>Le pointage de la catégorie</returns>
        public static int get(string category, string playerName)
        {
            category = (category.Substring(0, 1).ToUpper() + category.Substring(1)).Replace('é', 'e');
            List<Args> IN = new List<Args>() {
                new Args("PNUM", Player.getNum(playerName), OracleDbType.Int32),
                new Args("PCATEGORIE", category, OracleDbType.Varchar2)
            };
            Args OUT = new Args("POIN", null, OracleDbType.Int32, ParameterDirection.ReturnValue);
            
            // GET - Points de la catégorie du joueur
            return int.Parse(BD.getString(Program.conn, "POINTS_PAKG.GET_POINT", IN, OUT));
        }

        /// <summary>
        /// Ajuste le nombre de points d'une catégorie selon le pointage passé en paramètre.
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <param name="playerName">Nom du joueur</param>
        /// <param name="points">Nouveau pointage de la catégorie</param>
        public static void set(string category, string playerName, int points)
        {
            category = (category.Substring(0, 1).ToUpper() + category.Substring(1)).Replace('é', 'e');

            List<Args> args = new List<Args>() {
                new Args("PNUM", Player.getNum(playerName), OracleDbType.Int32),
                new Args("PCATEGORIE", category, OracleDbType.Varchar2),
                new Args("NEW_POINT", points.ToString(), OracleDbType.Int32)
            };

            // UPDATE - Point de la catégorie du joueur = points
            BD.modify(Program.conn, "POINTS_PAKG.UPDATE_POINT", args);
        }
    }
}
