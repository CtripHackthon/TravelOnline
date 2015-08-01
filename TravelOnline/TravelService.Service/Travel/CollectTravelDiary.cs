using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TravelService.DataService;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Travel
{
    public class CollectTravelDiary : IService
    {

        public void process(ServiceRequest request, ServiceResponse response)
        {
            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            CollectTravelDiaryRequest serviceRequest = (CollectTravelDiaryRequest)request.requestObj;
            if (serviceRequest.diaryId < 0 || serviceRequest.userId < 0)
            {
                response.errMessage = ReportServiceMessage.USER_ID_OR_DIARY_ID_INVALID;
                response.returnCode = -1;
                return;
            }

            string sqlStr = String.Format("select * from diary_collect_info where userid={0} and diaryid={1}", serviceRequest.userId, serviceRequest.diaryId);
            MySqlConnection conn = ConnectionManager.getInstance().getConnection();

            conn.Open();

            MySqlDataAdapter mda = new MySqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            mda.Fill(ds, "table1");
            if (ds.Tables["table1"].Rows.Count == 0)
            {
                sqlStr = String.Format("insert into diary_collect_info values ({0}, {1})", serviceRequest.userId, serviceRequest.diaryId);
                MySqlCommand command = new MySqlCommand();
                command.CommandText = sqlStr;
                command.Connection = conn;

                command.ExecuteNonQuery();
            }
            conn.Close();

            response.returnCode = 0;
        }
    }
}
