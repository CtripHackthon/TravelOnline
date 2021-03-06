﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service;
using TravelService.Service.ServiceRepository;

namespace Application.Back.TravelService.UnitTest
{
    [TestClass]
    public class GetTravelDiariesListUnitTest
    {
        [TestMethod]
        public void GetTravelDiariesListTest()
        {
            IService service = ServiceFactory.getInstance().getService(service_type.GET_TRAVEL_DIARYLIST);
            GetTravelDiariesListRequest serviceRequest = new GetTravelDiariesListRequest();

            serviceRequest.categoryIds = new System.Collections.Generic.List<long>();
            serviceRequest.categoryIds.Add(2);

            ServiceRequest request = new ServiceRequest(serviceRequest);
            ServiceResponse response = new ServiceResponse();
            service.process(request, response);

            Assert.AreEqual(0, response.returnCode);
        }
    }
}
