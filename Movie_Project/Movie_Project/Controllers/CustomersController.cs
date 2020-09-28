using Movie_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Movie_Project.ViewModel;

namespace Movie_Project.Controllers
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
            var membershipType = _context.MembershipTypes.ToList();

            var viewmodel = new CustomerFromViewModel
            {
                customer = new Customer(),
                MembershipTypes  = membershipType
            };

            return View("CustomerForm", viewmodel);
        }
        
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //return View(customers);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFromViewModel
                {
                    customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0)
                 _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
                _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var Customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (Customer == null)
                return HttpNotFound();

            var viewmodel = new CustomerFromViewModel
            {
                customer = Customer,
                MembershipTypes = _context.MembershipTypes.ToList(),
            };

            return View("CustomerForm", viewmodel);

        }

        public ActionResult Details(int id)
        {
            var Customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (Customer == null)
                return HttpNotFound();

            return View(Customer);
        }
    }
}