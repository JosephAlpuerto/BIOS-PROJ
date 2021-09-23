﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB
{
    class ConnectionUtil
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["LBC_BIOS"].ConnectionString;

        public  static SqlConnection GetConnection() 
        {
            var con = new SqlConnection(ConnectionString);
            con.Open();
            return con;
        }
    }
}
