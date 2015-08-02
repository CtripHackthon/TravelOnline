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
using TravelService.Model.Base.Travel;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Travel
{
    public class GetTravelDiaryDetailInfo : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            GetTravelDiaryDetailInfoRequest serviceRequest = (GetTravelDiaryDetailInfoRequest)request.requestObj;

            if (serviceRequest.diaryid < 0 || serviceRequest.userId < 0)
            {
                response.errMessage = ReportServiceMessage.USER_ID_OR_DIARY_ID_INVALID;
                response.returnCode = -1;
                return;
            }

            GetTravelDiaryDetailInfoResponse serviceResponse = new GetTravelDiaryDetailInfoResponse();
            if (serviceRequest.diaryid > 0)
            {
                diary d = Diary.getDiaryByDiaryID((int)serviceRequest.diaryid);
                if (d != null)
                {
                    TravelDiary ds = new TravelDiary();
                    ds.diaryId = d.diaryID;
                    ds.content = d.content;
                    ds.userId = (long)d.userID;
                    ds.publishTime = ((DateTime)d.publishTime).ToString();
                    ds.tags = d.tag;
                    ds.title = d.title;
                    serviceResponse.diaryInfo = ds;        
                }

                string sqlStr = string.Format("select * from diary_pic_info where diaryId={0}", serviceRequest.diaryid);

                MySqlConnection conn = ConnectionManager.getInstance().getConnection();

                conn.Open();

                MySqlDataAdapter mda = new MySqlDataAdapter(sqlStr, conn);
                DataSet ds1 = new DataSet();
                mda.Fill(ds1, "table1");

                conn.Close();

                int count = ds1.Tables["table1"].Rows.Count;
                List<string> strlist = new List<string>();
                if(count > 0)
                {
                    string str = null;
                    str = (string)ds1.Tables["table1"].Rows[0][1];

                    if(str != null)
                        strlist.Add(str);

                    str = (string)ds1.Tables["table1"].Rows[0][2];

                    if (str != null)
                        strlist.Add(str);

                    str = (string)ds1.Tables["table1"].Rows[0][3];

                    if (str != null)
                        strlist.Add(str);

                }

                serviceResponse.diaryInfo.addrs = strlist;

            }

            response.responseObj = serviceResponse;
            response.returnCode = 0;
        }
    }
}
