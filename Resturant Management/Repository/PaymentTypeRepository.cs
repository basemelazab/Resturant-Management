using Resturant_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant_Management.Repository
{
    public class PaymentTypeRepository
    {
       private ResturantDBEntities db;
        public PaymentTypeRepository()
        {
            db = new ResturantDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            var selectListItems = new List<SelectListItem>();
             selectListItems = (from obj in db.PaymentTypes
                               select new SelectListItem()
                               {
                                   Text=obj.PaymentTypeName,
                                   Value=obj.PaymentTypeID.ToString(),
                                   Selected=true
                               }).ToList();
            return selectListItems;
              
        }
    }
}