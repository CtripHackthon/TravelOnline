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
    public partial class game_building_in_build : System.Web.UI.Page
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
                String selectSql = "select type_in_building,eof_dt from player_country where player_id='" + user_id + "'";
                DataTable dt = dbo.SelectToDataTable(selectSql);
                DateTime dTime = Convert.ToDateTime(dt.Rows[0]["eof_dt"].ToString());
                TimeSpan span = dTime - DateTime.Now;
                Session["eof_dt"] = Convert.ToInt32(span.TotalSeconds);
                if (span.TotalSeconds < 0)
                {
                    Response.Redirect("dealAccomplish.aspx?type=1");
                }
            }
            dbo.CloseConnection();
        }
        private void loadPage()
        {
            if (!this.IsPostBack)
            {
                DataTable building_description = null;
                string building_name = "";
                string description = "";
                string type_in_building = "";
                if (Request.QueryString["type_in_building"] != null)
                {
                    type_in_building = Request.QueryString["type_in_building"].ToString().Trim();
                    building_description = getBuildingDescription(type_in_building);
                    building_name = building_description.Rows[0][0].ToString().Trim();
                    description = building_description.Rows[0][1].ToString().Trim();
                    lbbuildingtype.Text = building_name;
                    lbdescription.Text = "  " + description;
                    if (Request.QueryString["new"] != null)
                    {
                        my.InnerHtml = "<script type='text/javascript'>window.parent.location.reload();</script>";
                    }
                }
            }
        }
        /// <summary>
        /// 本方法得到正在建造建筑的信息
        /// </summary>
        /// <param name="type_in_building"></param>
        /// <returns></returns>
        private DataTable getBuildingDescription(string type_in_building)
        {
            string sql = "select building_name,building_description from building_description where building_id='" + type_in_building + "'";
            DataTable dt = selectToTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 本方法得到正在建筑的建筑的信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private DataTable selectToTable(string sql)
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
    }
}