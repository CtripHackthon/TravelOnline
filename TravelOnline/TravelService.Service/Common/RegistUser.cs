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
    public class RegistUser : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            RegistUserRequest serviceRequest = (RegistUserRequest)request.requestObj;

            if (serviceRequest.userinfo.username == null ||
                serviceRequest.userinfo.password == null)
            {
                response.errMessage = ReportServiceMessage.USER_OR_PASSWORD_ILLEGAL;
                response.returnCode = -1;
                return;
            }

            user u = new user();
            u.email = serviceRequest.userinfo.email;
            u.password = serviceRequest.userinfo.password;
            u.phone = serviceRequest.userinfo.phone;
            u.userName = serviceRequest.userinfo.username;
            
            RegistUserResponse serviceResponse = new RegistUserResponse();
            serviceResponse.userId = User.saveUser(u);
         
            response.responseObj = serviceResponse;
            response.returnCode = 0;
            return;
        }
    }
}
