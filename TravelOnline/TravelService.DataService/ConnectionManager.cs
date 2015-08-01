using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TravelService.DataService
{
    public class ConnectionManager
    {
        private static ConnectionManager manager;
        private MySqlConnection connection;
        private String sqlStr = "Database=hackthon;Data Source=127.0.0.1;User Id=root;Password=admin;pooling=false;CharSet=utf8;port=3306";

        private ConnectionManager() { }


        public static ConnectionManager getInstance()
        {
            if (manager == null)
            {
                manager = new ConnectionManager();
            }

            return manager;
        }

        public MySqlConnection getConnection()
        {

            
            connection = new MySqlConnection(sqlStr);

          //  Connection conn = new Connection(connection);

            return connection;
        }

        public static MySqlCommand getSqlCommand(String sql, MySqlConnection mysql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
            //  MySqlCommand mySqlCommand = new MySqlCommand(sql);
            // mySqlCommand.Connection = mysql;
            return mySqlCommand;
        }


        
    }
}
