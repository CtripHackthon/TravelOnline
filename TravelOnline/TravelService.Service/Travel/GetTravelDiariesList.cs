using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using MySql.Data.MySqlClient;
using TravelService.DataService;
using TravelService.Model;
using TravelService.Model.Base.Travel;
using TravelService.Model.ServiceModel;
using TravelService.Service.Utilities;

namespace TravelService.Service.Travel
{
    class GetTravelDiariesList : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
            if (request == null || request.requestObj == null)
            {
                response.errMessage = ReportServiceMessage.REQUEST_INVALID;
                response.returnCode = -1;
                return;
            }

            GetTravelDiariesListRequest serviceRequest =  (GetTravelDiariesListRequest)request.requestObj;

            
            GetTravelDiariesListResponse serviceResponse = new GetTravelDiariesListResponse();

            List<CategoryDiary> diarylist = new List<CategoryDiary>();
            if (serviceRequest.diaryId > 0)
            {
                diary d = Diary.getDiaryByDiaryID((int)serviceRequest.diaryId);
                if (d != null)
                {
                    TravelDiarySummary ds = new TravelDiarySummary();
                    ds.diaryId = d.diaryID;
                    ds.diaryPicAddr = "default";
                    ds.diarySummary = "summary";
                    ds.publishTime = (DateTime)d.publishTime;
                    ds.tags = d.tag;
                    ds.title  = d.title;
                    CategoryDiary cd = new CategoryDiary();
                    string sqlStr = null;
                    sqlStr = string.Format("select * from diary where diaryID={0}",ds.diaryId);

                    MySqlConnection conn = ConnectionManager.getInstance().getConnection();

                    conn.Open();

                    MySqlDataAdapter mda = new MySqlDataAdapter(sqlStr, conn);
                    DataSet ds1 = new DataSet();
                    mda.Fill(ds1, "table1");

                    conn.Close();

                    int count = ds1.Tables["table1"].Rows.Count;


                    cd.categoryId = (int)ds1.Tables["table1"].Rows[0][10];
                        
                    

                    cd.diares = new List<TravelDiarySummary>();
                    cd.diares.Add(ds);
                    diarylist.Add(cd);
                }
            }
            else
            {
                if (serviceRequest.categoryIds.Count > 0)
                {
                    int count = serviceRequest.categoryIds.Count;
                    List<CategoryDiary> flist = new List<CategoryDiary>();
                    for (int i = 0; i < count; i++)
                    {
                        long cid = serviceRequest.categoryIds.ElementAt(i);
                        string sqlStr = string.Format("select * from diary where categoryID={0}", cid);

                        MySqlConnection conn = ConnectionManager.getInstance().getConnection();

                        conn.Open();

                        MySqlDataAdapter mda = new MySqlDataAdapter(sqlStr, conn);
                        DataSet ds1 = new DataSet();
                        mda.Fill(ds1, "table1");

                        conn.Close();

                        CategoryDiary cd = new CategoryDiary();
                        cd.categoryId = cid;
                        cd.diares = new List<TravelDiarySummary>();

                        int sd = ds1.Tables["table1"].Rows.Count;

                        if (sd > 0)
                        {
                            for (int j = 0; j < sd; j++)
                            {
                                TravelDiarySummary tds = new TravelDiarySummary();
                                tds.diaryId = (int)ds1.Tables["table1"].Rows[j][0];
                                tds.diarySummary = "fdsafsd";
                                tds.publishTime = (DateTime)ds1.Tables["table1"].Rows[j][5];
                                tds.tags = (string)ds1.Tables["table1"].Rows[j][4];
                                tds.title = (string)ds1.Tables["table1"].Rows[j][2];
                                tds.userId = (int)ds1.Tables["table1"].Rows[j][1];
                                cd.diares.Add(tds);
                            }
                        }
                        //int size = ds1.Tables["table1"].Rows.Count;
                        //List<string> strlist = new List<string>();
                        //if (count > 0)
                        //{
                        //    string str = null;
                        //    str = (string)ds1.Tables["table1"].Rows[0][1];

                        //    if (str != null)
                        //        strlist.Add(str);

                        //    str = (string)ds1.Tables["table1"].Rows[0][2];

                        //    if (str != null)
                        //        strlist.Add(str);

                        //    str = (string)ds1.Tables["table1"].Rows[0][3];

                        //    if (str != null)
                        //        strlist.Add(str);

                        //}

                        flist.Add(cd);

                    }

                    serviceResponse.diaries = flist;
                }

                if (serviceRequest.userId > 0)
                {
                    
                }
                //int userid = ()
            }


            serviceResponse.diaries = diarylist;
            response.responseObj = serviceResponse;

            response.returnCode = 0;
        }
    }
}
