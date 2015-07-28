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
    public partial class game_developroom_working : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadPage();
            String field_id = Session["field_id"].ToString();
            String user_id = Session["user_id"].ToString();
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            if (Session["field_id"] != null && Session["user_id"] != null)
            {
                field_id = Session["field_id"].ToString().Trim();
                user_id = Session["user_id"].ToString().Trim();
                String selectSql = "select eof_dt from building_state where player_id='" + user_id + "' and field_id='" + field_id + "'";
                DataTable dt = dbo.SelectToDataTable(selectSql);
                DateTime dTime = Convert.ToDateTime(dt.Rows[0]["eof_dt"].ToString());
                TimeSpan span = dTime - DateTime.Now;
                Session["eof_dt"] = Convert.ToInt32(span.TotalSeconds);
                if (span.TotalSeconds < 0)
                {
                    Response.Redirect("dealAccomplish.aspx?type=3");
                }
            }
        }
        private void loadPage()
        {
            string cpu_id = "";
            string user_id = "";
            if (!this.IsPostBack)
            {
                if (Request.QueryString["cpu_id"] != null && Session["user_id"] != null)
                {
                    cpu_id = Request.QueryString["cpu_id"].ToString().Trim();
                    user_id = Session["user_id"].ToString().Trim();
                    displayCpuInfo(user_id, cpu_id);
                }
            }
        }
        private void displayCpuInfo(string user_id, string cpu_id)
        {
            string cpu_imageurl = "";
            string cpu_description = "";
            string cpu_name = "";
            string sql = "select cpu_name,description,cpu_img from cpu_info where cpu_id='" + cpu_id + "'";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count > 0)
            {
                cpu_imageurl = dt.Rows[0][2].ToString().Trim();
                cpu_description = dt.Rows[0][1].ToString().Trim();
                cpu_name = dt.Rows[0][0].ToString().Trim();
            }
            else
            {

            }
            imcpu.ImageUrl = cpu_imageurl;
            lbcpuname.Text = cpu_name;
            lbcpudescription.Text = cpu_description;
        }
    }
}