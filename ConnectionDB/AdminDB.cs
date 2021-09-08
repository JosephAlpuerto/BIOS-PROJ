using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Dapper;

namespace ConnectionDB
{
public class AdminDB
    {
        public static Admin CheckLogin(Admin obj)
        {
            string sqlQuery = "SELECT Username, Password FROM Admin WHERE(Username = @Username) AND(Password = @Password)";

            using (var con = ConnectionUtil.GetConnection())
            {
                return con.Query<Admin>(sqlQuery, obj).FirstOrDefault();
            }
        }

        public static bool Insert (Admin admin)
        {
            string sql = "INSERT INTO [Admin](Username, Password, FirstName, LastName) VALUES (@Username, @Password, @FirstName, @LastName)";

            using (var con = ConnectionUtil.GetConnection())
            {
                return con.Execute(sql, admin) > 0;
            }
        }

        public static List<Admin> FetchList()
        {
            string sql = "SELECT [Id], [Username], [Password], [FirstName], [LastName] FROM [BIOSproject].[dbo].[Admin]";
            using (var con = ConnectionUtil.GetConnection())
            {
                return con.Query<Admin>(sql).ToList();
            }
        }

       






        public static bool Insert(Users user)
        {
            string sql = "INSERT INTO [Users](Username, Password, FirstName, LastName, MobileNumber) VALUES (@Username, @Password, @FirstName, @LastName, @MobileNumber)";

            using (var con = ConnectionUtil.GetConnection())
            {
                return con.Execute(sql, user) > 0;
            }
        }
        public static List<Users> FetchList1()
        {
            string sql = "SELECT [Id], [Username], [Password], [FirstName], [LastName], [MobileNumber] FROM [BIOSproject].[dbo].[Users]";
            using (var con = ConnectionUtil.GetConnection())
            {
                return con.Query<Users>(sql).ToList();
            }
        }


    }
}
