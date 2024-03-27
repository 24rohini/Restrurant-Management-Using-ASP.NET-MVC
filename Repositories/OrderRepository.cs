//using RestrurantMVC.Models;
//using RestrurantMVC.ViewModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Xml.Linq;

//namespace RestrurantMVC.Repositories
//{
//    public class OrderRepository
//    {
//        private RestaurantDBEntities objRestaurantDbEntites;
//        public  OrderRepository()
//        {
//            objRestaurantDbEntites = new RestaurantDBEntities();
//        }
//        public bool AddOrder(OrderViewModel objOrderViewModel)
//        {
//            Order objOrder = new Order();
//            objOrder.CustomerId = objOrderViewModel.CustomerId;
//            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
//            objOrder.OrderDate = DateTime.Now;
//            objOrder.OrderNumber=string.Format("{0:ddmmmyyyyhhmmss}",DateTime.Now);
//            objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;
//            objRestaurantDbEntites.Orders.Add(objOrder);
//            objRestaurantDbEntites = SaveChanges();
//            int OrderId = objOrder.OrderId;

//            foreach(var item in objOrderViewModel.ListOfOrderDetailViewModel)
//            {
//                OrderDetail objOrderDetail = new OrderDetail();
//                objOrderDetail.OrderId = OrderId;
//                objOrderDetail.Discount = item.Discount;
//                objOrderDetail.ItemId = item.ItemId;
//                objOrderDetail.Total = item.Total;
//                objOrderDetail.UnitPrice = item.UnitPrice;
//                objOrderDetail.Quantity = item.Quantity;
//                objRestaurantDbEntites.OrderDetails.Add(objOrderDetail);
//                objRestaurantDbEntites.SaveChanges();


//                Transaction objTransaction = new Transaction();
//                objTransaction.ItemId = item.ItemId;
//                objTransaction.Quantity =(-1)* item.Quantity;
//                objTransaction.TransactionDate = DateTime.Now;
//                objTransaction.TypeId = 2;
//                objRestaurantDbEntites.Transactions.Add(objTransaction);
//                objRestaurantDbEntites.SaveChanges();









//            }

//            return true;



//        }

//        private RestaurantDBEntities SaveChanges()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

using RestrurantMVC.Models;
using RestrurantMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RestrurantMVC.Repositories
{
    public class OrderRepository
    {
        private RestaurantDBEntities objRestaurantDbEntities;

        public OrderRepository()
        {
            objRestaurantDbEntities = new RestaurantDBEntities();
        }

        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Order objOrder = new Order();
            objOrder.CustomerId = objOrderViewModel.CustomerId;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.OrderDate = DateTime.Now;
            objOrder.OrderNumber = string.Format("{0:ddmmmyyyyhhmmss}", DateTime.Now);
            objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;
            objRestaurantDbEntities.Orders.Add(objOrder);

            // Save changes to the database
            SaveChanges();

            int OrderId = objOrder.OrderId;

            foreach (var item in objOrderViewModel.ListOfOrderDetailViewModel)
            {
                OrderDetail objOrderDetail = new OrderDetail();
                objOrderDetail.OrderId = OrderId;
                objOrderDetail.Discount = item.Discount;
                objOrderDetail.ItemId = item.ItemId;
                objOrderDetail.Total = item.Total;
                objOrderDetail.UnitPrice = item.UnitPrice;
                objOrderDetail.Quantity = item.Quantity;
                objRestaurantDbEntities.OrderDetails.Add(objOrderDetail);
                objRestaurantDbEntities.SaveChanges();

                Transaction objTransaction = new Transaction();
                objTransaction.ItemId = item.ItemId;
                objTransaction.Quantity = (-1) * item.Quantity;
                objTransaction.TransactionDate = DateTime.Now;
                objTransaction.TypeId = 2;
                objRestaurantDbEntities.Transactions.Add(objTransaction);
                objRestaurantDbEntities.SaveChanges();
            }

            return true;
        }

        private void SaveChanges()
        {
            // Save changes to the database using the context
            objRestaurantDbEntities.SaveChanges();
        }
    }
}
