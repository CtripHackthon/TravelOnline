using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Model.Base.Travel
{
    public class TravelDiarySummary
    {
        public long diaryId { get; set; }

        public long userId { get; set; }

        public string title { get; set; }

        public string username { get; set; }

        public string diaryPicAddr { get; set; }

        public string diarySummary { get; set; }

        public DateTime publishTime { get; set; }

        public string tags { get; set; }


    }
}
