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
            

            response.responseObj = serviceResponse;
            response.returnCode = 0;
        }
    }
}
