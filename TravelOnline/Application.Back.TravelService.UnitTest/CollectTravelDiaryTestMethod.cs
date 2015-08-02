using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service;
using TravelService.Service.ServiceRepository;

namespace Application.Back.TravelService.UnitTest
{
    [TestClass]
    public class CollectTravelDiaryUnitTest
    {
        [TestMethod]
        public void CollectTravelDiaryTestMethod()
        {
            IService service = ServiceFactory.getInstance().getService(service_type.COLLECT_TRAVEL_DIARY);
            CollectTravelDiaryRequest serviceRequest = new CollectTravelDiaryRequest();

            serviceRequest.userId = 45;
            serviceRequest.diaryId = 9;

            ServiceRequest request = new ServiceRequest(serviceRequest);
            ServiceResponse response = new ServiceResponse();
            service.process(request, response);

            Assert.AreEqual(0, response.returnCode);
           
        }
    }
}
