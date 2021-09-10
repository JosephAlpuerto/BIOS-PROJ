using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BIOSproject.Domain;

namespace BIOSproject.ConnectionDB
{
    public class DBAdmin
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Connection Details
        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        // Fetch All Admin list with using Dapper ORM

        public static List<clsAdmin> FetchList()
        {
            string sql = "";

            using (var con = GetConnection())
            {
                return con.Query<clsAdmin>(sql).ToList();
            }
        }
    }
}