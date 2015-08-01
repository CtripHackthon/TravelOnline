using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelService.Model;
using TravelService.Model.ServiceModel;

namespace TravelService.MockService
{
    public class MockDataFactory
    {
        private static MockDataFactory factory = null;
        private MockDataRepository repositoy;
        private MockDataFactory() { }

        public MockDataFactory getInstance()
        {
            if(factory == null)
            {
                factory = new MockDataFactory();
            }

            return factory;
        }

        public ServiceResponse getResponse(service_type type)
        {
            if (repositoy == null)
            {
                lazyinit();
            }

            return repositoy.getServiceEntity(type);
        }

        private void lazyinit()
        {
            repositoy = new MockDataRepository();
            ServiceResponse response = null;

            response = new ServiceResponse();
            response.responseObj = new GetUserInfoResponse();

            repositoy.storeServiceEntity(service_type.GET_USER_INFO, response);

            response = new ServiceResponse();
            response.responseObj = new RegistUserResponse();
            repositoy.storeServiceEntity(service_type.REGIST_USER, response);

            response = new ServiceResponse();
            response.responseObj = new UserLoginResponse();
            repositoy.storeServiceEntity(service_type.USER_LOGIN, response);

            response = new ServiceResponse();
            response.responseObj = new DeleteTravelDiaryResponse();
            repositoy.storeServiceEntity(service_type.DELETE_TRAVEL_DIARY, response);

            response = new ServiceResponse();
            response.responseObj = new UpdateTravelDiaryResponse();
            repositoy.storeServiceEntity(service_type.UPDATE_TRAVEL_DIARY, response);

            response = new ServiceResponse();
            response.responseObj = new PublishTravelDiaryResponse();
            repositoy.storeServiceEntity(service_type.PUBLISH_TRAVEL_DIARY, response);

            response = new ServiceResponse();
            response.responseObj = new GetTravelDiariesListResponse();
            repositoy.storeServiceEntity(service_type.GET_TRAVEL_DIARYLIST, response);

            response = new ServiceResponse();
            response.responseObj = new GetTravelDiaryDetailInfoResponse();
            repositoy.storeServiceEntity(service_type.GET_TRAVEL_DIARY_DETAIL, response);

            response = new ServiceResponse();
            response.responseObj = new GetTravelCommentsResponse();
            repositoy.storeServiceEntity(service_type.GET_TRAVEL_COMMENT, response);

            response = new ServiceResponse();
            response.responseObj = new GetAssociatedProductsInfoResponse();
            repositoy.storeServiceEntity(service_type.GET_ASSOCIATED_PRODUCT, response);

            response = new ServiceResponse();
            response.responseObj = new GetDisplayCategoriesResponse();
            repositoy.storeServiceEntity(service_type.GET_DISPLAY_CATEGORY, response);

            return;
        }
    }
}
