using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service;
using TravelService.Service.ServiceRepository;

namespace Application.Back.TravelService.UnitTest
{
    [TestClass]
    public class ReserveProductUnitTest
    {
        [TestMethod]
        public void ReserveProductTest()
        {
            IService service = ServiceFactory.getInstance().getService(service_type.RESERVE_PRODUCT);
            ReserveProductRequest serviceRequest = new ReserveProductRequest();

            serviceRequest.diaryId = 5;
            serviceRequest.point = 5;
           

            ServiceRequest request = new ServiceRequest(serviceRequest);
            ServiceResponse response = new ServiceResponse();
            service.process(request, response);

            Assert.AreEqual(0, response.returnCode);
        }
    }
}
