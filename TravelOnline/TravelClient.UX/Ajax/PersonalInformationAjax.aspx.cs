using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelClient.UX.Ajax.Models;

namespace TravelClient.UX.Ajax
{
    public partial class PersonalInformationAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["requestType"] == "gettiles")
            {
                // Generate the tile information
                List<Tile> tiles = new List<Tile>() { 
                    new Tile(){ Id=1, ReportCount=56, TileName="我的游记"},
                     new Tile(){ Id=2, ReportCount=44, TileName="游记推荐"},
                    new Tile(){ Id=3, ReportCount=55, TileName="游记订阅"},
                    new Tile(){ Id=4, ReportCount=11, TileName="我的盈利"},
                    };

                // Serialize the data to client
                JavaScriptSerializer jss = new JavaScriptSerializer();

                string outPut = jss.Serialize(tiles);
                Response.Write(outPut);
            }
        }
    }
}