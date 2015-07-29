using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class Comment
    {
       /* 

         GetTravelComments 获取某一游记关联的评论信息
	Comments getCommentsByDiaryID()	
        */
        public static comment getCommentsByDiaryID(int diaryID)
        {
            using (var ctx = new hackthonEntities())
            {
                return ctx.comments.Where(x => x.diaryID == diaryID).FirstOrDefault();
            }
        }
    }
}
