using Resturant_Management.Models;
using Resturant_Management.Repository;
using Resturant_Management.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant_Management.Controllers
{
    public class HomeController : Controller
    {
        private ResturantDBEntities db;
        public HomeController()
        {
            db = new ResturantDBEntities();
        }
        public ActionResult Index()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            PaymentTypeRepository paymentTypeRepository = new PaymentTypeRepository();
            ItemRepository itemRepository = new ItemRepository();
            var multipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (customerRepository.GetAllCustomers(), paymentTypeRepository.GetAllPaymentType(), itemRepository.GetAllItems());
            return View(multipleModels);
        }
        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal unitPrice=db.Items.Single(model=>model.ItemID==itemId).ItemPrice;
            return Json(unitPrice,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Index(OrderViewModel orderViewModel)
        {
            OrderRepository orderRepository = new OrderRepository();
            orderRepository.AddOrder(orderViewModel);
            return Json(" Your order has been Successfully Placed.", JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}