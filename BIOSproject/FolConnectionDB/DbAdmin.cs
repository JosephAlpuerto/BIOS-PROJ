using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using BIOSproject.FolDomain;

namespace BIOSproject.FolConnectionDB
{
    public class DbAdmin
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;

        // connection Admin
        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        // fetch all admin list 

        public static List<clsAdmin> FetchList2()
        {
            string sql = "SELECT [Id], [Username], [Password], [FirstName], [LastName] FROM [LBC.BIOS].[dbo].[Admin]";

            using (var con = GetConnection())
            {
                return con.Query<clsAdmin>(sql).ToList();
            }
        }
    }

}