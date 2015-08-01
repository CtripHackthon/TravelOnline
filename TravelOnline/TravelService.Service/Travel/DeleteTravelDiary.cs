using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Travel
{
    public class DeleteTravelDiary : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            DeleteTravelDiaryRequest serviceRequest = (DeleteTravelDiaryRequest)request.requestObj;

            if (serviceRequest.userId < 0)
            {
                response.errMessage = ReportServiceMessage.USER_ID_ILLEGAL;
                response.returnCode = -1;
                return;
            }

            if (serviceRequest.diariesList != null)
            {
                String[] diaryIds = serviceRequest.diariesList.Split(',');
                if (diaryIds.Length > 0)
                {
                    int len = diaryIds.Length;
                    for (int index = 0; index < len; index++ )
                    {
                        Diary.DeleteTraveDiary(int.Parse(diaryIds[index]));
                    }
                    
                }
            }
            DeleteTravelDiaryResponse serviceResponse = new DeleteTravelDiaryResponse();
            response.responseObj = serviceResponse;
            response.returnCode = 0;
        }
    }
}
