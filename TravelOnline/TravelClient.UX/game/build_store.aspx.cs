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
using TravelClient.UX.utils;
namespace TravelClient.UX.game
{
    public partial class game_build_store : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayResourceNeeded();
            loadPage();
        }
        /// <summary>
        /// 方法用来显现界面按钮加载功能
        /// </summary>
        private void loadPage()
        {
            bool store_enough = true;
            string user_id = "";
            string field_id = "";
            if (!this.IsPostBack)
            {
                if (Session["field_id"] != null && Session["user_id"] != null)
                {
                    user_id = Session["user_id"].ToString().Trim();
                    field_id = Session["field_id"].ToString().Trim();
                    store_enough = checkResource(user_id, field_id);
                    if (store_enough)
                    {
                        btstore.CommandArgument = "2";
                    }
                    else
                    {
                        btstore.Text = "原料不足";
                        btstore.Enabled = false;
                    }
                }
            }
        }
        /// <summary>
        /// 方法用来显示界面上的资源
        /// </summary>
        private void displayResourceNeeded()
        {
            string swood_needed = "";
            string sstone_needed = "";
            string stime_needed = "";
            if (Session["user_id"] != null)
            {
                string user_id = Session["user_id"].ToString().Trim();
                buildinginfo building = new  buildinginfo();
                int[] sresources = building.GetResourcesNeeded(user_id, "a", "2");
                if (sresources.Length > 0)
                {
                    swood_needed = sresources[0].ToString().Trim();
                    sstone_needed = sresources[1].ToString().Trim();
                    stime_needed = sresources[2].ToString().Trim();
                }
                lbSstoneneeded.Text = sstone_needed;
                lbStimeneeded.Text = stime_needed;
                lbSwoodneeded.Text = swood_needed;
            }
        }
        private bool checkResource(string user_id, string field_id)
        {
            bool result = true;
            int wood_count = 0;
            int stone_count = 0;
            string sql = "select wood_count,stone_count from player_resource where player_id='" + user_id + "'";
            //string sql = "select wood_needed,stone_needed from building_fees where building_id="+building_type+" and building_level='a'";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count > 0)
            {
                wood_count = Int32.Parse(dt.Rows[0][0].ToString().Trim());
                stone_count = Int32.Parse(dt.Rows[0][1].ToString().Trim());
            }
            else
            {
                Message.Show("数据库连接失败", Response);
            }
            if (wood_count >= Int32.Parse(lbSwoodneeded.Text.ToString().Trim()) && stone_count >= Int32.Parse(lbSstoneneeded.Text.ToString().Trim()))
            {
                result = true;
            }
            else
            {

                result = false;
            }
            return result;
        }

        protected void btdeveloproom_Click(object sender, EventArgs e)
        {
            string field_id = "";
            Button bt = sender as Button;
            if (Session["user_id"] != null && Session["field_id"] != null)
            {
                field_id = Session["field_id"].ToString().Trim();
                Click.buildingClick(bt.CommandArgument, Session["field_id"].ToString(), Session["user_id"].ToString());

                Response.Redirect("building_updated_requset.aspx?field_id=" + field_id + "&new=yes");
            }
            else
            {
                Message.Show("请先登录", Response);
            }
        }
        protected void btcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("build_welcome.aspx");
        }
    }
}