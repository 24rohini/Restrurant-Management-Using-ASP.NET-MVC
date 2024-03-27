using RestrurantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestrurantMVC.Repositories
{
    public class CustomerRepository
    {
        private RestaurantDBEntities objRestaurantDbEntites;
        public CustomerRepository()
        {
            objRestaurantDbEntites = new RestaurantDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllCustomer()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestaurantDbEntites.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.Customerid.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}