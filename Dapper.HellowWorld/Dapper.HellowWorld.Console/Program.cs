using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.HellowWorld.Console
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void getObjects()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString))
            {
                IDbCommand cmd = db.CreateCommand();
                cmd.CommandText = "Select * From Author";

                
            }
        }
    }
}
