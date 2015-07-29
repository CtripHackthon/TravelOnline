using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Model
{
    public class ServiceRequest
    {
        public ServiceRequest(Object reqObj)
        {
            requestObj = reqObj;
        }
        public Object requestObj { get; set; }
    }
}
