﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelService.Model.ServiceModel
{
    public class GetTravelDiaryDetailInfoResponse
    {
        public long username { get; set; }

        public DateTime publishTime { get; set; }

        public List<string> tags { get; set; }

        public byte[] content { get; set; }
    }
}
