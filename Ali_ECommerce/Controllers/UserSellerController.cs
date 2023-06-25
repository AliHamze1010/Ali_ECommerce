using Ali_ECommerce.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Ali_ECommerce.Controllers
{
    public class UserSellerController : Controller
    {
        private ApplicationDbContext _context;

        public UserSellerController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserSeller userSeller)
        {
            if (ModelState.IsValid)
            {
                _context.UserSellers.Add(userSeller);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(userSeller);
        }

        public ActionResult Index()
        {
            var userSellers = _context.UserSellers.ToList();
            return View(userSellers);
        }

        public ActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userSeller = _context.UserSellers.Find(id);
            if (userSeller == null)
            {
                return HttpNotFound();
            }

            return View(userSeller);
        }
    }
}
