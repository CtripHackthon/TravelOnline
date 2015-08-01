using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelService.Model;
using TravelService.Model.Base.Common;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Travel
{
    public class GetDisplayCategories : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
            if (request == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            GetDisplayCategoriesResponse serviceResponse = new GetDisplayCategoriesResponse();
            List<Category> categories = new List<Category>();
            Category c1 = new Category();
            c1.categoryId = 1;
            c1.categoryName = "Test1";

            Category c2 = new Category();
            c2.categoryId = 2;
            c2.categoryName = "Test5";
            categories.Add(c1);
            categories.Add(c2);
            serviceResponse.categories = categories;
            response.returnCode = 0;
            response.responseObj = serviceResponse;
        }
    }
}
