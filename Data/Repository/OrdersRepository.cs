using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IOrders
    {
        private readonly AppDBContent db;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDBContent db, ShopCart shopCart)
        {
            this.db = db;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            db.Order.Add(order);
            db.SaveChanges();

            foreach (var item in shopCart.ListShopsItems)
            {
                var orderDetail = new OrderDetail()
                {
                    carId = item.Car.IdCar,
                    orderId = order.id,
                    desc = item.Car.DescCar
                };
                db.OrderDetail.Add(orderDetail);
            }

            db.SaveChanges();
        }
    }
}
