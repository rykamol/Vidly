using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;


        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {

            return View(_context.Customers.Include(x => x.MemberShipType).ToList());
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x => x.MemberShipType).FirstOrDefault(x => x.Id == id);
            return View(customer);
        }
    }
}