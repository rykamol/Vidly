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
            var viewModel = new NewCustomerViewModel()
            {
                MemberShipTypes = _context.MemberShipTypes
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            if (id < 0)
                return HttpNotFound();

            var customer = _context.Customers.Include(x => x.MemberShipType).FirstOrDefault(x => x.Id == id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Save(NewCustomerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var newCustomer = new NewCustomerViewModel()
                {
                    Customer = viewModel.Customer,
                    MemberShipTypes = _context.MemberShipTypes
                };
                return View("CustomerForm", newCustomer);
            }

            if (viewModel.Customer.Id == 0)
                _context.Customers.Add(Mapper.Map<Customer>(viewModel));
            else
            {
                var customer = _context.Customers.Single(c => c.Id == viewModel.Customer.Id);
                Mapper.Map(viewModel, customer);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id < 0)
                return HttpNotFound();

            var customer = _context.Customers.Include(x => x.MemberShipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes
            };

            return View("CustomerForm", viewModel);
        }
    }
}