using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Service.ServiceRepository
{
    public class ServiceRepository
    {

        private Dictionary<service_type, IService> repositoy;

        public ServiceRepository()
        {
            repositoy = new Dictionary<service_type, IService>();
        }

        public void storeServiceEntity(service_type type, IService service_entity)
        {
            repositoy.Add(type, service_entity);
        }

        public IService getServiceEntity(service_type type)
        {
            return repositoy[type];
        }

    }
}
