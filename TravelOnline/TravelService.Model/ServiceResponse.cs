using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Model
{
    public class ServiceResponse
    {
        
        public Object responseObj { get; set; }

        public String errMessage { get; set; }

        public int returnCode { get; set; }
    }
}
