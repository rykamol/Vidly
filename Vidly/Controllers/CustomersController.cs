using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {

            return View(Customers());
        }

        public List<Customer> Customers()
        {
            var customers = new List<Customer>
            {
                new Customer() {Id = 1, Name = "Kamol Roy"},
                new Customer() {Id = 2, Name = "Jhon"}
            };

            return customers;
        }

        public ActionResult Details(int id)
        {
            var customer = Customers().FirstOrDefault(x => x.Id == id);
            return View(customer);
        }
    }
}