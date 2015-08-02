using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelClient.UX.Ajax.Models;
using TravelService.Model;
using TravelService.Model.Base.Common;
using TravelService.Model.ServiceModel;
using TravelService.Service;
using TravelService.Service.ServiceRepository;

namespace TravelClient.UX.Ajax
{
    public partial class UserAjax : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["queryType"] == "register")
            {
                Response.Write(RegisterNewUser());
            }

            if (Request.Params["queryType"] == "login")
            {
                Response.Write(LoginUser());
            }


            if (Request.Params["queryType"] == "signoff")
            {
                Response.Write(signOff());
            }
        }

        private string RegisterNewUser() {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            UserInfo user = jss.Deserialize<UserInfo>(Request.Params["user"]);

            RegistUserRequest registerReq = new RegistUserRequest();
            registerReq.userinfo = user;

            ServiceRequest request = new ServiceRequest(registerReq);
            ServiceResponse response = new ServiceResponse();

            IService service = ServiceFactory.getInstance().getService(service_type.REGIST_USER);
           

            service.process(request, response);

            RegistUserResponse responseU = (RegistUserResponse)response.responseObj;

             if (response.returnCode==0)
             {
                 // Login successfully
                 Session["UserName"] = user.username;
                 Session["UserId"] = responseU.userId;
                 return "{\"register\":1}";
             }
             else
             {
                 return "{\"register\":0}";
             }
        }


        private string LoginUser() {

            JavaScriptSerializer jss = new JavaScriptSerializer();
            UserInfo user = jss.Deserialize<UserInfo>(Request.Params["user"]);

            UserLoginRequest registerReq = new UserLoginRequest();
            registerReq.username = user.username;
            registerReq.password = user.password;

            ServiceRequest request = new ServiceRequest(registerReq);
            ServiceResponse response = new ServiceResponse();

            IService service = ServiceFactory.getInstance().getService(service_type.USER_LOGIN);


            service.process(request, response);
            UserLoginResponse responseU = (UserLoginResponse)response.responseObj;
            
            if (response.returnCode == 0)
            {
                // Login successfully
                Session["UserName"] = user.username;
                Session["UserId"] = responseU.userId;
                return "{\"login\":1}";
            }
            else
            {
                return "{\"login\":0}";
            }

        }

        private string signOff() {
            Session.Remove("UserName");
            Session.Remove("UserId");

            return "";
        }
    }
}