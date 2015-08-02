using System;
using System.Collections.Generic;
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
    public class PublishTravelDiary : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            PublishTravelDiaryRequest serviceRequest = (PublishTravelDiaryRequest)request.requestObj;

            if (serviceRequest.diary.userId < 0)
            {
                response.errMessage = ReportServiceMessage.USER_ID_ILLEGAL;
                response.returnCode = -1;
                return;
            }

            diary d = new diary();
            d.title = serviceRequest.diary.title;
            d.userID = (int)serviceRequest.diary.userId;
            d.tag = serviceRequest.diary.tags;
            d.content = serviceRequest.diary.content;
            d.publishTime = DateTime.Now;
            
            int diaryId = Diary.saveDiary(d);

            MySqlConnection conn = ConnectionManager.getInstance().getConnection();

            conn.Open();

            string addr1 = null;
            string addr2 = null;
            string addr3 = null;
            if(serviceRequest.diary.addrs.Count > 0)
            {
                addr1 = serviceRequest.diary.addrs.ElementAt(0);
            }
            if(serviceRequest.diary.addrs.Count > 1)
            {
                addr2 = serviceRequest.diary.addrs.ElementAt(1);
            }
            if(serviceRequest.diary.addrs.Count > 2)
            {
                addr3 = serviceRequest.diary.addrs.ElementAt(2);
            }
            string sqlStr = String.Format("insert into diary_pic_info values ({0}, '{1}', '{2}', '{3}')", diaryId,
                                            addr1, addr2, addr3);
            MySqlCommand command = new MySqlCommand();
            command.CommandText = sqlStr;
            command.Connection = conn;

            command.ExecuteNonQuery();

            sqlStr = String.Format("update diary set categoryID={0} where diaryId={1}", serviceRequest.diary.belongCategory.categoryId, diaryId);

            command = new MySqlCommand();
            command.CommandText = sqlStr;
            command.Connection = conn;

            command.ExecuteNonQuery();
            conn.Close();



            PublishTravelDiaryResponse serviceResoponse = new PublishTravelDiaryResponse();


            serviceResoponse.diaryId = diaryId;
            response.responseObj = serviceResoponse;
            response.returnCode = 0;
            return;

        }
    }
}
