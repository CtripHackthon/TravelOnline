using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Model.ServiceModel
{
    public class DeleteTravelDiaryRequest
    {
        public long userId { get; set; }

        public String diariesList { get; set; }

    }
}
