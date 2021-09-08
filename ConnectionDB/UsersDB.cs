using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Dapper;

namespace ConnectionDB
{
    public class UsersDB
    {
        public static bool Insert(Users user)
        {
            string sql = "INSERT INTO [Users](Username, Password, FirstName, LastName, MobileNumber) VALUES (@Username, @Password, @FirstName, @LastName, @MobileNumber)";

            using (var con = ConnectionUtil.GetConnection())
            {
                return con.Execute(sql, user) > 0;
            }
        }
    }
}
