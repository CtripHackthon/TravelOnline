using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service;
using TravelService.Service.ServiceRepository;

namespace Application.Back.TravelService.UnitTest
{
    [TestClass]
    public class GetTravelDiaryDetailInfoUnitTest
    {
        [TestMethod]
        public void GetTravelDiaryDetailInfoTest()
        {
            IService service = ServiceFactory.getInstance().getService(service_type.GET_TRAVEL_DIARY_DETAIL);
            GetTravelDiaryDetailInfoRequest serviceRequest = new GetTravelDiaryDetailInfoRequest();

            serviceRequest.diaryid = 1;

            ServiceRequest request = new ServiceRequest(serviceRequest);
            ServiceResponse response = new ServiceResponse();
            service.process(request, response);

            Assert.AreEqual(0, response.returnCode);
        }
    }
}
