using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            response.returnCode = 0;
        }
    }
}
