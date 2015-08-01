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

            //if (Request.Params["queryType"] == "login")
            //{
            //    Response.Write(LoginUser());
            //}


            //if (Request.Params["queryType"] == "signoff")
            //{
            //    Response.Write(signOff());
            //}
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
            
             if (response.returnCode==0)
             {
                 // Login successfully
                 return "{\"register\":1}";
             }
             else
             {
                 return "{\"register\":0}";
             }
        }


        private string LoginUser() {

            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //UserModel user = jss.Deserialize<UserModel>(Request.Params["user"]);


            //using (MainDBUnitWorkContext context = new MainDBUnitWorkContext()) {
            //    UserRepository ur = new UserRepository(context);
            //    UserService uservice = new UserService(ur);
            //    bool success = uservice.LoginUser(new AppUser() { UserName = user.UserName, UserPassword = user.Password });

            //    if (success)
            //    {
            //        Session["UserName"] = user.UserName;

            //        // Login successfully
            //        return "{\"login\":1}";
            //    }
            //    else
            //    {
            //        return "{\"login\":0}";
 
            //    }
            //}

            return "";

        }

        private string signOff() {
            Session.Remove("UserName");
            return "";
        }
    }
}