using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelService.Model;
using TravelService.Model.Base.Common;
using TravelService.Model.ServiceModel;
using TravelService.Service;
using TravelService.Service.ServiceRepository;
using TravelService.Service.Utilities;

namespace Application.Back.TravelService.UnitTest
{
    [TestClass]
    public class RegistUserUnitTest
    {

        [TestMethod]
        public void ResgistUserTest()
        {
            IService service = ServiceFactory.getInstance().getService(service_type.REGIST_USER);
            RegistUserRequest serviceRequest = new RegistUserRequest();
            UserInfo ui = new UserInfo();
            ui.username = "jack";
            ui.password = "1234";
            ui.phone = "12344525";
            ui.email = "twoit@145.com";

            serviceRequest.userinfo = ui;
           

            ServiceRequest request = new ServiceRequest(serviceRequest);
            ServiceResponse response = new ServiceResponse();
            service.process(request, response);

            Assert.IsTrue(9 == ((RegistUserResponse)response.responseObj).userId);
            Assert.AreEqual(0, response.returnCode);

        }

        [TestMethod]
        public void ResgistUserTest1()
        {
            IService service = ServiceFactory.getInstance().getService(service_type.REGIST_USER);
            RegistUserRequest serviceRequest = new RegistUserRequest();

            UserInfo ui = new UserInfo();
            ui.username = "jack";
          
            ui.phone = "12344525";
            ui.email = "twoit@145.com";

            serviceRequest.userinfo = ui;

            ServiceRequest request = new ServiceRequest(serviceRequest);
            ServiceResponse response = new ServiceResponse();
            service.process(request, response);

            Assert.AreEqual(-1, response.returnCode);
            Assert.AreEqual(ReportServiceMessage.USER_OR_PASSWORD_ILLEGAL, response.errMessage);

        }
               
    }
}
