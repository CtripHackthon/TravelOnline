using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TravelService.DataService
{
    public class Connection
    {
        private MySqlConnection connection;

        public Connection(MySqlConnection conn)
        {
            connection = conn;
        }

        public void Open()
        {
            connection.Open();
        }

        public void Close()
        {
            connection.Close();
        }



    }
}
