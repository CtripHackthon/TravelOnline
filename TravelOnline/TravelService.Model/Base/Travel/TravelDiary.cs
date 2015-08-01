using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelService.Model.Base.Common;

namespace TravelService.Model.Base.Travel
{
    public class TravelDiary
    {
        public long userId { get; set; }

        public string title { get; set; }


        public string content { get; set; }

        public string tags { get; set; }

        public Category belongCategory { get; set; }

        public List<string> addrs { get; set; }
    }
}
