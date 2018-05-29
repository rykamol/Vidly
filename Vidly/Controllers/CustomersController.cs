using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public ApplicationDbContext Context;

        public CustomersController()
        {
            Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {

            return View(Context.Customers.Include(x => x.MemberShipType).ToList());
        }

        public ActionResult Details(int id)
        {
            var customer = Context.Customers.Include(x => x.MemberShipType).FirstOrDefault(x => x.Id == id);
            return View(customer);
        }
    }
}