using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelClient.UX.Ajax.Models;

namespace TravelClient.UX.Ajax
{
    public partial class PostAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["queryType"] == "addPicture")
            {
                Response.Write(AddPicture());
            }


             if (Request["queryType"] == "removePicture")
            {
                RemovePicture();
            }
        }
        private void RemovePicture()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var paramDes = jss.Deserialize<ListQueryParameterPicture>(Request["queryParam"]);

            foreach (var item in paramDes)
            {
                FileInfo myfileinf = new FileInfo(Server.MapPath(item));
                myfileinf.Delete();
            }
        }

        private string AddPicture()
        {
            string output = "";
            Guid subString = Guid.NewGuid();
            // Get the post data
            if (Request.Files == null)
            {
                output = "Querystring:uploaded file is null!";
            }
            //var paramDes = jss.Deserialize<QueryParameterPicture>(Request["data"]);

            string logicalPath = "";
            //if (paramDes.SaveLocation != string.Empty)
            //{
            //    // Save int temp location
            //    picturePath = Server.MapPath("../CustomerPicture/Temp/");
            //    logicalPath = "../CustomerPicture/Temp/";
            //}
            //else
            //{
            var picturePath = Server.MapPath("../CustomerPicture/");
            logicalPath = "../CustomerPicture/";
            //}
            string[] stringSplit = Request.Files[0].FileName.Split('\\');
            int temp = stringSplit.Length;

            string newFileName = picturePath + subString + stringSplit[temp - 1];
            Directory.CreateDirectory(Path.GetDirectoryName(newFileName));

            string newLogicFileName = logicalPath + subString + stringSplit[temp - 1];



            using (FileStream fileStream = File.Create(newFileName))
            {
                var buffer = new byte[Request.Files[0].ContentLength];
                int readCount = Request.Files[0].InputStream.Read(buffer, 0, buffer.Length);

                if (readCount > 0)
                {
                    fileStream.Write(buffer, 0, readCount);
                }
            }
            Console.Write("Hello");
            return newLogicFileName;
        }
    }
}