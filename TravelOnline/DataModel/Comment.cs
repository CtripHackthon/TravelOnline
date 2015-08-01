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
        public static List<comment> getCommentsByDiaryID(int diaryID)
        {
            using (var ctx = new hackthonEntities())
            {
                List<comment> list = new List<comment>();
                IEnumerator<comment> ie = ctx.comments.Where(x => x.diaryID == diaryID).GetEnumerator();
                while (ie.MoveNext())
                {
                    list.Add(ie.Current);
                }

                return list;
            }
        }
    }
}
