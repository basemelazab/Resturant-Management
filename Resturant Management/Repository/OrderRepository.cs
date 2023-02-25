using Resturant_Management.Models;
using Resturant_Management.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant_Management.Repository
{
    public class OrderRepository
    {
        private ResturantDBEntities db;
        public OrderRepository()
        {
            db = new ResturantDBEntities();
        }
        public bool AddOrder(OrderViewModel orderViewModel)
        {
            Order order = new Order();
            order.CustomerId = orderViewModel.CustomerId;
            order.FinalTotal = orderViewModel.FinalTotal;
            order.OrderDate =DateTime.Now;
            order.OrderName = String.Format("{0:ddmmmyyyyhhmmss}", DateTime.Now);
            order.PaymentTypeId= orderViewModel.PaymentTypeId;
            db.Orders.Add(order);
            db.SaveChanges();
            int orderId=order.OrderId;
            foreach(var item in orderViewModel.listOfOrderDetailViewModels)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderId = orderId;
                orderDetail.Discount=item.Discount;
                orderDetail.ItemId = item.ItemId;
                orderDetail.Total = item.Total;
                orderDetail.UnitPrice=item.UnitPrice;
                orderDetail.Quantity = item.Quantity;
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();

                Transaction transaction = new Transaction();
                transaction.ItemId=item.ItemId;
                transaction.Quantity=(-1)*item.Quantity;
                transaction.TransactionDate=DateTime.Now;
                transaction.TypeId = 2;
                db.Transactions.Add(transaction);
                db.SaveChanges(); 
            }
            return true;
        }
    }
}