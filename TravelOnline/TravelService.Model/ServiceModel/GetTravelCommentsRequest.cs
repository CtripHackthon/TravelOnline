﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Model.ServiceModel
{
    public class GetTravelCommentsRequest
    {
        public long userId { get; set; }

        public long diaryId { get; set; }
    }
}
