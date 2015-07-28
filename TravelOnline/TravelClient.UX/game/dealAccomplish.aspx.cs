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
    public partial class
        game_dealAccomplish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String type = Request["type"].ToString();
            String field_id = Session["field_id"].ToString();
            String player_id = Session["user_id"].ToString();
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            String selectSql = "";
            switch (type)
            {
                case "1":
                    selectSql = "select type_in_building from player_country where player_id='" + player_id + "'";
                    DataTable dt = dbo.SelectToDataTable(selectSql);
                    if (dt != null && dt.Rows.Count > 0)
                        Click.accomplishBuilding(dt.Rows[0]["type_in_building"].ToString(), field_id, player_id);
                    break;
                case "2":
                    Click.accomplishUpdate(field_id, player_id);
                    break;
                case "3":
                    Click.accomplishDevelop(field_id, player_id);
                    break;
                case "4":
                    Click.accomplishManufacture(field_id, player_id);
                    break;
            }
            dbo.CloseConnection();
        }
    }
}