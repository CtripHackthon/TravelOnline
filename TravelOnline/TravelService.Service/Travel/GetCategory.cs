using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TravelService.DataService;
using TravelService.Model;
using TravelService.Model.Base.Common;
using TravelService.Model.ServiceModel;

namespace TravelService.Service.Travel
{
    public class GetCategory : IService
    {
        public void process(ServiceRequest request, ServiceResponse response)
        {
            List<Category> list = new List<Category>();

            string sqlStr = "select * from category";

            MySqlConnection conn = ConnectionManager.getInstance().getConnection();
  
            conn.Open();

            MySqlDataAdapter mda = new MySqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            mda.Fill(ds,"table1");
            
            conn.Close();

            int count = ds.Tables["table1"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Category c = new Category();
                c.categoryId = (int)ds.Tables["table1"].Rows[i][0];
                c.categoryName = (string)ds.Tables["table1"].Rows[i][1];
                list.Add(c);
            }

            GetCategoryResponse serviceResponse = new GetCategoryResponse();
            serviceResponse.categories = list;
            response.responseObj = serviceResponse;
            response.returnCode = 0;
        }
    }
}
