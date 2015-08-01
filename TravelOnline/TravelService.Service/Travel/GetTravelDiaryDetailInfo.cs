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

            GetTravelDiaryDetailInfoRequest serviceRequest = new GetTravelDiaryDetailInfoRequest();

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
            }

            response.responseObj = serviceResponse;
            response.returnCode = 0;
        }
    }
}
