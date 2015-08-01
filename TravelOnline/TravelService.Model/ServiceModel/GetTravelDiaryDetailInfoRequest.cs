using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Model.ServiceModel
{
    public class GetTravelDiaryDetailInfoRequest
    {
        public long userId { get; set; }


        public long diaryid { get; set; }
        public long username { get; set; }

        public DateTime publishTime { get; set; }

        public List<string> tags { get; set; }
    }



}
