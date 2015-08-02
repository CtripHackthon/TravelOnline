using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using MySql.Data.MySqlClient;
using TravelService.DataService;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Travel
{
    public class ReserveProduct : IService
    {


        public void process(ServiceRequest request, ServiceResponse response)
        {

            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            ReserveProductRequest serviceRequest = (ReserveProductRequest)request.requestObj; 
            if (serviceRequest.userId < 0 || serviceRequest.diaryId < 0)
            {
                response.errMessage = ReportServiceMessage.USER_ID_OR_DIARY_ID_INVALID;
                response.returnCode = -1;
                return;
            }

            string sqlStr = String.Format("select * from diary_point_table where diaryId={0} and date='{1}'", serviceRequest.diaryId, DateTime.Now.Date);
            MySqlConnection conn = ConnectionManager.getInstance().getConnection();

            conn.Open();

            MySqlDataAdapter mda = new MySqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            
            mda.Fill(ds, "table1");
            if (ds.Tables["table1"].Rows.Count == 0)
            {
                sqlStr = String.Format("insert into diary_point_table values ({0}, {1}, '{2}')", serviceRequest.diaryId, 5, DateTime.Now.Date);
               
            }
            else
            {
                int point = (int)ds.Tables["table1"].Rows[0][1];
                sqlStr = String.Format("update diary_point_table set point={0} where diaryId={1} and date='{2}'", point + 5, serviceRequest.diaryId, DateTime.Now.Date);

            }
            MySqlCommand command = new MySqlCommand();
            command.CommandText = sqlStr;
            command.Connection = conn;

            command.ExecuteNonQuery();

            conn.Close();
            response.returnCode = 0;
           
        }
    }
}
