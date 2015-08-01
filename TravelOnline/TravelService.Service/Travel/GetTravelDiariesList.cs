using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using TravelService.Model;
using TravelService.Model.Base.Travel;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Travel
{
    class GetTravelDiariesList : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            GetTravelDiariesListRequest serviceRequest =  (GetTravelDiariesListRequest)request.requestObj;

            string sqlStr = null;
            GetTravelDiariesListResponse serviceResponse = new GetTravelDiariesListResponse();

            List<TravelDiarySummary> diarylist = new List<TravelDiarySummary>();
            if (serviceRequest.diaryId > 0)
            {
                diary d = Diary.getDiaryByDiaryID((int)serviceRequest.diaryId);
                if (d != null)
                {
                    TravelDiarySummary ds = new TravelDiarySummary();
                    ds.diaryId = d.diaryID;
                    ds.diaryPicAddr = "default";
                    ds.diarySummary = "summary";
                    ds.publishTime = (DateTime)d.publishTime;
                    ds.tags = d.tag;
                    ds.title  = d.title;
                    diarylist.Add(ds);
                }
            }
            else
            {
                if (serviceRequest.userId > 0)
                {
                    
                }
                //int userid = ()
            }


            serviceResponse.diaries = diarylist;
            response.responseObj = serviceResponse;

            response.returnCode = 0;
        }
    }
}
