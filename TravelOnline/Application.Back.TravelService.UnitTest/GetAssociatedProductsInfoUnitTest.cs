﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service;
using TravelService.Service.ServiceRepository;

namespace Application.Back.TravelService.UnitTest
{
    [TestClass]
    public class GetAssociatedProductsInfoUnitTest
    {
        [TestMethod]
        public void GetAssociatedProductsInfoTestMethod()
        {
            IService service = ServiceFactory.getInstance().getService(service_type.GET_ASSOCIATED_PRODUCT);
            GetAssociatedProductsInfoRequest serviceRequest = new GetAssociatedProductsInfoRequest();


            ServiceRequest request = new ServiceRequest(serviceRequest);
            ServiceResponse response = new ServiceResponse();
            service.process(request, response);

            Assert.AreEqual(0, response.returnCode);
        }
    }
}
