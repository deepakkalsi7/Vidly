using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private VidlyContext vidlyContext;

        public CustomersController()
        {
            vidlyContext = new VidlyContext();
        }
       
        // GET: All Customer
        public ActionResult Customers()
        {
            var customers = vidlyContext.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        //Get customer by Id 
        public ActionResult Detail(int id)
        {
            var Cus = vidlyContext.Customers.FirstOrDefault(x => x.Id == id);
            return View(Cus);
        }
        //new 
        public ActionResult NewCustomer()
        {
            var list = vidlyContext.MembershipTypes.ToList();
            var viewmodel = new NewCustomerViewModel()
            {Customer=new Customer(),
                MembershipTypes = list
            };

            return View("save",viewmodel);
        }
        //create new customer in database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new NewCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = vidlyContext.MembershipTypes.ToList()
                    
                };

                return View("Save", viewmodel);
            }
            if (customer.Id == 0)
            {
                vidlyContext.Customers.Add(customer);
                vidlyContext.SaveChanges();
                return RedirectToAction("detail", "customers", new { id = customer.Id });
            }
            else
            {
                var cust = vidlyContext.Customers.First(x => x.Id == customer.Id);
                cust.Name = customer.Name;
                cust.Birthdate = customer.Birthdate;
                vidlyContext.SaveChanges();

                return RedirectToAction("detail", "customers", new { id=customer.Id});
            }

            
        }
        
        //Edit customer
        public ActionResult Edit(int id)
        {
            var customer = vidlyContext.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new NewCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = vidlyContext.MembershipTypes.ToList()
        };
            return View("save",viewmodel);

        }


    }
}