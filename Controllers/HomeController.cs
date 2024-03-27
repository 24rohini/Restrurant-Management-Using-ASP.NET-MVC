
//using RestrurantMVC.Models;
//using RestrurantMVC.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace RestrurantMVC.Controllers
//{
//    public class HomeController : Controller
//    {
//        private RestaurantDBEntities objRestaurantDBEntities;

//        public HomeController()
//        {
//            objRestaurantDBEntities = new RestaurantDBEntities();
//        }

//        // GET: Home
//        public ActionResult Index()
//        {
//            CustomerRepository objCustomerRepository = new CustomerRepository();
//            ItemRepository objItemRepository = new ItemRepository();
//            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();

//            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(
//                objCustomerRepository.GetAllCustomer(),
//                objItemRepository.GetAllItems(),
//                objPaymentTypeRepository.GetAllPaymentType()
//            );

//            return View(objMultipleModels);
//        }

//        [HttpGet]
//        public JsonResult getItemUnitPrice(int id) // Change itemId to id for consistency
//        {
//            try
//            {
//                // Fetch the item from the database using ItemId
//                var item = objRestaurantDBEntities.Items.SingleOrDefault(i => i.ItemId == id);

//                if (item != null)
//                {
//                    decimal unitPrice = item.ItemPrice;
//                    return Json(unitPrice, JsonRequestBehavior.AllowGet);
//                }
//                else
//                {
//                    // Handle case where item with specified itemId was not found
//                    return Json("Item not found", JsonRequestBehavior.AllowGet);
//                }
//            }
//            catch (Exception ex)
//            {
//                // Log the exception or handle it appropriately
//                return Json("Error: " + ex.Message, JsonRequestBehavior.AllowGet);
//            }
//        }
//    }

//}
using RestrurantMVC.Models;
using RestrurantMVC.Repositories;
using RestrurantMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestrurantMVC.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantDBEntities objRestaurantDBEntities;

        public HomeController()
        {
            objRestaurantDBEntities = new RestaurantDBEntities();
        }

        // GET: Home
        public ActionResult Index()
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(
                objCustomerRepository.GetAllCustomer(),
                objItemRepository.GetAllItems(),
                objPaymentTypeRepository.GetAllPaymentType()
            );

            return View(objMultipleModels);
        }

        [HttpGet]
        public JsonResult getItemUnitPrice(int id)
        {
            try
            {
                var item = objRestaurantDBEntities.Items.SingleOrDefault(i => i.ItemId == id);

                if (item != null)
                {
                    decimal unitPrice = item.ItemPrice;
                    return Json(unitPrice, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Item not found", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("Error: " + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]

        public JsonResult Index(OrderViewModel ObjOrderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(ObjOrderViewModel);
            return Json(data: "Your Order has been Successfuly Created", JsonRequestBehavior.AllowGet);
        }
    }
}
