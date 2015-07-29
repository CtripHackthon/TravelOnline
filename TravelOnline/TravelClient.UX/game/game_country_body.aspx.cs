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
    public partial class game_game_country_body : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //建筑在升级或是建设中的建筑已完成，则更新数据库
           IsConstructOrUpdateStatusOK();
        }

        //组装得到当前在建设中的或是升级中的建筑的完成时间
        private string AssembleGetEofDt()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select player_id,is_in_building,field_type,type_in_building,eof_dt from player_country where is_in_building !='0' and player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //组装从数据表中提取20块地格的信息
        private string AssemblePartInfoPickUp()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select player_id,field_type,field_level from player_country where country_x=");
            re.Append(Convert.ToInt32(Session["country_x"].ToString().Trim()));
            re.Append(" and country_y=");
            re.Append(Convert.ToInt32(Session["country_y"].ToString().Trim()));
            return re.ToString();
        }

        //组装从建筑图片表中得到建筑的图片信息
        private string AssembleGetBuildingImg(string building_id, string building_level)
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select img_location from building_img where building_id=");
            re.Append("'");
            re.Append(building_id);
            re.Append("' and building_level=");
            re.Append("'");
            re.Append(building_level);
            re.Append("'");
            return re.ToString();
        }

        //从数据表中提取20块地格的信息
        protected void PartInfoPickUp()
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = AssemblePartInfoPickUp();
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            if (dt != null && dt.Rows.Count != 0)
            {
                string field_type = "";
                string field_level = "";
                for (int i = 0; i < dt.Rows[0]["field_type"].ToString().Trim().Length; i++)
                {
                    field_type = HLString.StringPickUp(dt.Rows[0]["field_type"].ToString().Trim(), i);
                    field_level = HLString.StringPickUp(dt.Rows[0]["field_level"].ToString().Trim(), i);
                    sqlStr = AssembleGetBuildingImg(field_type, field_level);
                    DataTable dt_building_img = dbo.SelectToDataTable(sqlStr);
                    if (dt_building_img != null && dt_building_img.Rows.Count != 0)
                    {
                        //用户村庄判断
                        if (dt.Rows[0]["player_id"].ToString().Trim() == Session["user_id"].ToString().Trim())
                        {
                            //此村庄是玩家的村庄
                            HLString.SetInnerHTMLValue(((char)('a' + i)).ToString(), "<div style=\"position: relative;top: 0px;left: 0px;Z-INDEX:11;\" onclick=\"Wave(" + (i + 1) + ");\" ><a href=\"field_type_request.aspx?field_id=" + (char)('a' + i) + "\" target=\"rightFrame\"><img src=\"images/touming.gif\" width=\"66\" height=\"68\" STYLE=\"cursor:hand;Z-INDEX: 11;position:absolute;top: 0px;left: 0px;\" border=\"0\"></a></div>" + dt_building_img.Rows[0]["img_location"].ToString().Trim(), Response);
                        }
                        else
                        {
                            //此村庄不是玩家的村庄
                            HLString.SetInnerHTMLValue(((char)('a' + i)).ToString(), "<div style=\"position: relative;top: 0px;left: 0px;Z-INDEX:11;\"></div>" + dt_building_img.Rows[0]["img_location"].ToString().Trim(), Response);
                        }
                    }
                }
            }
            dbo.CloseConnection();
        }

        //若是否有建筑在升级或是建设中的建筑已完成，则更新数据库
        private void IsConstructOrUpdateStatusOK()
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DateTime currentTime = DateTime.Now;
            string sqlStr = AssembleGetEofDt();
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                if (currentTime >= Convert.ToDateTime((dt.Rows[0]["eof_dt"].ToString().Trim())))
                {
                    if (dt.Rows[0]["field_type"].ToString().Trim().Substring(dt.Rows[0]["is_in_building"].ToString()[0] - 'a', 1) == "0")
                    {
                        Click.accomplishBuilding(dt.Rows[0]["type_in_building"].ToString().Trim(), dt.Rows[0]["is_in_building"].ToString().Trim(), dt.Rows[0]["player_id"].ToString().Trim());
                    }
                    else
                    {
                        Click.accomplishUpdate(dt.Rows[0]["is_in_building"].ToString().Trim(), dt.Rows[0]["player_id"].ToString().Trim());
                    }
                }
            }
        }

        //若是否有建筑在升级或是建设中的建筑未完成，则更新建设中的图片图标
        protected void ConstructingOrUpdating()
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            DateTime currentTime = DateTime.Now;
            string sqlStr = AssembleGetEofDt();
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            if (dt != null && dt.Rows.Count != 0)
            {
                if (currentTime < Convert.ToDateTime((dt.Rows[0]["eof_dt"].ToString().Trim())))
                {
                    //用户村庄判断
                    if (dt.Rows[0]["player_id"].ToString().Trim() == Session["user_id"].ToString().Trim())
                    {
                        //此村庄是玩家的村庄
                        HLString.SetInnerHTMLValue(dt.Rows[0]["is_in_building"].ToString().Trim(), "<div style=\"position: relative;top: 0px;left: 0px;Z-INDEX:11;\" onclick=\"Wave(" + ((dt.Rows[0]["is_in_building"].ToString()[0]) - 'a' + 1) + ");\" ><a href=\"field_type_request.aspx?field_id=" + dt.Rows[0]["is_in_building"].ToString().Trim() + "\" target=\"rightFrame\"><img src=\"images/touming.gif\" width=\"66\" height=\"68\" STYLE=\"cursor:hand;Z-INDEX: 11;position:absolute;top: 0px;left: 0px;\" border=\"0\"></a></div><object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" width=\"66\" height=\"68\"><param name=\"movie\" value=\"images/build/ing.swf\" /><param name=\"quality\" value=\"high\" /><param name=\"wmode\" value=\"transparent\" /><embed src=\"images/build/ing.swf\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"66\" height=\"68\" wmode=\"transparent\"></embed></object>", Response);
                    }
                    else
                    {
                        //此村庄不是玩家的村庄
                        HLString.SetInnerHTMLValue(dt.Rows[0]["is_in_building"].ToString().Trim(), "<div style=\"position: relative;top: 0px;left: 0px;Z-INDEX:11;\"></div><object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" width=\"66\" height=\"68\"><param name=\"movie\" value=\"images/build/ing.swf\" /><param name=\"quality\" value=\"high\" /><param name=\"wmode\" value=\"transparent\" /></object>", Response);
                    }
                }
            }
            dbo.CloseConnection();
        }

    }
}