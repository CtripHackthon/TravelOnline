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

        //��װ��ʾ��ҵ�ľ������ʯͷ���������
        private string AssembleGetPlayerCurrentWoodStoneMoney()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select wood_count,stone_count,money_count from player_resource where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //��װ��ʾ��ҵĲֿ������ɵ�ľ��������ʯͷ����
        private string AssembleGetPlayerTotalWoodStone()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select field_type,field_level from player_country where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //��װ�ض�������������ľ�ĺ�ʯͷ������
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

        //���������䷽����µ�letter_collected�ֶ�����
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

        //��װ�õ��Ѿ��ռ�������ĸ��sql���
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

        //��װ�õ����е�cpu������Ϣ��sql���
        private string AssembleGetAllCpuNameSQL()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select cpu_name from  cpu_info");
            return re.ToString();
        }

        //��װ�õ��Ѿ����е�cpu�����䷽�������Ѿ����е�cpu�����䷽��id���ϵ�sql���
        private string AssembleGetCpuIdInfoBySomeOne()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select formula_collected,cpu_collected from player_resource where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //��װ����cpu�����ֵõ�cpu_id��sql���
        private string AssembleGetCpuIdByCpuNameSort(string cpu_name)
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select cpu_id from cpu_info where cpu_name_sort=");
            re.Append("'");
            re.Append(cpu_name);
            re.Append("'");
            return re.ToString();
        }

        //��װ�õ�formula��Ϣ��sql���
        private string AssembleGetCpuFormulaField()
        {
            System.Text.StringBuilder re = new System.Text.StringBuilder();
            re.Append("select formula_collected from player_resource where player_id=");
            re.Append("'");
            re.Append(Session["user_id"].ToString().Trim());
            re.Append("'");
            return re.ToString();
        }

        //��װ�����ºϳɵ��䷽����player_resource���sql���
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

        //��װ�����µ��䷽�󣬸������е�letter_collected�ֶε�sql���
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

        //�õ��Ѿ��ռ�������ĸ
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

        //�õ����е�cpu������Ϣ
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

        //�õ��Ѿ����е�cpu�����䷽�������Ѿ����е�cpu�����䷽��id����
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

        //����cpu�����ֵõ�cpu_id
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

        //�õ�formula��Ϣ
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

        //�����ºϳɵ��䷽����player_resource��
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
                //message show �ϳɳɹ�
            }
        }

        //�����µ��䷽�󣬸������е�letter_collected�ֶ� 
        private void UpdateLetterField()
        {
            DATABASE.SQLDBOperate dbo = new DATABASE.SQLDBOperate();
            dbo.Connect();
            string sqlStr = AssembleUpdateLetterField();
            int re = dbo.UpdateDataBase(sqlStr);
            dbo.CloseConnection();
            if (re == 1)
            {
                //message show �ϳɳɹ�
            }
        }

        //������ѡ����ر���ĸ������Ƿ��ܵõ��䷽
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

        //����ѵõ��䷽���鿴�Ƿ��Ѿ����ڴ˿�cpu�������䷽�����������䷽
        private bool ComposeFormulaOrCpuInfo()
        {
            bool re = true;
            string validFormula = ValidFormula();
            if (validFormula == "")
            {
                //�ϳ�ʧ�ܣ�ԭ�������е�оƬ�䷽��һ��
                Message.Show("�ϳ�ʧ�ܣ�����ѡ�е���ĸ���ܺϳ��κ��䷽��", Response);
            }
            else
            {
                string formula = GetCpuIdByCpuNameSort(HLString.SortString(validFormula));
                string formulaBySomeone = GetCpuIdInfoBySomeOne();
                if (-1 != formulaBySomeone.IndexOf(formula))
                {
                    //�ϳ�ʧ�ܣ�ԭ���䷽�Ѵ���
                    Message.Show("�ϳ�ʧ�ܣ�����ѡ�е���ĸ�ϳɺ���䷽�Ѵ��ڡ�", Response);
                }
                else
                {
                    //�ϳɳɹ����޸�player_resource��
                    UpdateFormulaField(formula);
                    UpdateLetterField();
                    GetLetterCollected();
                    HLString.MessageBoxShow("��ϲ���䷽�ϳɳɹ���", Response);
                }
            }
            return re;
        }

        //��ҽ�������Լ��Ĵ�ׯʱ����ʾ��ҵ�ľ������ʯͷ���������
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

        //��ҽ�������Լ��Ĵ�ׯʱ����ʾ��ҵĲֿ������ɵ�ľ��������ʯͷ����
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