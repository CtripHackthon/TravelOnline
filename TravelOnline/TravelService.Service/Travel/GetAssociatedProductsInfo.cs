using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelService.Model;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Travel
{
    public class GetAssociatedProductsInfo : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
             if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            GetAssociatedProductsInfoRequest serviceRequest = (GetAssociatedProductsInfoRequest)request.requestObj;

            if (serviceRequest.tags != null && serviceRequest.tags.Length > 0)
            {
                GetAssociatedProductsInfoResponse serviceResponse = new GetAssociatedProductsInfoResponse();
                Hashtable products = new Hashtable();
                String p1 = "airplane";
                byte[] addr1 = new byte[16];
                products.Add(p1, addr1);
                serviceResponse.products = products;
                response.responseObj = serviceResponse;
                response.returnCode = 0;    
            }
            
        }
    }
}
