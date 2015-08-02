using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelService.Model.Base.Travel;

namespace TravelService.Model.ServiceModel
{
    public class GetAssociatedProductsInfoResponse
    {
        public List<TravelProduct> products { get; set; }
    }
}
