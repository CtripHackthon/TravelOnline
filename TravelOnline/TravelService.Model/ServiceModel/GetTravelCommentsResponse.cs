using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Model.ServiceModel
{
    public class GetTravelCommentsResponse
    {
        public long commentNum { get; set; }

        public String[] comments { get; set; }
    }
}
