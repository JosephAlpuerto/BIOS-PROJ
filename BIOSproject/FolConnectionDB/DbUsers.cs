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
    public class DbUsers
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;

        // connection Users
        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        // fetch all Users list 

        public static List<clsUsers> FetchList3()
        {
            string sql = "SELECT [Id], [Username], [Password], [FirstName], [LastName], [MobileNumber] FROM [LBC.BIOS].[dbo].[Users]";

            using (var con = GetConnection())
            {
                return con.Query<clsUsers>(sql).ToList();
            }
        }
    }
}