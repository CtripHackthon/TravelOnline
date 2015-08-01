﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Travel
{
    public class PublishTravelDiary : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            PublishTravelDiaryRequest serviceRequest = (PublishTravelDiaryRequest)request.requestObj;

            if (serviceRequest.diary.userId < 0)
            {
                response.errMessage = ReportServiceMessage.USER_ID_ILLEGAL;
                response.returnCode = -1;
                return;
            }

            diary d = new diary();
            d.title = serviceRequest.diary.title;
            d.userID = (int)serviceRequest.diary.userId;
            d.tag = serviceRequest.diary.tags;
            d.content = serviceRequest.diary.content;
            d.publishTime = DateTime.Now;
            
            int diaryId = Diary.saveDiary(d);

            PublishTravelDiaryResponse serviceResoponse = new PublishTravelDiaryResponse();


            serviceResoponse.diaryId = diaryId;
            response.responseObj = serviceResoponse;
            response.returnCode = 0;
            return;

        }
    }
}
