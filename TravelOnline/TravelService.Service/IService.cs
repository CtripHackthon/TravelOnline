using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelService.Model;

namespace TravelService.Service
{
    public interface IService
    {
        void process(ServiceRequest request, ServiceResponse response);
    }

    public enum service_type
    {
        GET_USER_INFO = 1,
        REGIST_USER = 2,
        USER_LOGIN = 3,
        PUBLISH_TRAVEL_DIARY = 4,
        UPDATE_TRAVEL_DIARY = 5,
        DELETE_TRAVEL_DIARY = 6,
        GET_TRAVEL_COMMENT = 7,
        GET_TRAVEL_DIARYLIST = 8,
        GET_TRAVEL_DIARY_DETAIL = 9,
        GET_ASSOCIATED_PRODUCT = 10,
        GET_DISPLAY_CATEGORY = 11,
        COLLECT_TRAVEL_DIARY = 12,
    }
}
