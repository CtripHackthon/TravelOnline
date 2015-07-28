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
                ///�����û�д�connectstring,��ô�������ļ���Web Configuration File����ȡ
                ///ConfigurationManager����ר�Ŷ������ļ���ʹ��ǰ��������System.configuration
                ///ÿ��ConfigurationManager��ĵ�Σ���Ϊһ����
                if (_Connectstring == null) _Connectstring = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                return _Connectstring;
            }
            set
            {
                _Connectstring = value;
            }
        }
        //���ݿ�����
        private SqlConnection connection = null;
        //����
        private SqlTransaction trans = null;
        //��ʾ��Ϣ
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
        /// �����ݿ���еĲ�ѯ����
        /// </summary>
        /// <param name="sql">
        /// ����װ��SQL��ѯ���
        /// </param>
        /// <returns>
        /// ����SQL�Ĳ�ѯ��䣬��ѯ�ó���ʱ������
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
        /// �����ݿ���и��²���
        /// </summary>
        /// <param name="sql">
        /// ����װ��SQL�������
        /// </param>
        /// <returns>
        /// Ӱ������ݿ��¼������
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
        /// ��ʼһ������
        /// </summary>
        public void BeginTransAction()
        {
            trans = connection.BeginTransaction();
        }
        /// <summary>
        /// �����ύ
        /// </summary>
        public void CommitTransAction()
        {
            trans.Commit();
        }
        /// <summary>
        /// ����ع�
        /// </summary>
        public void RollbackTransAction()
        {
            trans.Rollback();
        }
        /// <summary>
        /// �����µ����ݿ�����
        /// </summary>
        /// <returns>
        /// �Ƿ����ӳɹ�
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
        /// �ر����ݿ������
        /// </summary>
        public void CloseConnection()
        {
            //�����жϣ����connectionδ�ر���ִ����һ��
            if (null != connection)
            {
                connection.Close();
            }
        }
    }
}
