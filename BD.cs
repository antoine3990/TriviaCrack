using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;


namespace TriviaCrack
{
    /// <summary>
    /// Regroupement d'opérations effectués sur une base de données.
    /// </summary>
    static class BD
    {
        /// <summary>
        /// Exécute une commande d'insertion dans la base de données.
        /// </summary>
        /// <param name="conn">Connection à la base de données</param>
        /// <param name="package">Nom du package et de la méthode</param>
        /// <param name="args">Liste d'arguments en IN à passer à la base de données</param>
        public static void insert(OracleConnection conn, string package, List<Args> args) 
        {
            conn.Open(); // Ouvrir la connection

            // Définition de l'insertion SQL
            OracleCommand cmd = new OracleCommand(package.Substring(0, package.IndexOf('.')), conn);
            cmd.CommandText = package;
            cmd.CommandType = CommandType.StoredProcedure;

            // Arguments en IN
            foreach (Args arg in args)
            {
                OracleParameter param = new OracleParameter(arg.name, arg.type);
                param.Direction = ParameterDirection.Input;
                param.Value = arg.value;
                cmd.Parameters.Add(param);
            }

            cmd.ExecuteNonQuery(); // Exécuter la query
            conn.Close(); // Fermer la connection
        }

        /// <summary>
        /// Exécute une commande de modification dans la base de données.
        /// </summary>
        /// <param name="conn">Connection à la base de données</param>
        /// <param name="package">Nom du package et de la méthode</param>
        /// <param name="args">Liste d'arguments en IN à passer à la base de données</param>
        public static void modify(OracleConnection conn, string package, List<Args> args)
        {
            insert(conn, package, args);
        }


        /// <summary>
        /// Recherche plusieurs objets dans la base de données.
        /// </summary>
        /// <param name="conn">Connection à la base de données</param>
        /// <param name="package">Nom du package et de la méthode</param>
        /// <param name="IN">Liste d'arguments en IN à passer à la base de données</param>
        /// <param name="OUT">Argument de retour de la base de données</param>
        /// <returns>Le dataset contenant les informations</returns>
        public static DataSet getDS(OracleConnection conn, string package, List<Args> IN, Args OUT)
        {
            DataSet ds = new DataSet();
            OracleCommand cmd = getCMD(conn, package, IN, OUT);
            OracleDataAdapter adapt = new OracleDataAdapter(cmd);
            adapt.Fill(ds, "0");
            adapt.Dispose();

            return ds;
        }

        /// <summary>
        /// Recherche un objet dans la base de données.
        /// </summary>
        /// <param name="conn">Connection à la base de données</param>
        /// <param name="package">Nom du package et de la méthode</param>
        /// <param name="IN">Liste d'arguments en IN à passer à la base de données</param>
        /// <param name="OUT">Argument de retour de la base de données</param>
        /// <returns>Le string contenant l'information recherchée.</returns>
        public static string getString(OracleConnection conn, string package, List<Args> IN, Args OUT)
        {
            OracleCommand cmd = getCMD(conn, package, IN, OUT);
            return cmd.Parameters[OUT.name].Value.ToString();
        }

        private static OracleCommand getCMD(OracleConnection conn, string package, List<Args> IN, Args OUT)
        {
            OracleCommand cmd = new OracleCommand(package.Substring(0, package.IndexOf('.')), conn);
            cmd.CommandText = package;
            cmd.CommandType = CommandType.StoredProcedure;

            // Argument en OUT
            OracleParameter returns = new OracleParameter(OUT.name, OUT.type);
            returns.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returns);

            // Arguments en IN
            foreach (Args arg in IN)
            {
                OracleParameter param = new OracleParameter(arg.name, arg.type);
                param.Direction = ParameterDirection.Input;
                param.Value = arg.value;
                cmd.Parameters.Add(param);
            }

            return cmd;
        }

        /// <summary>
        /// Exécute une commande pour compter des éléments dans la base de données.
        /// </summary>
        /// <param name="conn">Connection à la base de données</param>
        /// <param name="package">Nom du package et de la méthode</param>
        /// <param name="IN">Liste d'arguments en IN à passer à la base de données</param>
        /// <param name="OUT">Argument de retour de la base de données</param>
        /// <returns>Le résultat du compte effectué</returns>
        public static int count(OracleConnection conn, string package, List<Args> IN, Args OUT)
        {
            OracleCommand cmd = getCMD(conn, package, IN, OUT);

            cmd.ExecuteScalar();
            return (int)cmd.Parameters[OUT.name].Value;
        }
    }

    /// <summary>
    /// Contient les informations d'un paramètre passé à une base de données.
    /// </summary>
    public class Args
    {
        public string name { get; private set; }
        public string value { get; private set; }
        public OracleDbType type { get; private set; }

        /// <summary>
        /// Constructeur paramétrique d'un argument passé en paramètre à une base de données.
        /// </summary>
        /// <param name="name_">Nom du paramètre</param>
        /// <param name="value_">Valeur du paramètre</param>
        /// <param name="type_">Type du paramètre</param>
        public Args(string name_, string value_, OracleDbType type_)
        {
            name = name_;
            value = value_;
            type = type_;
        }
    }
}
