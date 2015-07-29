using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace TravelClient.UX.game
{
    public partial class game_welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["field_id"] != null)
            {
                Response.Redirect("field_type_request.aspx?field_id=" + Session["field_id"].ToString().Trim());
            }
        }
    }
}