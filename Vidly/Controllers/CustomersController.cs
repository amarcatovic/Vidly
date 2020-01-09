using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var MemType = _context.MembershipTypes.ToList();
            var model = new NewCustomerViewModel();
            model.MembershipTypes = MemType;
            model.Customer = new Customer();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewCustomerViewModel nc)
        {
            if(!ModelState.IsValid)
            {
                var model = new NewCustomerViewModel
                {
                    Customer = nc.Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("New", model);
            }
            if(nc.Customer.Id == 0)
            {
                _context.Customers.Add(nc.Customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == nc.Customer.Id);
                customerInDb.Name = nc.Customer.Name;
                customerInDb.MembershipTypeId = nc.Customer.MembershipTypeId;
                customerInDb.IsSuscribedToNewsletter = nc.Customer.IsSuscribedToNewsletter;
                customerInDb.BirthDate = nc.Customer.BirthDate;
            }
          
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var model = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("New", model);
        }

        // GET: Customers
        [Route("Customers")]
        [Route("Customers/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var c = _context.Customers.Include(e => e.MembershipType).SingleOrDefault(e => e.Id == id);
            if (c == null)
                return HttpNotFound();

            return View(c);
        }
    }
}