using Resturant_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant_Management.Repository
{
    public class CustomerRepository
    {
        private ResturantDBEntities db;
        public CustomerRepository()
        {
            db = new ResturantDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in db.Customers
                               select new SelectListItem()
                               {
                                   Text = obj.CustomerName,
                                   Value = obj.CustomerID.ToString(),
                                   Selected = true
                               }).ToList();
            return selectListItems;

        }
    }
}