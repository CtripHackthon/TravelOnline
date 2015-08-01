using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service;
using TravelService.Service.ServiceRepository;

namespace Application.Back.TravelService.UnitTest
{
    [TestClass]
    public class UserLoginUnitTest
    {
        [TestMethod]
        public void TestLoginSuccess()
        {
            IService service = ServiceFactory.getInstance().getService(service_type.USER_LOGIN);
            UserLoginRequest serviceRequest = new UserLoginRequest();

            serviceRequest.username = "jack";
            serviceRequest.password = "1234";
        


            ServiceRequest request = new ServiceRequest(serviceRequest);
            ServiceResponse response = new ServiceResponse();
            service.process(request, response);

            Assert.AreEqual(0, response.returnCode);
            Assert.IsTrue(7 == ((UserLoginResponse)response.responseObj).userId);
            
        }

        [TestMethod]
        public void TestLoginFail()
        {
            IService service = ServiceFactory.getInstance().getService(service_type.USER_LOGIN);
            UserLoginRequest serviceRequest = new UserLoginRequest();

            serviceRequest.username = "jack";
            serviceRequest.password = "23";



            ServiceRequest request = new ServiceRequest(serviceRequest);
            ServiceResponse response = new ServiceResponse();
            service.process(request, response);

            Assert.AreEqual(-1, response.returnCode);
           
        }
    }
}
