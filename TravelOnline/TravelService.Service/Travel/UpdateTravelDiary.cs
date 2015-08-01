using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Travel
{
    class UpdateTravelDiary : IService
    {
        public void process(Model.ServiceRequest request, Model.ServiceResponse response)
        {
            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            UpdateTravelDiaryRequest serviceRequest = (UpdateTravelDiaryRequest)request.requestObj;

            if (serviceRequest.userId < 0 || serviceRequest.diaryId < 0)
            {
                response.errMessage = ReportServiceMessage.USER_ID_OR_DIARY_ID_INVALID;
                response.returnCode = -1;
                return;
            }

            diary d = new diary();
            d.content = serviceRequest.diary.content;
            d.tag = serviceRequest.diary.tags;
            d.title = serviceRequest.diary.title;
            d.diaryID = (int)serviceRequest.diary.diaryId;

            Diary.updateDiary((int)serviceRequest.diary.diaryId, d);

            response.returnCode = 0;


        }
    }
}
