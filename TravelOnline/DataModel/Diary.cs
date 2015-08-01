using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class Diary
    {  
        //PutTravelDiary         删除旅行日志
        public static void DeleteTraveDiary(int diaryID)
        {
            using (var ctx = new hackthonEntities())
            {
                var diary = from c in ctx.diaries where c.diaryID== diaryID select c ;
                ctx.DeleteObject(diary);
                ctx.SaveChanges();
            }
        }

        //PutTravelDiary         发布旅行日志
        public static int saveDiary(diary diary)
        {
            using (var ctx = new hackthonEntities())
            {
                ctx.AddTodiaries(diary);
                ctx.SaveChanges();
                return diary.diaryID;

            }
        }

        //updateTravelDiary         更新旅行日志
        public static void updateDiary(int diaryID, diary updateddiary)
        {
            using (var ctx = new hackthonEntities())
            {
                diary diary = getDiaryByDiaryID(diaryID);
                ctx.diaries.Attach(diary);
                if(diary.title !=updateddiary.title) diary.title =updateddiary.title;
                //todo: 写其他的
                ctx.SaveChanges();
            }
        }

        //GetTravelDiaryDetailInfo  获取某一游记详细信息
        static diary getDiaryByDiaryID(int diaryID)
        {          
            using (var ctx = new hackthonEntities())
            {
               return  ctx.diaries.Where(x => x.diaryID == diaryID).FirstOrDefault();
            }            
        }

        //按Tag获取游记列表
        public static IQueryable<diary> getDiaryListByTag(string tag)
        {
            IQueryable<diary> results;
            using (var ctx = new hackthonEntities())
            {
                results = ctx.diaries.Where(c => c.tag.Contains(tag));
                return results;
            }            
        }

        //按UserID获取游记列表
        static IQueryable<diary> getDiaryListByUserID(int userID)
        {
            IQueryable<diary> results;
            using (var ctx = new hackthonEntities())
            {
                results = ctx.diaries.Where(c => c.userID == userID);
                return results;
            }
        }

        //GetTravelDiariesList
    }
}
