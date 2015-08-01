using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Common
{
    public class GetUserInfo : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            GetUserInfoRequest serviceRequest = (GetUserInfoRequest)request.requestObj;

            if (serviceRequest.userId < 0)
            {
                response.errMessage = ReportServiceMessage.USER_ID_ILLEGAL;
                response.returnCode = -1;
                return;
            }

            GetUserInfoResponse serviceResponse = new GetUserInfoResponse();
            response.responseObj = serviceResponse;
            response.returnCode = 0;

        }
    }
}
