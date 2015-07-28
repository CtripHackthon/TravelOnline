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
    public partial class long_game_building_permited : System.Web.UI.Page
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
            bool develop_enough = true;
            bool store_enough = true;
            bool factory_enough = true;
            bool market_enough = true;
            string user_id = "";
            string field_id = "";
            if (!this.IsPostBack)
            {
                if (Session["field_id"] != null && Session["user_id"] != null)
                {
                    user_id = Session["user_id"].ToString().Trim();
                    field_id = Session["field_id"].ToString().Trim();
                    develop_enough = checkResource(user_id, field_id, "1");
                    store_enough = checkResource(user_id, field_id, "2");
                    factory_enough = checkResource(user_id, field_id, "3");
                    market_enough = checkResource(user_id, field_id, "4");
                    if (develop_enough)
                    {
                        btdeveloproom.CommandArgument = "1";
                    }
                    else
                    {
                        btdeveloproom.Text = "原料不足";
                        btdeveloproom.Enabled = false;
                    }
                    if (store_enough)
                    {
                        btstore.CommandArgument = "2";
                    }
                    else
                    {
                        btstore.Text = "原料不足";
                        btstore.Enabled = false;
                    }
                    if (factory_enough)
                    {
                        btfactory.CommandArgument = "3";
                    }
                    else
                    {
                        btfactory.Text = "原料不足";
                        btfactory.Enabled = false;
                    }
                    if (market_enough)
                    {
                        btmarket.CommandArgument = "4";
                    }
                    else
                    {
                        btmarket.Text = "原料不足";
                        btmarket.Enabled = false;
                    }
                }
            }
        }
        /// <summary>
        /// 方法用来显示界面上的资源
        /// </summary>
        private void displayResourceNeeded()
        {
            string dwood_needed = "";
            string dstone_neede = "";
            string dtime_needed = "";
            string swood_needed = "";
            string sstone_needed = "";
            string stime_needed = "";
            string fwood_needed = "";
            string fstone_needed = "";
            string ftime_needed = "";
            string mwood_needed = "";
            string mstone_needed = "";
            string mtime_needed = "";
            if (Session["user_id"] != null)
            {
                string user_id = Session["user_id"].ToString().Trim();
                buildinginfo building = new buildinginfo();
                int[] dresources = building.GetResourcesNeeded(user_id, "a", "1");
                int[] sresources = building.GetResourcesNeeded(user_id, "a", "2");
                int[] mresources = building.GetResourcesNeeded(user_id, "a", "3");
                int[] fresources = building.GetResourcesNeeded(user_id, "a", "4");
                if (dresources.Length > 0)
                {
                    dwood_needed = dresources[0].ToString().Trim();
                    dstone_neede = dresources[1].ToString().Trim();
                    dtime_needed = dresources[2].ToString().Trim();
                }
                if (sresources.Length > 0)
                {
                    swood_needed = sresources[0].ToString().Trim();
                    sstone_needed = sresources[1].ToString().Trim();
                    stime_needed = sresources[2].ToString().Trim();
                }
                if (mresources.Length > 0)
                {
                    mwood_needed = mresources[0].ToString().Trim();
                    mstone_needed = mresources[1].ToString().Trim();
                    mtime_needed = mresources[2].ToString().Trim();
                }
                if (fresources.Length > 0)
                {
                    fwood_needed = fresources[0].ToString().Trim();
                    fstone_needed = fresources[1].ToString().Trim();
                    ftime_needed = fresources[2].ToString().Trim();
                }
                lbDstoneneeded.Text = dstone_neede;
                lbDwoodneeded.Text = dwood_needed;
                lbDtimeneeded.Text = dtime_needed;
                lbSstoneneeded.Text = sstone_needed;
                lbStimeneeded.Text = stime_needed;
                lbSwoodneeded.Text = swood_needed;
                lbMstoneneeded.Text = mstone_needed;
                lbMtimeneeded.Text = mtime_needed;
                lbMwoodneeded.Text = mwood_needed;
                lbFstoneneeded.Text = fstone_needed;
                lbFwoodneeded.Text = fwood_needed;
                lbFtimeneeded.Text = ftime_needed;

            }
        }
        private bool checkResource(string user_id, string field_id, string building_type)
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
            if (building_type == "1")
            {
                if (wood_count >= Int32.Parse(lbDwoodneeded.Text.ToString().Trim()) && stone_count >= Int32.Parse(lbDstoneneeded.Text.ToString().Trim()))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else if (building_type == "2")
            {
                if (wood_count >= Int32.Parse(lbSwoodneeded.Text.ToString().Trim()) && stone_count >= Int32.Parse(lbSstoneneeded.Text.ToString().Trim()))
                {
                    result = true;
                }
                else
                {

                    result = false;
                }
            }
            else if (building_type == "3")
            {
                if (wood_count >= Int32.Parse(lbFwoodneeded.Text.ToString().Trim()) && stone_count >= Int32.Parse(lbFstoneneeded.Text.ToString().Trim()))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else if (building_type == "4")
            {
                if (wood_count >= Int32.Parse(lbMwoodneeded.Text.ToString().Trim()) && stone_count >= Int32.Parse(lbMstoneneeded.Text.ToString().Trim()))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
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
                Response.Redirect("building_updated_requset.aspx?field_id=" + field_id);
            }
            else
            {
                Message.Show("请先登录", Response);
            }
        }
    }
}