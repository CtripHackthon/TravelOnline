using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Common
{
    public class UserLogin : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            UserLoginRequest serviceRequest = (UserLoginRequest)request.requestObj;

            if (serviceRequest.username == null ||
                serviceRequest.password == null)
            {
                response.errMessage = ReportServiceMessage.USER_OR_PASSWORD_ILLEGAL;
                response.returnCode = -1;
                return;
            }

            user u = new user();
            int? id = (int)User.getIdentity(serviceRequest.username, serviceRequest.password);

            if (id > 0)
            {
                UserLoginResponse serviceResponse = new UserLoginResponse();
                serviceResponse.userId = (long)id;
                response.responseObj = serviceResponse;
                response.returnCode = 0;

            }
            else 
            {
                response.returnCode = -1;
                response.errMessage = "password err";
            }
            
            return;
        }
    }
}
