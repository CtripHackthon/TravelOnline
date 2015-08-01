using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service;
using TravelService.Service.ServiceRepository;

namespace Application.Back.TravelService.UnitTest
{
    [TestClass]
    public class GetCategoryUnitTest
    {
        [TestMethod]
        public void GetCategoryTestMethod()
        {
            IService service = ServiceFactory.getInstance().getService(service_type.GET_DISPLAY_CATEGORY);
            GetCategoryRequest serviceRequest = new GetCategoryRequest();

           

            ServiceRequest request = new ServiceRequest(serviceRequest);
            ServiceResponse response = new ServiceResponse();
            service.process(request, response);

            Assert.AreEqual(0, response.returnCode);
        }
    }
}
