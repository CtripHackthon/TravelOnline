using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class Orders
    {
        //下单
        //更新订单状态
        //PutTravelDiary         发布旅行日志
        public static void saveOrder(order order)
        {
            using (var ctx = new hackthonEntities())
            {
                ctx.AddToorders(order);
                ctx.SaveChanges();
            }
        }

        //updateTravelDiary  更新旅行日志状态，已下单/已付款/已返积分/退款
        public static void updateOrderStatusAs(int orderID,string orderStatus)
        {
            using (var ctx = new hackthonEntities())
            {
                order order = selectOrderInfoById(orderID);
                ctx.orders.Attach(order);
                order.status = orderStatus;
                ctx.SaveChanges();
            }
        }

        public static order selectOrderInfoById(int orderID)
        {
            IQueryable<order> results;
            using (var ctx = new hackthonEntities())
            {
                results = ctx.orders.Where(c => c.orderID == orderID);
                return results.First();
            }
        }
    }
}
