using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelService.Model;
using TravelService.Model.Base.Common;
using TravelService.Model.Base.Travel;
using TravelService.Model.ServiceModel;
using TravelService.Service;
using TravelService.Service.ServiceRepository;

namespace Application.Back.TravelService.UnitTest
{
    [TestClass]
    public class PublishDiaryUnitTest
    {
        [TestMethod]
        public void DiaryUnitTest()
        {
            IService service = ServiceFactory.getInstance().getService(service_type.PUBLISH_TRAVEL_DIARY);
            PublishTravelDiaryRequest serviceRequest = new PublishTravelDiaryRequest();

            TravelDiary td = new TravelDiary();
            td.userId = 9;
            td.tags = "3452,532,df3";
            td.content = "fajlsfjlkjl3kj4lk3j4l34lj343";
            td.title = "zhangzhenrep9834";
            Category c = new Category();
            c.categoryId = 2;
            c.categoryName = "oversea";
            td.belongCategory = c;
            td.addrs = new  List<string>();

            td.addrs.Add("fjladsfjkdsf");
            td.addrs.Add("fjladsfjkdsfd");
            td.addrs.Add("fjladsfjkdsfh");
            serviceRequest.diary = td;

            ServiceRequest request = new ServiceRequest(serviceRequest);
            ServiceResponse response = new ServiceResponse();
            service.process(request, response);

            Assert.AreEqual(0, response.returnCode);
           
        }
    }
}
