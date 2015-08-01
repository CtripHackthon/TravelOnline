using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelClient.UX.Ajax.Models;

namespace TravelClient.UX.Ajax
{
    public partial class UserAjax : System.Web.UI.Page
    {
       private DATABASE.SQLDBOperate operate = new DATABASE.SQLDBOperate();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["queryType"] == "register") {
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
            UserModel user = jss.Deserialize<UserModel>(Request.Params["user"]);


            operate.Connect();
            operate.UpdateDataBase("insert into users(uname,upassword) values('" + user.UserName + "','"+user.Password+"')");
            operate.CloseConnection();
            return null;
        }


        private string LoginUser() {

            JavaScriptSerializer jss = new JavaScriptSerializer();
            UserModel user = jss.Deserialize<UserModel>(Request.Params["user"]);

            operate.Connect();
            string query = "select * from users where uname='" + user.UserName + "' and upassword='" + user.Password + "'";

            DataTable dt = operate.SelectToDataTable(query);

            operate.CloseConnection();

            if (dt.Rows.Count > 0)
            {
                Session["user_id"] = dt.Rows[0]["id"];
                Session["UserName"] = dt.Rows[0]["uname"];

                // Login successfully
                return "{\"login\":1}";
            }
            else {
                return "{\"login\":0}";
            }

        }

        private string signOff() {
            Session.Remove("UserName");
            return "";
        }
    }
}