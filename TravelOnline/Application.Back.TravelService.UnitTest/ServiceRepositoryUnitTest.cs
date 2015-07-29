using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelService.Service;
using TravelService.Service.Common;
using TravelService.Service.ServiceRepository;

namespace Application.Back.TravelService.UnitTest
{
   
    [TestClass]
    public class ServiceRepositoryUnitTest
    {

        [TestMethod]
        public void ServiceRepositoryStoreTest()
        {
            ServiceRepository repo = new ServiceRepository();
            IService entity = new RegistUser();
            repo.storeServiceEntity(service_type.REGIST_USER, entity);
            Assert.AreSame(entity, repo.getServiceEntity(service_type.REGIST_USER));
        }

    }
}
