using System;
using System.Linq;
using System.Web.Mvc;
using IsintuWebsite.Models;

namespace IsintuWebsite.Controllers
{
    public class AttireController : Controller
    {
        private readonly IsintuDbContext db = new IsintuDbContext();

        // GET: Attire
        // Shows every available attire item, with an optional category filter
        // coming from the dropdown on the Index page (Men, Women, Accessories).
        public ActionResult Index(string category)
        {
            var query = db.ClothingItems.Where(a => a.AvailabilityStatus == "Available");

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(a => a.Category == category);
            }

            var items = query.OrderBy(a => a.Category).ThenBy(a => a.Name).ToList();

            return View(items);
        }

        // GET: Attire/Details/5
        // Loads the attire and hands back a pre-filled order form for it.
        public ActionResult Details(int id)
        {
            var attire = db.ClothingItems.FirstOrDefault(a => a.AttireId == id);

            if (attire == null)
            {
                return HttpNotFound();
            }

            var model = new OrderFormViewModel
            {
                AttireId = attire.AttireId,
                Attire = attire,
                OrderType = "Buy",
                Quantity = 1,
                RentalDays = 1
            };

            return View(model);
        }

        // POST: Attire/PlaceOrder
        // Handles the submitted order form - creates the customer if they're new,
        // builds up the order and its single line item, then works out the total.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceOrder(OrderFormViewModel model)
        {
            var attire = db.ClothingItems.FirstOrDefault(a => a.AttireId == model.AttireId);

            if (attire == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                model.Attire = attire;
                return View("Details", model);
            }

            var customer = db.Customers.FirstOrDefault(c => c.Email == model.CustomerEmail);

            if (customer == null)
            {
                customer = new Customer
                {
                    Name = model.CustomerName,
                    Email = model.CustomerEmail,
                    Phone = model.CustomerPhone,
                    Address = model.DeliveryAddress
                };

                db.Customers.Add(customer);
                db.SaveChanges();
            }

            var orderItem = new OrderItem
            {
                AttireId = attire.AttireId,
                Attire = attire,
                OrderType = model.OrderType,
                Quantity = model.Quantity,
                RentalDays = model.OrderType == "Rent" ? model.RentalDays : 0,
                IncludeAccessories = model.IncludeAccessories
            };

            var order = new Order
            {
                CustomerId = customer.CustomerId,
                OrderDate = DateTime.Now,
                DeliveryStatus = "Pending"
            };

            order.OrderItems.Add(orderItem);

            db.Orders.Add(order);
            db.SaveChanges();

            // If this was a rental, we also open up a Hire record so the return
            // date and any late fees can be tracked separately from the order.
            if (model.OrderType == "Rent")
            {
                var hire = new Hire
                {
                    OrderItemId = orderItem.OrderItemId,
                    StartDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(model.RentalDays)
                };

                db.Hires.Add(hire);
                db.SaveChanges();
            }

            var confirmation = new OrderConfirmationViewModel
            {
                OrderId = order.OrderId,
                AttireName = attire.Name,
                CustomerName = customer.Name,
                OrderType = orderItem.OrderType,
                Quantity = orderItem.Quantity,
                RentalDays = orderItem.RentalDays,
                IncludeAccessories = orderItem.IncludeAccessories,
                TotalAmount = order.CalculateOrderTotal()
            };

            return View("Confirmation", confirmation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
