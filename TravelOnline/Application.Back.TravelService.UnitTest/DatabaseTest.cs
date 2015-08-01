using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Data;


namespace Application.Back.TravelService.UnitTest
{
    [TestClass]
    public class DatabaseTest
    {
        private MySqlConnection mysqlConnection;
        public void initConn()
        {
            string ip = "localhost";
            string username = "root";
            string password = "admin";
            string database = "hackthon";

            string connectionString = "datasource=" + ip + ";username=" + username + ";password=" + password + ";database=" + database + ";charset=gb2312";
            mysqlConnection = new MySqlConnection(connectionString);

            

        }

        [TestMethod]
        public void TestDataBase()
        {
            initConn();

            MySqlCommand cmd = mysqlConnection.CreateCommand();
            cmd.CommandText = "Select * from user";
            MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            mysqlConnection.Close();
            mysqlDataAdapter.Fill(ds);
            System.Console.WriteLine();
        }

    }
}
