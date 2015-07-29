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
    public partial class game_market_update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                pageLoading();
                if (Session["user_id"] != null)
                {
                    string user_id = Session["user_id"].ToString().Trim();
                    refreshView(user_id);
                }
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

                string user_id = Session["user_id"].ToString().Trim();
                string building_type = Request.QueryString["building_type"].ToString().Trim();
                char charLevel = Char.Parse(building_type);
                int level = (charLevel - 'a') + 1;
                lbcurrentlevel.Text = level.ToString();
                //判断升级按钮是不是能用
                if (Char.Parse(building_type) - 'j' < 0)
                {

                    //显示建筑升级所需要的材料
                    displayBuildingInfo(building_type, user_id);
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
                    lbhourneeded.Visible = false;
                    lbminuteneeded.Visible = false;
                    lbstoneneeded.Visible = false;
                    lbwoodneeded.Visible = false;
                    lbsecondcost.Visible = false;
                }
            }
            else if (Request.QueryString["building_type"] != null && Session["user_id"] != null && Request.QueryString["flag"] != null)
            {
                string user_id = Session["user_id"].ToString().Trim();
                string building_type = Request.QueryString["building_type"].ToString().Trim();
                char charLevel = Char.Parse(building_type);
                int level = (charLevel - 'a') + 1;
                lbcurrentlevel.Text = level.ToString();
                //显示建筑升级所需要的材料
                if (Char.Parse(building_type) - 'j' < 0)
                {

                    //显示建筑升级所需要的材料
                    displayBuildingInfo(building_type, user_id);
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
            int[] resources = building.GetResourcesNeeded(user_id, char_building_type, "4");
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
        protected void gvchipdetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int race = 0;
                if (Session["user_id"] != null && Session["field_id"] != null)
                {
                    string user_id = Session["user_id"].ToString().Trim();
                    int field_id = 4;
                    race = getRace(user_id);

                    loadChipMessage(user_id, field_id, e, race);
                    loadButtonMessage(user_id, field_id, e);
                }
                else
                {
                    Message.Show("你还没有登陆", Response);
                }
            }
        }
        /// <summary>
        /// 该方法得到玩家的种族
        /// </summary>
        /// <param name="user_id">用户名</param>
        /// <returns>1代表金脉龙族，2=绯颜龙族 3=紫麟龙族 4=青岚龙族 </returns>
        private int getRace(string user_id)
        {
            int race = 0;
            string sql = "select player_race from player_country where player_id='" + user_id + "'";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                race = Int32.Parse(dt.Rows[0][0].ToString().Trim());
                return race;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 本方法用来加载芯片配方的信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="field_id"></param>
        private void loadChipMessage(string user_id, int field_id, GridViewRowEventArgs e, int race)
        {
            string level = lbcurrentlevel.Text.ToString().Trim();
            Label chipname = (Label)e.Row.Cells[0].FindControl("lbchipname") as Label;
            Image chippicture = (Image)e.Row.Cells[0].FindControl("imchip") as Image;
            Label eachcost = (Label)e.Row.Cells[0].FindControl("lbeachcost") as Label;
            TextBox chipnumber = (TextBox)e.Row.Cells[0].FindControl("tbsalecount") as TextBox;
            Label totalnumber = (Label)e.Row.Cells[0].FindControl("lbtotalnumber") as Label;
            totalnumber.Text = getChipNumber(user_id, e).ToString();
            chipname.Text = DataBinder.Eval(e.Row.DataItem, "cpu_title").ToString().Trim();
            chippicture.ImageUrl = DataBinder.Eval(e.Row.DataItem, "cpu_img").ToString().Trim();
            eachcost.Text = DataBinder.Eval(e.Row.DataItem, "cpu_value").ToString().Trim();
        }
        /// <summary>
        /// 本方法得到当前用户已有的cpu数目
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        private int getChipNumber(string user_id, GridViewRowEventArgs e)
        {
            string sql = "select cpu_count from player_cpu where player_id='" + user_id + "' and cpu_id='" + DataBinder.Eval(e.Row.DataItem, "cpu_id").ToString().Trim() + "'";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count > 0)
            {
                int i = Int32.Parse(dt.Rows[0][0].ToString().Trim());
                return i;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 本方法用来加载按钮，状态有“生产”、“研发中”、“龙币不足”三种
        /// </summary>
        /// <param name="user_id">用户名</param>
        /// <param name="field_id">地块名</param>
        private void loadButtonMessage(string user_id, int field_id, GridViewRowEventArgs e)
        {
            string field = "";
            bool is_in_building = false;
            bool result = false;
            checkbuildingstate check = new checkbuildingstate();
            Button start = (Button)e.Row.Cells[0].FindControl("btsale") as Button;
            TextBox tb = (TextBox)e.Row.Cells[0].FindControl("tbsalecount") as TextBox;
            if (Session["field_id"] != null)
            {
                field = Session["field_id"].ToString().Trim();
                if (Request.QueryString["flag"] != null)
                {
                    //有建筑正在升级或者建筑中看一下这个升级或者建筑中的建筑是不是当前的建筑
                    //如果是则当前的建筑内不能生产，否则就能够再生产
                    is_in_building = check.checkBuildingUpdate(user_id, field);
                    if (is_in_building)
                    {
                        start.Enabled = false;
                        start.Text = "建筑建造升级中";
                    }
                    else
                    {
                        start.CommandArgument = DataBinder.Eval(e.Row.DataItem, "cpu_id").ToString().Trim();
                        start.ToolTip = e.Row.RowIndex.ToString();
                    }
                }
                else
                {
                    //判断该建筑中是不是还在生产或者研发什么东西
                    result = check.checkWorkContent(user_id, field);
                    if (result)
                    {
                        //没有在生产的东西
                        //看金币的数目是不是0
                        start.CommandArgument = DataBinder.Eval(e.Row.DataItem, "cpu_id").ToString().Trim();
                        start.ToolTip = e.Row.RowIndex.ToString();
                    }
                    else
                    {
                        start.Text = "生产中";
                        start.Enabled = false;
                    }
                }
            }
            else
            {
                Message.Show("你还没有选择村庄", Response);
            }
        }
        /// <summary>
        /// 方法用来加载数据到gridview中
        /// </summary>
        /// <param name="user_id"></param>
        private void refreshView(string user_id)
        {
            string sql = "select * from cpu_info where cpu_id in (select cpu_id from player_cpu where player_id='" + user_id + "' and cpu_count!=0)";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DataTable dt = dbo.SelectToDataTable(sql);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count > 0)
            {
                gvchipdetail.DataSource = dt;
                gvchipdetail.DataBind();
            }
            else
            {
                gvchipdetail.DataSource = null;
                gvchipdetail.DataBind();
            }
        }
        protected void btsale_Click(object sender, EventArgs e)
        {

            Button bt = (Button)sender;
            TextBox tb = (TextBox)gvchipdetail.Rows[Convert.ToInt32(bt.ToolTip)].FindControl("tbsalecount") as TextBox;
            string cpu_id = bt.CommandArgument.ToString().Trim();
            string user_id = "";
            string field_id = "";
            string building_id = "";
            string test = tb.Text.ToString().Trim();
            int num = 0;
            if (Session["field_id"] != null && Session["user_id"] != null)
            {
                if (tb.Text == "")
                {
                    Message.Show("请输入整数", Response);
                    return;
                }
                else
                {
                    for (int i = 0; i <= test.Length - 1; i++)
                    {
                        int j = 0;
                        try
                        {
                            j = Int32.Parse(test[i].ToString());
                        }
                        catch (Exception es)
                        {
                            Message.Show("请输入整数", Response);
                            return;
                        }
                    }
                }
                user_id = Session["user_id"].ToString().Trim();
                field_id = Session["field_id"].ToString().Trim();
                building_id = "4";
                num = Convert.ToInt32(test);
                Message.Show(Click.saleCpu(cpu_id, num, field_id, user_id), Response);
                refreshView(user_id);
            }
            else
            {
                Message.Show("你还没有登录", Response);
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
                building_id = "4";
                Click.updataing_click(building_id, field_id, user_id);
                Response.Redirect("building_updated_requset.aspx?field_id=" + field_id + "&news=yes");
            }
            else
            {
                Message.Show("你还没有登录", Response);
            }
        }
    }
}