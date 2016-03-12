using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;

namespace TriviaCrack
{
    /// <summary>
    /// Contient le pointage pour une catégorie.
    /// </summary>
    static class Points
    {
        /// <summary>
        /// Réinitialise les points de la catégorie à zéro.
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <param name="playerName">Nom du joueur</param>
        public static void reset(string playerName)
        {
            // Points du joueur = 0
            BD.modify(Program.conn, "POINTS_PAKG.RESET_POINT", new List<Args>() { new Args("PNUM", Program.getNumPlayer(playerName), OracleDbType.Int32) });
        }

        /// <summary>
        /// Incrémente de un(1) le nombre de points de la catégorie.
        /// </summary>
        /// <param name="category">Nom de la catégorie</param>
        /// <param name="playerName">Nom du joueur</param>
        public static void add(string category, string playerName)
        {
            List<Args> args = new List<Args>() {
                new Args("PNUM", Program.getNumPlayer(playerName), OracleDbType.Int32),
                new Args("PCATEGORIE", category, OracleDbType.Varchar2)
            };

            // Point de la catégorie du joueur +1
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
            List<Args> IN = new List<Args>() {
                new Args("PNUM", Program.getNumPlayer(playerName), OracleDbType.Int32),
                new Args("PCATEGORIE", category, OracleDbType.Varchar2)
            };
            Args OUT = new Args("POIN", null, OracleDbType.Int32, ParameterDirection.ReturnValue);

            // Points de la catégorie du joueur
            return BD.getInt(Program.conn, "POINTS_PAKG.GET_POINT", IN, OUT);
        }
    }
}
