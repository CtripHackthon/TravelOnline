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
    public partial class game_game_pocket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null || Session["country_x"] == null || Session["country_y"] == null)
            {
                Session["preAdd"] = "~/game/index_game.aspx";
                Response.Redirect("../Account/Login.aspx");
            }
            GetLetterCollected();
            if (Request["checked"] != null)
            {
                ComposeFormulaOrCpuInfo();
            }
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

        //产生研制配方后的新的letter_collected字段内容
        private string GetNewLetterField()
        {
            string re = "";
            if (Request["checked"] != null)
            {
                string selectedLetter = Request["checked"].Trim();
                string oldLetter = GetLetterCollected();
                re = HLString.StringClipping(oldLetter, selectedLetter);
            }
            return re;
        }

        //组装得到已经收集到的字母的sql语句
        private string AssembleGetLetterCollectedSQL()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select letter_collected letter_collected from player_resource where player_id=");
            re.Append("'");
            if (Session["user_id"] != null)
            {
                re.Append(Session["user_id"].ToString().Trim());
            }
            re.Append("'");
            return re.ToString();
        }

        //组装得到所有的cpu名称信息的sql语句
        private string AssembleGetAllCpuNameSQL()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select cpu_name from  cpu_info");
            return re.ToString();
        }

        //组装得到已经持有的cpu研制配方，或者已经持有的cpu制造配方的id集合的sql语句
        private string AssembleGetCpuIdInfoBySomeOne()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select formula_collected,cpu_collected from player_resource where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //组装根据cpu的名字得到cpu_id的sql语句
        private string AssembleGetCpuIdByCpuNameSort(string cpu_name)
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select cpu_id from cpu_info where cpu_name_sort=");
            re.Append("'");
            re.Append(cpu_name);
            re.Append("'");
            return re.ToString();
        }

        //组装得到formula信息的sql语句
        private string AssembleGetCpuFormulaField()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select formula_collected from player_resource where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //组装根据新合成的配方更新player_resource表的sql语句
        private string AssembleUpdateFormulaField(string newFormula)
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("update player_resource set formula_collected=");
            re.Append("'");
            re.Append(newFormula);
            re.Append("'");
            re.Append(" where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //组装产生新的配方后，更新已有的letter_collected字段的sql语句
        private string AssembleUpdateLetterField()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("update player_resource set letter_collected=");
            re.Append("'");
            re.Append(GetNewLetterField());
            re.Append("'");
            re.Append(" where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //得到已经收集到的字母
        private string GetLetterCollected()
        {
            string re = "";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = AssembleGetLetterCollectedSQL();
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                Session["collected"] = dt.Rows[0]["letter_collected"].ToString().Trim();
                re = dt.Rows[0]["letter_collected"].ToString().Trim();
            }
            return re;
        }

        //得到所有的cpu名称信息
        private string[] GetAllCpuName()
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = AssembleGetAllCpuNameSQL();
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            string[] re = new string[dt.Rows.Count];
            if (dt != null && dt.Rows != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    re.SetValue(dt.Rows[i]["cpu_name"].ToString().Trim(), i);
                }
            }
            return re;
        }

        //得到已经持有的cpu研制配方，或者已经持有的cpu制造配方的id集合
        private string GetCpuIdInfoBySomeOne()
        {
            string re = "";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = AssembleGetCpuIdInfoBySomeOne();
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["formula_collected"].ToString() != "")
                {
                    re += dt.Rows[0]["formula_collected"].ToString().Trim();
                }
                if (dt.Rows[0]["cpu_collected"].ToString() != "")
                {
                    re += dt.Rows[0]["cpu_collected"].ToString().Trim();
                }
            }
            return re;
        }

        //根据cpu的名字得到cpu_id
        private string GetCpuIdByCpuNameSort(string cpu_name)
        {
            string re = "";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = AssembleGetCpuIdByCpuNameSort(cpu_name);
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                re = dt.Rows[0]["cpu_id"].ToString().Trim();
            }
            return re;
        }

        //得到formula信息
        private string GetCpuFormulaField()
        {
            string re = "";
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = AssembleGetCpuFormulaField();
            DataTable dt = dbo.SelectToDataTable(sqlStr);
            dbo.CloseConnection();
            if (dt != null && dt.Rows.Count != 0)
            {
                re = dt.Rows[0]["formula_collected"].ToString().Trim();
            }
            return re;
        }

        //根据新合成的配方更新player_resource表
        private void UpdateFormulaField(string formula)
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string newFormula = GetCpuFormulaField() + formula;
            string sqlStr = AssembleUpdateFormulaField(newFormula);
            int re = dbo.UpdateDataBase(sqlStr);
            dbo.CloseConnection();
            if (re == 1)
            {
                //message show 合成成功
            }
        }

        //产生新的配方后，更新已有的letter_collected字段 
        private void UpdateLetterField()
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = AssembleUpdateLetterField();
            int re = dbo.UpdateDataBase(sqlStr);
            dbo.CloseConnection();
            if (re == 1)
            {
                //message show 合成成功
            }
        }

        //根据已选择的秘宝字母，检测是否能得到配方
        private string ValidFormula()
        {
            string re = "";
            int flag = 0;
            if (Request["checked"] != null)
            {
                re = Request["checked"].Trim();
                string[] allNames = GetAllCpuName();
                for (int i = 0; i < allNames.Length; i++)
                {
                    if (HLString.SortString(re) == HLString.SortString(allNames[i]))
                    {
                        flag = 1;
                        break;
                    }
                }
            }
            if (flag == 1)
            {
                re = Request["checked"].Trim();
            }
            else
            {
                re = "";
            }
            return re;
        }

        //如果已得到配方，查看是否已经存在此款cpu的研制配方或者是制造配方
        private bool ComposeFormulaOrCpuInfo()
        {
            bool re = true;
            string validFormula = ValidFormula();
            if (validFormula == "")
            {
                //合成失败，原因：与现有的芯片配方不一样
                Message.Show("合成失败，您所选中的字母不能合成任何配方。", Response);
            }
            else
            {
                string formula = GetCpuIdByCpuNameSort(HLString.SortString(validFormula));
                string formulaBySomeone = GetCpuIdInfoBySomeOne();
                if (-1 != formulaBySomeone.IndexOf(formula))
                {
                    //合成失败，原因：配方已存在
                    Message.Show("合成失败，您所选中的字母合成后的配方已存在。", Response);
                }
                else
                {
                    //合成成功，修改player_resource表
                    UpdateFormulaField(formula);
                    UpdateLetterField();
                    GetLetterCollected();
                    HLString.MessageBoxShow("恭喜，配方合成成功。", Response);
                }
            }
            return re;
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
                        if (dt_count != null && dt.Rows.Count != 0)
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


    }
}