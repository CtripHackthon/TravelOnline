using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using TravelService.DataService;

namespace Application.Back.TravelService.UnitTest
{
    [TestClass]
    public class MySqlConnectionUnitTest
    {
        [TestMethod]
        public void ConnectionUnitTest()
        {
            MySqlConnection conn = ConnectionManager.getInstance().getConnection();
            string str = "insert into user values (5, 'adf', '2dl',0,0.0,'xx','212')";
            conn.Open();
            MySqlCommand command = new MySqlCommand();
            command.CommandText = str;
            command.Connection = conn;

            command.ExecuteNonQuery();

            conn.Close();

        }
    }
}
