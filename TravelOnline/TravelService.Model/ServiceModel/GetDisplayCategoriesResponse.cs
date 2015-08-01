using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelService.Model.Base.Common;

namespace TravelService.Model.ServiceModel
{
    public class GetDisplayCategoriesResponse
    {
        public List<Category> categories { get; set; }
    }
}
