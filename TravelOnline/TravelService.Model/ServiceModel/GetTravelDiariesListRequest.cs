using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Model.ServiceModel
{
    public class GetTravelDiariesListRequest
    {
        public long userId { get; set; }

        public long diaryId { get; set; }

        public List<long> categoryIds { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        public long cityId { get; set; }


        public sort_type sortType { get; set; }
    }

    public enum sort_type
    {
        NATIVE_FIRST = 0,
        LASTEST_FIRST = 1,
        COMMENT_FIRST = 2,
         
    }
}
