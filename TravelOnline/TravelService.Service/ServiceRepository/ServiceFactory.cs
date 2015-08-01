using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelService.Service.Common;
using TravelService.Service.Travel;

namespace TravelService.Service.ServiceRepository
{
    public class ServiceFactory
    {
        private ServiceFactory()
        { }

        private static ServiceFactory factory;
        private ServiceRepository repositoy;

        public static ServiceFactory getInstance()
        {
            if (factory == null)
            {
                factory = new ServiceFactory();
            }

            return factory;
        }

        public IService getService(service_type type)
        {
            if (repositoy == null)
            {
                lazyinit();
            }

            return repositoy.getServiceEntity(type);
        }

        private void lazyinit()
        {
            repositoy = new ServiceRepository();
            IService entity = null;

            entity = new GetUserInfo();
            repositoy.storeServiceEntity(service_type.GET_USER_INFO, entity);

            entity = new RegistUser();
            repositoy.storeServiceEntity(service_type.REGIST_USER, entity);

            entity = new UserLogin();
            repositoy.storeServiceEntity(service_type.USER_LOGIN, entity);

            entity = new DeleteTravelDiary();
            repositoy.storeServiceEntity(service_type.DELETE_TRAVEL_DIARY, entity);

            entity = new UpdateTravelDiary();
            repositoy.storeServiceEntity(service_type.UPDATE_TRAVEL_DIARY, entity);

            entity = new PublishTravelDiary();
            repositoy.storeServiceEntity(service_type.PUBLISH_TRAVEL_DIARY, entity);

            entity = new GetTravelDiariesList();
            repositoy.storeServiceEntity(service_type.GET_TRAVEL_DIARYLIST, entity);

            entity = new GetTravelDiaryDetailInfo();
            repositoy.storeServiceEntity(service_type.GET_TRAVEL_DIARY_DETAIL, entity);

            entity = new GetTravelComments();
            repositoy.storeServiceEntity(service_type.GET_TRAVEL_COMMENT, entity);

            entity = new GetAssociatedProductsInfo();
            repositoy.storeServiceEntity(service_type.GET_ASSOCIATED_PRODUCT, entity);

            entity = new GetCategory();
            repositoy.storeServiceEntity(service_type.GET_DISPLAY_CATEGORY, entity);

            return;
        }

    }
}
