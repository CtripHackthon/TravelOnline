using System;
using System.Data;
using System.Text;
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
    /// <summary>
    /// 根据相应坐标加载地图信息，显示不同的地表风貌
    /// </summary>
    public partial class game_game_map : System.Web.UI.Page
    {

        private DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
        private Int32 a = 0;
        private Int32[] b = new Int32[] { 10, 20, 30, 40, 50, 60 };

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user_id"] == null || Session["country_x"] == null || Session["country_y"] == null)
            //{
            //    Session["preAdd"] = "~/game/index_game.aspx";
            //    Response.Redirect("../Account/Login.aspx");
            //}
            LoadMap();
            loadPage();
            GetPlayerCurrentWoodStoneMoney();
            GetPlayerTotalWoodStone();
        }

        //组装显示玩家的木材数，石头数，金币数
        private string AssembleGetPlayerCurrentWoodStoneMoney()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select wood_count,stone_count,money_count from player_resource where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //组装特定级别建筑的容纳木材和石头的能力
        private string AssembleGetWoodStoneCount(string building_id, string building_level)
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select stored_wood_count,stored_stone_count from building_ability where building_id=");
            re.Append("'");
            re.Append(building_id);
            re.Append("' and building_level=");
            re.Append("'");
            re.Append(building_level);
            re.Append("'");
            return re.ToString();
        }

        //组装显示玩家的仓库能容纳的木材总数，石头总数
        private string AssembleGetPlayerTotalWoodStone()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select field_type,field_level from player_country where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //玩家进入的是自己的村庄时，显示玩家的木材数，石头数，金币数
        private void GetPlayerCurrentWoodStoneMoney()
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = AssembleGetPlayerCurrentWoodStoneMoney();
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                lbCurrentWoodCount.Text = dt.Rows[0]["wood_count"].ToString().Trim();
                lbCurrentStoneCount.Text = dt.Rows[0]["stone_count"].ToString().Trim();
                lbCurrentMoneyCount.Text = dt.Rows[0]["money_count"].ToString().Trim();
            }
        }

        //玩家进入的是自己的村庄时，显示玩家的仓库能容纳的木材总数，石头总数
        private void GetPlayerTotalWoodStone()
        {
            int sum_wood = 0;
            int sum_stone = 0;
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = AssembleGetPlayerTotalWoodStone();
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows[0]["field_type"].ToString().Trim().Length; i++)
                {
                    if (HLString.StringPickUp(dt.Rows[0]["field_type"].ToString().Trim(), i) == "2")
                    {
                        sqlStr = AssembleGetWoodStoneCount(HLString.StringPickUp(dt.Rows[0]["field_type"].ToString().Trim(), i), HLString.StringPickUp(dt.Rows[0]["field_level"].ToString().Trim(), i));
                        DataTable dt_count = dbo.SelectToDataTable(sqlStr);
                        if (dt_count != null && dt_count.Rows.Count != 0)
                        {
                            sum_wood += Convert.ToInt32(dt_count.Rows[0]["stored_wood_count"].ToString().Trim());
                            sum_stone += Convert.ToInt32(dt_count.Rows[0]["stored_stone_count"].ToString().Trim());
                        }
                    }
                }
            }
            dbo.CloseConnection();
            lbTotalWoodCount.Text = sum_wood.ToString();
            lbTotalStoneCount.Text = sum_stone.ToString();
        }
        /// <summary>
        /// 页面加载时根据不同情况加载地图信息，若有坐标信息，加载坐标指定的位置，若没有坐标信息，则以用户村庄为坐标加载地图
        /// </summary>
        public void LoadMap()
        {
            if (Request.QueryString["country_x"] != null && Request.QueryString["country_y"] != null)
            {
                FillContent(Convert.ToInt32(Request.QueryString["country_x"]), Convert.ToInt32(Request.QueryString["country_y"]));
            }
            else
            {
                if (Session["country_x"] != null && Session["country_y"] != null)
                {
                    FillContent(Convert.ToInt32(Session["country_x"].ToString().Trim()), Convert.ToInt32(Session["country_y"].ToString().Trim()));
                }
                else if (Session["user_id"] != null)
                {
                    DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
                    dbo.Connect();
                    String user_name = Session["user_id"].ToString();
                    DataTable dt = dbo.SelectToDataTable("select country_x,country_y from map where player_id='" + user_name + "'");
                    FillContent(Convert.ToInt32(dt.Rows[0]["country_x"]), Convert.ToInt32(dt.Rows[0]["country_y"]));
                }
            }
            Click.Response_To(Request.QueryString["yu"], Response);
        }
        /// <summary>
        /// 填充地图内容
        /// </summary>
        /// <param name="x">中心位置x坐标</param>
        /// <param name="y">中心位置y坐标</param>
        public void FillContent(Int32 x, Int32 y)
        {
            dbo.Connect();
            if (x < 4)
                x = 4;
            if (x > 997)
                x = 997;
            if (y < 4)
                y = 4;
            if (y > 997)
                y = 997;
            DataTable dt = new DataTable();
            StringBuilder innerH = new StringBuilder();
            Int32[,] list = new int[,] { { -3, -3 }, { -3, -2 }, { -2, -3 }, { -3, -1 }, { -2, -2 }, { -1, -3 }, { -3, 0 }, 
                                     { -2, -1 }, { -1, -2 }, { 0, -3 }, { -3, 1 }, { -2, 0 }, { -1, -1 }, { 0, -2 }, 
                                     { 1, -3 }, { -3, 2 }, { -2, 1 }, { -1, 0 }, { 0, -1 }, { 1, -2 }, { 2, -3 }, 
                                     { -3, 3 }, { -2, 2 }, { -1, 1 }, { 0, 0 }, { 1, -1 }, { 2, -2 }, { 3, -3 },
                                     { -2, 3 }, { -1, 2 }, { 0, 1 }, { 1, 0 }, { 2, -1 }, { 3, -2 }, { -1, 3 }, 
                                     { 0, 2 }, { 1, 1 }, { 2, 0 }, { 3, -1 }, { 0, 3 }, { 1, 2 }, { 2, 1 }, 
                                     { 3, 0 }, { 1, 3 }, { 2, 2 }, { 3, 1 }, { 2, 3 }, { 3, 2 }, { 3,3} };//由于页面中的图为菱形，此数组作用在于将数据库中信息与页面相结合
            Int32[] change = { 1, 8, 2, 15, 9, 3, 22, 16, 10, 4, 29, 23, 17, 11, 5, 36, 30, 24, 18, 12, 6, 43, 37, 31, 25, 19, 13, 7, 44, 38, 32, 26, 20, 14, 45, 39, 33, 27, 21, 46, 40, 34, 28, 47, 41, 35, 48, 42, 49 };//确定地图相应地块class属性
            innerH.Append("<ul>");
            for (Int32 num = 0; num < 49; num++)
            {
                dt = Get_Field_Info(x + list[num, 0], y + list[num, 1]);
                Int32 type = Convert.ToInt32(dt.Rows[0]["map_field_type"]);
                String fieldType = GetPic(type, x + list[num, 0], y + list[num, 1]);
                String temp = "";
                innerH.Append("<li class=\"p");
                innerH.Append(num + 1);
                innerH.Append("\">");
                innerH.Append("<div><div style=\"position: relative;top: 0px;left: 0px;Z-INDEX:11;\"><a href=\"game_map.aspx?");
                innerH.Append("country_x=");
                innerH.Append(x + list[num, 0]);
                innerH.Append("&");
                innerH.Append("country_y=");
                innerH.Append(y + list[num, 1]);
                innerH.Append("\" id=\"a");
                innerH.Append(change[num]);
                innerH.Append("\" onclick=\"return click1();\"><img src='images/testheight.gif' width='45' height='36' STYLE='cursor:hand;Z-INDEX: 11;position:absolute;' border=\"0\" alt=\"");
                if (type == 1)
                {
                    dt = dbo.SelectToDataTable("select player_id from player_country where country_x=" + (x + list[num, 0]) + " and country_y=" + (y + list[num, 1]) + "");
                    if (dt.Rows[0]["player_id"].ToString() == Session["user_id"].ToString().Trim())
                    {
                        temp = "进入自己的村庄看一下啊";
                    }
                    else
                    {
                        temp = dt.Rows[0]["player_id"].ToString();
                        temp += "的村庄，进去拜访一下啊";
                    }
                }
                else
                {
                    temp = Get_field_type(type);
                }
                innerH.Append(temp);
                innerH.Append("\" title=\"" + temp + "\"");
                innerH.Append("\" id=\"img");
                innerH.Append(change[num]);
                innerH.Append("\"></a></div>");
                innerH.Append("<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" width=\"45\" height=\"36\">");
                innerH.Append("<param name=\"movie\" value=\"images/map/M");
                innerH.Append(fieldType);
                innerH.Append(".swf\" />");
                innerH.Append("<param name=\"quality\" value=\"high\" />");
                innerH.Append("<param name=\"wmode\" value=\"transparent\" />");
                innerH.Append("<embed src=\"images/map/M");
                innerH.Append(fieldType);
                innerH.Append(".swf\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"45\" height=\"36\" wmode=\"transparent\"></embed>");
                innerH.Append("</object></div></li>\n");

            }
            innerH.Append("</ul>");
            map_pic.InnerHtml = innerH.ToString();

            dbo.CloseConnection();
        }
        /// <summary>
        /// 得到指定地块的信息
        /// </summary>
        /// <param name="x">地块x坐标</param>
        /// <param name="y">地块y坐标</param>
        /// <returns>包含地块相应信息的datatable</returns>
        public DataTable Get_Field_Info(Int32 x, Int32 y)
        {

            DataTable dt;
            String queryString = "select map_field_type,player_id from map where country_x=" + x + " and country_y=" + y + "";
            dt = dbo.SelectToDataTable(queryString);
            return dt;
        }
        /// <summary>
        /// 辅助产生相应地块类型所对应的图片
        /// </summary>
        /// <param name="type">地块类型</param>
        /// <param name="x">地块x坐标</param>
        /// <param name="y">地块y坐标，</param>
        /// <returns></returns>
        public String GetPic(Int32 type, Int32 x, Int32 y)
        {
            String[,] fieldType = new String[,] { { "13", "13", "13" }, { "03", "03", "03" }, { "07", "09", "10" }, { "02", "04", "05" }, { "08", "11", "12" } };
            return fieldType[type, (x + y * 2) % 3];//根据坐标随即产生一个图片序号
        }
        /// <summary>
        /// 根据地块id不同，产生相应的提示信息
        /// </summary>
        /// <param name="id">地块id</param>
        /// <returns>相应提示信息</returns>
        public String Get_field_type(Int32 id)
        {
            String type = "";
            switch (id)
            {
                case 0:
                    type = "空地";
                    break;
                case 1:
                    type = "村庄";
                    break;
                case 2:
                    type = "森林,在这里有机会找到木材";
                    break;
                case 3:
                    type = "矿山，里面有丰富的石料";
                    break;
                case 4:
                    type = "藏宝洞，说不定有你想要的秘宝";
                    break;
            }
            return type;
        }

        private void loadPage()
        {
            if (Request.QueryString["country_x"] != null && Request.QueryString["country_y"] != null)
            {
                //就是说这是本页面上用户点击了地形后传过来的
                loadExporingMessage();
            }
            else
            {
                //显示访问村庄的情况
                loadVisitCountryMessage();
            }
        }
        /// <summary>
        /// 本方法纯粹是为了结构清晰
        /// </summary>
        private void loadVisitCountryMessage()
        {
            string visit_list = ""; ;
            string visit_countryMessage = "";
            bool sameuser = false;
            bool visit_succed = false;
            int country_x = 0;
            int country_y = 0;
            string user_id = "";
            string from_country = "";
            //这是从其他页面比如说从自己村庄回来的，从别人村庄回来的。或者是从点击了本页的地图超链接传过来的
            if (Session["country_x"] != null && Session["country_y"] != null && Session["user_id"] != null)
            {
                //先来判断这个用户是谁？是不是当前这个用户,如果是的话就清空出行记录‘
                user_id = Session["user_id"].ToString().Trim();
                country_x = Int32.Parse(Session["country_x"].ToString().Trim());
                country_y = Int32.Parse(Session["country_y"].ToString().Trim());
                sameuser = player_activity.sameUser(user_id, country_x, country_y);
                if (sameuser)
                {
                    //是同一个用户，清空数据库
                    //这地方有一个问题，就是说如果这个用户点击了地图超链接后如果是同一个用户出行记录被清空如果不是同一个用户的画布清空吗？
                    if (Request.QueryString["flag"] != null)
                    {
                        //是地图超链接会发过来的
                        DataTable dt = player_activity.getActivityRecord(user_id);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                visit_list += dr[0].ToString().Trim();
                            }
                        }
                        ltactivity.Text = visit_list;
                    }
                    else
                    {
                        //清空出行记录
                        bool right = player_activity.deleteRecord(user_id);
                    }
                }
                else
                {
                    //不是同一个用户代表这是从其他村庄转过来的
                    //同样是不是从本页点击地图进来的吗？
                    if (Request.QueryString["flag"] != null)
                    {
                        DataTable dt = player_activity.getActivityRecord(user_id);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                visit_list += dr[0].ToString().Trim();
                            }
                        }
                        ltactivity.Text = visit_list;
                    }
                    else
                    {
                        // 将出行到的村庄的信息显示出来
                        from_country = player_activity.fromCountryMessage(country_x, country_y);
                        visit_countryMessage = "你从" + from_country + "的村庄回来<br>";
                        //插入行动成功
                        visit_succed = player_activity.visitActivityWrite(user_id, visit_countryMessage);
                        if (visit_succed)
                        {
                            //将行动日志load 出来
                            DataTable dt1 = player_activity.getActivityRecord(user_id);
                            if (dt1 != null && dt1.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt1.Rows)
                                {
                                    visit_list += dr[0].ToString().Trim();
                                }
                            }
                            ltactivity.Text = visit_list;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 本方法也是纯粹为了结构清晰
        /// </summary>
        private void loadExporingMessage()
        {
            string content = "";
            string random = "";
            bool visit_succed = false;
            int country_x = 0;
            int country_y = 0;
            string user_id = "";
            string field_type = "";//用户点击的地形是什么？
            if (Session["user_id"] != null)
            {
                user_id = Session["user_id"].ToString().Trim();
                if (Request.QueryString["random"] != null)
                {
                    random = Request.QueryString["random"].ToString().Trim();
                }
                else
                {
                    random = "0";
                }
                country_x = Int32.Parse(Request.QueryString["country_x"].ToString().Trim());
                country_y = Int32.Parse(Request.QueryString["country_y"].ToString().Trim());
                // 先判断该用户的点击来自的地形是什么
                field_type = player_activity.getFieldType(country_x, country_y);
                if (field_type == "0")
                {
                    //来到一片空地,插入行动日志
                    if (random != "0")
                    {
                        content = "你掷出的点数:" + random + "<br>你来到一片空地<br>";
                    }
                    else
                    {
                        content = "你没有掷骰子<br>";
                    }
                    visit_succed = player_activity.visitActivityWrite(user_id, content);
                    if (visit_succed)
                    {
                        //重新load一便数据
                        DataTable dt = player_activity.getActivityRecord(user_id);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ltactivity.Text += dr[0].ToString().Trim();
                            }
                        }
                    }

                }
                else if (field_type == "1")
                {
                    //用户点击的是村庄
                    loadCountry(country_x, country_y, user_id);

                }
                else if (field_type == "2")
                {
                    //用户点击的是森林
                    loadForestMessage(user_id, random);
                }
                else if (field_type == "3")
                {
                    //用户点击的是矿山
                    loadCoralMessage(user_id, random);
                }
                else
                {
                    //用户点击的是藏宝洞
                    loadCoinRoom(user_id, random);
                }
            }
        }
        /// <summary>
        /// 当用户点击的是村庄
        /// </summary>
        /// <param name="country_x">村庄横坐标</param>
        /// <param name="country_y">村庄纵坐标</param>
        /// <param name="user_id">用户id</param>
        private void loadCountry(int country_x, int country_y, string user_id)
        {
            string random = "";
            string content = "";
            bool is_myCountry = false;
            Session["country_x"] = country_x;
            Session["country_y"] = country_y;
            //判断这个村庄是不是自己的村庄
            is_myCountry = player_activity.sameUser(user_id, country_x, country_y);
            if (is_myCountry)
            {
                //是我的村庄
                Response.Redirect("game_country.aspx");
            }
            else
            {
                //是别人的村庄
                //进入别人村庄之前写入出行日志
                if (Request.QueryString["random"] != null)
                {
                    random = Request.QueryString["random"].ToString().Trim();
                }
                else
                {
                    random = "0";
                }

                //content = "你掷出的点数:" + random + "</br>";
                //visit_succed = player_activity.visitActivityWrite(user_id, content);
                if (random != "0")
                {
                    Response.Redirect("game_country_others.aspx");
                }
                else
                {
                    content = "你没有掷骰子<br>";
                    bool can_write_activity = player_activity.visitActivityWrite(user_id, content);
                    if (can_write_activity)
                    {
                        //将记录load出来
                        DataTable dt = player_activity.getActivityRecord(user_id);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ltactivity.Text += dr[0].ToString().Trim();
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 当用户点进的是一片森林
        /// </summary>
        private void loadForestMessage(string user_id, string random)
        {
            int[] current_resource = { 0, 0 };
            int current_wood = 0;
            int[] maxresource = { 0, 0 };
            int maxwood = 0;
            DataTable dt = null;
            string content = "";
            string top_level = "";
            int wood_get = 0;
            bool can_write_resource = true;
            bool can_write_activity = true;
            if (random != "0")
            {
                maxresource = player_activity.getMaxStorage(user_id);
                maxwood = maxresource[0];
                current_resource = getCurrentResource(user_id);
                current_wood = current_resource[0];
                if (current_wood < maxwood)
                {
                    top_level = player_activity.getPlayerTopLevel(user_id);
                    wood_get = player_activity.getResourceAquired(top_level);
                    content = "你掷出的点数:" + random + "<br>你来到一片森林获得了" + wood_get + "的木材<br>";
                    can_write_resource = player_activity.writeResourceToDb(user_id, wood_get, 0);
                }
                else
                {
                    content = "你掷出的点数:" + random + "<br>你来到一片森林,但是仓库已满所以不能得到一点木材<br>";
                }
                can_write_activity = player_activity.visitActivityWrite(user_id, content);
                if (can_write_activity)
                {
                    //将记录load出来
                    dt = player_activity.getActivityRecord(user_id);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            ltactivity.Text += dr[0].ToString().Trim();
                        }
                    }
                }
            }
            else
            {
                //原地踏步
                content = "你没有掷骰子<br>";
                can_write_activity = player_activity.visitActivityWrite(user_id, content);
                if (can_write_activity)
                {
                    //将记录load出来
                    dt = player_activity.getActivityRecord(user_id);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            ltactivity.Text += dr[0].ToString().Trim();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 用户点进的是一座矿山
        /// </summary>
        private void loadCoralMessage(string user_id, string random)
        {
            int[] current_resource = { 0, 0 };
            int current_stone = 0;
            int[] maxresource = { 0, 0 };
            int maxstone = 0;
            //可以得到矿石
            DataTable dt = null;
            string content = "";
            string top_level = "";
            int stone_get = 0;
            bool can_write_resource = true;
            bool can_write_activity = true;
            //首先看着次进入森林获取树木是否成功
            if (random != "0")
            {
                maxresource = player_activity.getMaxStorage(user_id);
                maxstone = maxresource[1];
                current_resource = getCurrentResource(user_id);
                current_stone = current_resource[1];
                if (current_stone < maxstone)
                {
                    top_level = player_activity.getPlayerTopLevel(user_id);
                    stone_get = player_activity.getResourceAquired(top_level);
                    content = "你掷出的点数:" + random + "<br>你来到一片采石厂,获得了" + stone_get + "的石材<br>";
                    can_write_resource = player_activity.writeResourceToDb(user_id, 0, stone_get);
                }
                else
                {
                    content = "你掷出的点数:" + random + "<br>你来到一片采石厂,但是仓库已满所以不能得到一点石材<br>";
                }
                can_write_activity = player_activity.visitActivityWrite(user_id, content);
                if (can_write_activity)
                {
                    //将记录load出来
                    dt = player_activity.getActivityRecord(user_id);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            ltactivity.Text += dr[0].ToString().Trim();
                        }
                    }
                }
            }
            else
            {
                content = "你没有掷骰子<br>";
                can_write_activity = player_activity.visitActivityWrite(user_id, content);
                if (can_write_activity)
                {
                    //将记录load出来
                    dt = player_activity.getActivityRecord(user_id);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            ltactivity.Text += dr[0].ToString().Trim();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 用户点金的是一个藏宝洞
        /// </summary>
        private void loadCoinRoom(string user_id, string random)
        {
            bool can_getCoin = true;//这次进来能见到字母？
            bool can_write_coin = true;
            bool can_write_activity = true;
            string letter_get = "";
            string content = "";
            DataTable dt = null;
            can_getCoin = player_activity.getRandomRate();
            if (can_getCoin)
            {
                //本次能得到密宝
                letter_get = player_activity.getLetterAquired();
                //将行动写入activity_record
                if (random != "0")
                {
                    //将得到的密保写入表player_resource
                    can_write_coin = player_activity.writeLetterToDb(letter_get, user_id);
                    content = "你掷出的点数:" + random + "<br>你来到一片山洞,恭喜你获得秘宝一枚<br>";
                    can_write_activity = player_activity.visitActivityWrite(user_id, content);
                    if (can_write_activity)
                    {
                        dt = player_activity.getActivityRecord(user_id);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ltactivity.Text += dr[0].ToString().Trim();
                            }
                        }
                    }
                }
                else
                {
                    content = "你没有掷骰子<br>";
                    can_write_activity = player_activity.visitActivityWrite(user_id, content);
                    if (can_write_activity)
                    {
                        dt = player_activity.getActivityRecord(user_id);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ltactivity.Text += dr[0].ToString().Trim();
                            }
                        }
                    }
                }

            }
            else
            {
                if (random != "0")
                {
                    //这次什么也没有得到
                    content = "你掷出的点数:" + random + "<br>你来到一片山洞,可惜你什么也没得到<br>";
                    can_write_activity = player_activity.visitActivityWrite(user_id, content);
                    if (can_write_activity)
                    {
                        //将记录load出来
                        dt = player_activity.getActivityRecord(user_id);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ltactivity.Text += dr[0].ToString().Trim();
                            }
                        }
                    }
                }
                else
                {
                    content = "你没有掷骰子<br>";
                    can_write_activity = player_activity.visitActivityWrite(user_id, content);
                    if (can_write_activity)
                    {
                        dt = player_activity.getActivityRecord(user_id);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ltactivity.Text += dr[0].ToString().Trim();
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 得到目前的仓库储量
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        private int[] getCurrentResource(string user_id)
        {
            int[] resource = { 0, 0 };
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
            resource[0] = wood_count;
            resource[1] = stone_count;
            return resource;
        }
    }
}