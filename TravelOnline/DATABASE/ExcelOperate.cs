using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DATABASE
{
    public class ExcelOperate
    {
        //create a connectstring
        private string _connectString = null;
        public string connectString
        {
            get
            {
                //read connect string from config file
                if (_connectString == null)
                {
                    _connectString = System.Configuration.ConfigurationManager.AppSettings["conExcel"].ToString() + System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["excelPath"]) + System.Configuration.ConfigurationManager.AppSettings["extendedInfo"].ToString();
                }
                return _connectString;
            }
            set
            {
                _connectString = value;
            }
        }

        public DataTable SelectToDataTable(string sql)
        {
            //set connection
            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();
            con.ConnectionString = connectString;
            //set commandtext
            System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand();
            command.CommandText = sql;
            command.Connection = con;
            //set adapter
            System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter();
            adapter.SelectCommand = command;
            //creat a datatable
            DataTable dt = new DataTable();
            try
            {
                //open this connection
                con.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //throw new Exception
                con.Close();
            }
            finally
            {
                //close this connection
                con.Close();
            }
            //return a datatable
            return dt;
        }

        public bool Connect()
        {
            bool re = true;
            return re;
        }

        public void CloseConnection()
        {
        }
    }
}
