using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DATABASE
{
    public class SQLDBOperate
    {
        private string _Connectstring = null;
        public string Connectstring
        {
            get
            {
                ///如果你没有传connectstring,那么从配置文件（Web Configuration File）中取
                ///ConfigurationManager此类专门读配置文件，使用前必须引用System.configuration
                ///每个ConfigurationManager后的点段，称为一个节
                if (_Connectstring == null) _Connectstring = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                return _Connectstring;
            }
            set
            {
                _Connectstring = value;
            }
        }
        //数据库连接
        private SqlConnection connection = null;
        //事务
        private SqlTransaction trans = null;
        //提示信息
        private string m_Message;
        public string Message
        {
            get
            {
                if (m_Message == null) m_Message = "";
                return m_Message;
            }
        }
        /// <summary>
        /// 对数据库进行的查询操作
        /// </summary>
        /// <param name="sql">
        /// 已组装的SQL查询语句
        /// </param>
        /// <returns>
        /// 根据SQL的查询语句，查询得出临时表并返回
        /// </returns>
        public DataTable SelectToDataTable(string sql)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = sql;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                m_Message = ex.Message;
                return null;
            }
            finally
            {
                //do sth else
            }
        }
        /// <summary>
        /// 对数据库进行更新操作
        /// </summary>
        /// <param name="sql">
        /// 已组装的SQL更新语句
        /// </param>
        /// <returns>
        /// 影响的数据库记录的行数
        /// </returns>
        public int UpdateDataBase(string sql)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Transaction = this.trans;
            //command.Transaction = trans;
            try
            {
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                m_Message = ex.Message;
                return -1;
            }
            finally
            {//do sth else
            }
        }

        /// <summary>
        /// 开始一个事务
        /// </summary>
        public void BeginTransAction()
        {
            trans = connection.BeginTransaction();
        }
        /// <summary>
        /// 事务提交
        /// </summary>
        public void CommitTransAction()
        {
            trans.Commit();
        }
        /// <summary>
        /// 事务回滚
        /// </summary>
        public void RollbackTransAction()
        {
            trans.Rollback();
        }
        /// <summary>
        /// 建立新的数据库连接
        /// </summary>
        /// <returns>
        /// 是否连接成功
        /// </returns>
        public bool Connect()
        {
            connection = new SqlConnection(Connectstring);
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                //do sth else
            }
        }
        /// <summary>
        /// 关闭数据库的连接
        /// </summary>
        public void CloseConnection()
        {
            //加上判断，如果connection未关闭则执行下一句
            if (null != connection)
            {
                connection.Close();
            }
        }
    }
}
