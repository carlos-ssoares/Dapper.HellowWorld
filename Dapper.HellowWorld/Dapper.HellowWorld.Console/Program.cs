using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.HellowWorld.Console.Model;
using Dapper.HellowWorld.Console.Model.Utils;

namespace DapperHellowWorld.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlMapper.AddTypeHandler(new IdTypeHandler());
            Dapper.SqlMapper.SetTypeMap(typeof(Inscription), new ColumnAttributeTypeMapper<Inscription>());
            Dapper.SqlMapper.SetTypeMap(typeof(Livraison), new ColumnAttributeTypeMapper<Livraison>());
            
            GetInscriptions();
            GetInscriptionsAndLivraison();

            System.Console.ReadKey();
        }

        static void GetInscriptions()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperDBMapper"].ConnectionString))
            {
                db.Open();

                IDbCommand cmd = db.CreateCommand();

                var resultado = db.Query<Inscription>("Select NO_FICH, DESCR_FICH from XP_FICH;");

                System.Console.WriteLine("{0} - {1} ", "Cod", "description");
                foreach (var cliente in resultado)
                {
                    System.Console.WriteLine("{0} - {1} ", cliente.Id.ID, cliente.Descr);
                }
                db.Close();
            }
        }

        static void GetInscriptionsAndLivraison()
        {
            //const string sql = "SELECT * FROM XP_FICH INNER JOIN XP_LIVR ON XP_FICH.NO_LIVR = XP_LIVR.NO_LIVR;";
            const string sql = @"SELECT XP_FICH.NO_FICH,
                                        XP_FICH.DESCR_FICH,
	                                    XP_LIVR.NO_LIVR,
                                        XP_LIVR.DESCR_LIVR,
                                        XP_LIVR.DAT_LIVR
                                   FROM XP_FICH
                                  INNER JOIN XP_LIVR ON XP_FICH.NO_LIVR = XP_LIVR.NO_LIVR";

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperDBMapper"].ConnectionString))
            {
                db.Open();

                IDbCommand cmd = db.CreateCommand();

                var resultado = db.Query<Inscription, Livraison, Inscription>(
                    sql,
                    (inscription, lirvaison) => {
                        return new Inscription(
                            inscription.Id,
                            inscription.Descr,
                            lirvaison);

                    },
                    splitOn: "NO_LIVR");

                System.Console.WriteLine("{0} - {1} / {2} - {3} - {4} ", "Cod", "description", "Livr", "desc", "date");
                foreach (var inscr in resultado)
                {
                    System.Console.WriteLine("{0} - {1} / {2} - {3} - {4} ", inscr.Id.ID, inscr.Descr, inscr.Livraison.Id.ID, inscr.Livraison.Descr, inscr.Livraison.Date);
                }
                db.Close();
            }
        }

    }
    
}
