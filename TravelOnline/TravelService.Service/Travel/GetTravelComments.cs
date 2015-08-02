using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using TravelService.Model;
using TravelService.Model.Base.Common;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Travel
{
    public class GetTravelComments : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            GetTravelCommentsRequest serviceRequest = (GetTravelCommentsRequest)request.requestObj;

            if (serviceRequest.userId < 0 || serviceRequest.diaryId < 0)
            {
                response.errMessage = ReportServiceMessage.USER_ID_OR_DIARY_ID_INVALID;
                response.returnCode = -1;
                return;
            }

            List<comment> list = Comment.getCommentsByDiaryID((int)serviceRequest.diaryId);
            int size = list.Count;
            List<TravelComment> comments = new List<TravelComment>();
            for (int index = 0; index < size; index++)
            {
                TravelComment c = new TravelComment();
                comment ct = list.ElementAt(index);
               // c.username = ct.diaryID;
                c.content = ct.content;
                c.username = "default";
                comments.Add(c);
            }


            GetTravelCommentsResponse serviceResponse = new GetTravelCommentsResponse();

            serviceResponse.comments = comments;
            response.responseObj = serviceResponse;
            response.returnCode = 0;

            return;

        }
    }
}
