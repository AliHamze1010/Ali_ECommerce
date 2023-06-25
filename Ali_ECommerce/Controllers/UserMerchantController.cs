using Ali_ECommerce.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Ali_ECommerce.Controllers
{
    public class UserMerchantController : Controller
    {
        private ApplicationDbContext _context;

        public UserMerchantController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                _context.Merchants.Add(merchant);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(merchant);
        }

        public ActionResult Index()
        {
            var merchants = _context.Merchants.ToList();
            return View(merchants);
        }

        public ActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var merchant = _context.Merchants.Find(id);
            if (merchant == null)
            {
                return HttpNotFound();
            }

            return View(merchant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(merchant).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(merchant);
        }

        public ActionResult List()
        {
            var merchants = _context.Merchants.ToList();
            return View(merchants);
        }

        public ActionResult Details(int id)
        {
            var merchant = _context.Merchants.Find(id);
            if (merchant == null)
            {
                return HttpNotFound();
            }

            return View(merchant);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var merchant = _context.Merchants.Find(id);
            if (merchant == null)
            {
                return HttpNotFound();
            }

            _context.Merchants.Remove(merchant);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
