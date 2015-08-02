using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelClient.UX.Ajax.Models;
using TravelService.Model;
using TravelService.Model.Base.Travel;
using TravelService.Model.ServiceModel;
using TravelService.Service;
using TravelService.Service.ServiceRepository;

namespace TravelClient.UX.Ajax
{
    public partial class PostAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["queryType"] == "addPicture")
            {
                Response.Write(AddPicture());
            }

            if (Request["queryType"] == "getproducts")
            {
                Response.Write(GetProducts());
            }
            

             if (Request["queryType"] == "removePicture")
            {
                RemovePicture();
            }


             if (Request["queryType"] == "getcategory")
             {
                 Response.Write(GetCategoryList());
             }

             if (Request["queryType"] == "getpostsbycategoryid")
             {
                 Response.Write(GetArticlesByCategoryId());
             }
            
             if (Request["queryType"] == "getarticlebyid")
             {
                 Response.Write(GetArticleByID());
             }

             if (Request["queryType"] == "savearticle")
             {
                 Response.Write(SubmitArticle());
             }
            

        }

        private string GetArticlesByCategoryId() {


            JavaScriptSerializer jss = new JavaScriptSerializer();
            var paramDes = jss.Deserialize<TravelDiary>(Request["queryParam"]);

            return "";
        }

        private string GetProducts() {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            GetAssociatedProductsInfoRequest registerReq = new GetAssociatedProductsInfoRequest();


            ServiceRequest request = new ServiceRequest(registerReq);
            ServiceResponse response = new ServiceResponse();

            IService service = ServiceFactory.getInstance().getService(service_type.GET_ASSOCIATED_PRODUCT);


            service.process(request, response);
            GetAssociatedProductsInfoResponse responseU = (GetAssociatedProductsInfoResponse)response.responseObj;
            return jss.Serialize(responseU.products);
        }
        private string SubmitArticle() {

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var paramDes = jss.Deserialize<TravelDiary>(Request["queryParam"]);

            PublishTravelDiaryRequest registerReq = new PublishTravelDiaryRequest();
            registerReq.diary = paramDes;


            ServiceRequest request = new ServiceRequest(registerReq);
            ServiceResponse response = new ServiceResponse();

            IService service = ServiceFactory.getInstance().getService(service_type.PUBLISH_TRAVEL_DIARY);


            service.process(request, response);
            PublishTravelDiaryResponse responseU = (PublishTravelDiaryResponse)response.responseObj;
            return responseU.diaryId.ToString();

        }
        private string GetArticleByID() {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            string articleId = Request["id"].ToString();



            GetTravelDiaryDetailInfoRequest registerReq = new GetTravelDiaryDetailInfoRequest();
            registerReq.diaryid = int.Parse(articleId);


            ServiceRequest request = new ServiceRequest(registerReq);
            ServiceResponse response = new ServiceResponse();

            IService service = ServiceFactory.getInstance().getService(service_type.GET_TRAVEL_DIARY_DETAIL);


            service.process(request, response);
            GetTravelDiaryDetailInfoResponse responseU = (GetTravelDiaryDetailInfoResponse)response.responseObj;
            return jss.Serialize(responseU.diaryInfo);
        }
        private void RemovePicture()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var paramDes = jss.Deserialize<ListQueryParameterPicture>(Request["queryParam"]);

            foreach (var item in paramDes)
            {
                FileInfo myfileinf = new FileInfo(Server.MapPath(item));
                myfileinf.Delete();
            }
        }

        private string GetCategoryList() {

            JavaScriptSerializer jss = new JavaScriptSerializer();

            GetCategoryRequest registerReq = new GetCategoryRequest();


            ServiceRequest request = new ServiceRequest(registerReq);
            ServiceResponse response = new ServiceResponse();

            IService service = ServiceFactory.getInstance().getService(service_type.GET_DISPLAY_CATEGORY);


            service.process(request, response);
            GetCategoryResponse responseU = (GetCategoryResponse)response.responseObj;
            return jss.Serialize(responseU.categories);
        }

        private string AddPicture()
        {
            string output = "";
            Guid subString = Guid.NewGuid();
            // Get the post data
            if (Request.Files == null)
            {
                output = "Querystring:uploaded file is null!";
            }
            //var paramDes = jss.Deserialize<QueryParameterPicture>(Request["data"]);

            string logicalPath = "";
            //if (paramDes.SaveLocation != string.Empty)
            //{
            //    // Save int temp location
            //    picturePath = Server.MapPath("../CustomerPicture/Temp/");
            //    logicalPath = "../CustomerPicture/Temp/";
            //}
            //else
            //{
            var picturePath = Server.MapPath("../CustomerPicture/");
            logicalPath = "../CustomerPicture/";
            //}
            string[] stringSplit = Request.Files[0].FileName.Split('\\');
            int temp = stringSplit.Length;

            string newFileName = picturePath + subString + stringSplit[temp - 1];
            Directory.CreateDirectory(Path.GetDirectoryName(newFileName));

            string newLogicFileName = logicalPath + subString + stringSplit[temp - 1];



            using (FileStream fileStream = File.Create(newFileName))
            {
                var buffer = new byte[Request.Files[0].ContentLength];
                int readCount = Request.Files[0].InputStream.Read(buffer, 0, buffer.Length);

                if (readCount > 0)
                {
                    fileStream.Write(buffer, 0, readCount);
                }
            }
            Console.Write("Hello");
            return newLogicFileName;
        }
    }
}