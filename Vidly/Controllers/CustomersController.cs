using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        public ActionResult New()
        {
            var memberShipTypes = _context.MemberShipTypes.ToList();

            var viewModel = new NewCustomerViewModel()
            {
                MemberShipTypes = memberShipTypes
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x => x.MemberShipType).FirstOrDefault(x => x.Id == id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Create(NewCustomerViewModel viewModel)
        {

            _context.Customers.Add(Mapper.Map<Customer>(viewModel));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}