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
    public partial class game_store_update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                pageLoading();
            }
        }
        /// <summary>
        /// 本方法纯粹是为了结构的明了性
        /// </summary>
        private void pageLoading()
        {
            bool updateok = false;
            if (Request.QueryString["building_type"] != null && Session["user_id"] != null && Request.QueryString["flag"] == null)
            {
                //首先判断级别有没有达到最高级

                string user_id = Session["user_id"].ToString().Trim();
                string building_type = Request.QueryString["building_type"].ToString().Trim();
                char charLevel = Char.Parse(building_type);
                int level = (charLevel - 'a') + 1;
                lbcurrentlevel.Text = level.ToString();
                //显示建筑升级所需要的材料
                if (Char.Parse(building_type) - 'j' < 0)
                {
                    displayBuildingInfo(building_type, user_id);
                    //判断升级按钮是不是能用
                    updateok = checkButtonEnable(user_id);
                    if (updateok == false)
                    {
                        btupdate.Text = "原料不足";
                        btupdate.Enabled = false;
                    }
                }
                else
                {
                    btupdate.Text = "级别已经到上限";
                    btupdate.Enabled = false;
                    btupdate.Enabled = false;
                    lbhourneeded.Visible = false;
                    lbminuteneeded.Visible = false;
                    lbstoneneeded.Visible = false;
                    lbwoodneeded.Visible = false;
                    lbsecondcost.Visible = false;
                }
            }
            else if (Request.QueryString["building_type"] != null && Session["user_id"] != null && Request.QueryString["flag"] != null)
            {
                //首先判断级别有没有达到最高级

                string user_id = Session["user_id"].ToString().Trim();
                string building_type = Request.QueryString["building_type"].ToString().Trim();
                char charLevel = Char.Parse(building_type);
                int level = (charLevel - 'a') + 1;
                lbcurrentlevel.Text = level.ToString();
                //显示建筑升级所需要的材料
                if (Char.Parse(building_type) - 'j' < 0)
                {
                    displayBuildingInfo(building_type, user_id);
                    //判断升级按钮是不是能用
                    updateok = checkButtonEnable(user_id);
                    if (updateok == false)
                    {
                        btupdate.Text = "原料不足";
                        btupdate.Enabled = false;
                    }
                    else
                    {
                        btupdate.Text = "建筑建造升级中";
                        btupdate.Enabled = false;
                    }
                }
                else
                {
                    btupdate.Text = "级别已经到上限";
                    btupdate.Enabled = false;
                    lbcurrentlevel.Visible = false;
                    lbhourneeded.Visible = false;
                    lbminuteneeded.Visible = false;
                    lbstoneneeded.Visible = false;
                    lbwoodneeded.Visible = false;
                    lbsecondcost.Visible = false;
                }
            }
        }
        /// <summary>
        /// 此方法用来显示用户所选择的建筑的信息
        /// </summary>
        /// <param name="building_type">建筑的级别,为从上一个页面传过来的</param>
        /// <param name="user_id"></param>
        private void displayBuildingInfo(string building_type, string user_id)
        {
            string woodNeeded = "";
            string stoneNeeded = "";
            string timeNeeded = "";
            buildinginfo building = new buildinginfo();
            string char_building_type = ((char)(Char.Parse(building_type) + 1)).ToString(); ;
            int[] resources = building.GetResourcesNeeded(user_id, char_building_type, "2");
            if (resources.Length > 0)
            {
                woodNeeded = resources[0].ToString().Trim();
                stoneNeeded = resources[1].ToString().Trim();
                timeNeeded = resources[2].ToString().Trim();
            }
            int hourneeded = (Int32.Parse(timeNeeded)) / 60;
            int minute = (Int32.Parse(timeNeeded)) % 60;
            lbwoodneeded.Text = woodNeeded;
            lbstoneneeded.Text = stoneNeeded;
            lbhourneeded.Text = hourneeded.ToString().Trim();
            lbminuteneeded.Text = minute.ToString().Trim();
        }
        /// <summary>
        /// 此方法用来判断建住升级按钮的可用性
        /// </summary>
        /// <param name="user_id">用户的id</param>
        /// <returns></returns>
        private bool checkButtonEnable(string user_id)
        {
            int wood_count = 0;
            int stone_count = 0;
            string sql = "select wood_count,stone_count from player_resource where player_id='" + user_id + "'";
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
                Message.Show("你还没有登录", Response);
            }
            if (wood_count - Int32.Parse(lbwoodneeded.Text.ToString().Trim()) < 0 || stone_count - Int32.Parse(lbstoneneeded.Text.ToString().Trim()) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        protected void btupdate_Click(object sender, EventArgs e)
        {
            string user_id = "";
            string field_id = "";
            string building_id = "";
            if (Session["field_id"] != null && Session["user_id"] != null)
            {
                user_id = Session["user_id"].ToString().Trim();
                field_id = Session["field_id"].ToString().Trim();
                building_id = "2";
                Click.updataing_click(building_id, field_id, user_id);
                Response.Write("<script language='javascript'>window.parent.frames[0].location.reload();</script>");
                Response.Redirect("building_updated_requset.aspx?field_id=" + field_id + "&news=yes");
            }
            else
            {
                Message.Show("你还没有登录", Response);
            }
        }
    }
}