﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelService.Model.Base.Travel;

namespace TravelService.Model.ServiceModel
{
    public class PublishTravelDiaryRequest
    {
        public TravelDiary diary { get; set; }
    }
}
