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
    public partial class game_building_in_manufacture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadInfo();
            String field_id = "c";
            String user_id = "";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            if (Session["field_id"] != null && Session["user_id"] != null)
            {
                field_id = Session["field_id"].ToString().Trim();
                user_id = Session["user_id"].ToString().Trim();


            }
            String selectSql = "select eof_dt from building_state where player_id='" + user_id + "' and field_id='" + field_id + "'";
            DataTable dt = dbo.SelectToDataTable(selectSql);
            DateTime dTime = Convert.ToDateTime(dt.Rows[0]["eof_dt"].ToString());
            TimeSpan span = dTime - DateTime.Now;
            Session["eof_dt"] = Convert.ToInt32(span.TotalSeconds);
            if (span.TotalSeconds < 0)
            {
                Response.Redirect("dealAccomplish.aspx?type=4");
            }
        }
        private void loadInfo()
        {
            String player_id = "";
            String field_id = "c";
            if (Session["user_id"] != null && Session["field_id"] != null)
            {
                player_id = Session["user_id"].ToString().Trim();
                field_id = Session["field_id"].ToString().Trim();
            }
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            String selectSql = "select work_content,building_state.description,cpu_name,cpu_img from cpu_info,building_state where player_id='" + player_id + "' and field_id='" + field_id + "' and cpu_info.cpu_id=work_content";
            DataTable dt = dbo.SelectToDataTable(selectSql);
            lcpuname.Text = dt.Rows[0]["cpu_name"].ToString();
            lcpucount.Text = dt.Rows[0]["description"].ToString();
            imgcpu.ImageUrl = dt.Rows[0]["cpu_img"].ToString();
        }
    }
}