using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelService.Model;
using TravelService.Model.Base.Travel;
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

          //  if (serviceRequest.tags != null && serviceRequest.tags.Length > 0)
            {
                GetAssociatedProductsInfoResponse serviceResponse = new GetAssociatedProductsInfoResponse();
                List<TravelProduct> products = new List<TravelProduct>();
                //Mock Data
                List<TravelProduct> raw_products  = new List<TravelProduct>();
                MockData(raw_products);

                int seed = 10;
                Random rand = new Random(seed);

                int num = rand.Next(4, 7);

                for (int i = 0; i < num; i++)
                {
                    int key = rand.Next(1, 10);
                    products.Add(raw_products.ElementAt(key));
                }


                serviceResponse.products = products;
                response.responseObj = serviceResponse;
                response.returnCode = 0;    
            }
            
        }



        private void MockData(List<TravelProduct> tpl)
        {
            
            TravelProduct tp1 = new TravelProduct();
            tp1.productId = 5;
            tp1.productName = "浙江杭州+千岛湖2日1晚跟团游";

            TravelProduct tp2 = new TravelProduct();
            tp2.productId = 522;
            tp2.productName = "安徽黄山3日2晚半自助游";

            TravelProduct tp3 = new TravelProduct();
            tp3.productId = 315;
            tp3.productName = "浙江西塘2日1晚跟团游";

            TravelProduct tp4 = new TravelProduct();
            tp4.productId = 735;
            tp4.productName = "厦门+鼓浪屿+福建土楼4日3晚跟团游";

            TravelProduct tp5 = new TravelProduct();
            tp5.productId = 845;
            tp5.productName = "北京5日跟团游(5钻)";

            TravelProduct tp6 = new TravelProduct();
            tp6.productId = 8456;
            tp6.productName = "西班牙+巴塞罗那+马德里11日9晚跟团游";

            TravelProduct tp7 = new TravelProduct();
            tp7.productId = 622;
            tp7.productName = "希腊+圣托里尼+西班牙+巴塞罗那12日10晚跟团游";

            TravelProduct tp8 = new TravelProduct();
            tp8.productId = 13;
            tp8.productName = "巴西+阿根廷13日9晚跟团游(4钻)";

            TravelProduct tp9 = new TravelProduct();
            tp9.productId = 6145;
            tp9.productName = "巴西+阿根廷+智利+秘鲁+墨西哥+古巴25日";

            TravelProduct tp10 = new TravelProduct();
            tp10.productId = 136;
            tp10.productName = "南极+阿根廷18日14晚跟团游";


            tpl.Add(tp1);
            tpl.Add(tp2);
            tpl.Add(tp3);
            tpl.Add(tp4);
            tpl.Add(tp5);
            tpl.Add(tp6);
            tpl.Add(tp7);
            tpl.Add(tp8);
            tpl.Add(tp9);
            tpl.Add(tp10);
        }
    }
}
