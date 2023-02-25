using Resturant_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant_Management.Repository
{
    public class ItemRepository
    {
        private ResturantDBEntities db;
        public ItemRepository()
        {
            db = new ResturantDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllItems()
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems = (from obj in db.Items
                               select new SelectListItem()
                               {
                                   Text = obj.ItemName,
                                   Value = obj.ItemID.ToString(),
                                   Selected = false
                               }).ToList();
            return selectListItems;

        }
    }
}