using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
            
            
            GetTravelDiariesListResponse serviceResponse = new GetTravelDiariesListResponse();

            serviceResponse.MyProperty = new List<TravelDiarySummary>();

            response.responseObj = serviceResponse;

            response.returnCode = 0;
        }
    }
}
