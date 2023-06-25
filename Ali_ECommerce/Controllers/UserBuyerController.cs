using Ali_ECommerce.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

public class UserBuyerController : Controller
{
    private ApplicationDbContext _context;

    public UserBuyerController()
    {
        _context = new ApplicationDbContext();
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(UserBuyer userBuyer)
    {
        if (ModelState.IsValid)
        {
            _context.UserBuyers.Add(userBuyer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(userBuyer);
    }

    public ActionResult Index()
    {
        var userBuyers = _context.UserBuyers.ToList();
        return View(userBuyers);
    }

    public ActionResult Error()
    {
        return View();
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        var userBuyer = _context.UserBuyers.Find(id);
        if (userBuyer == null)
        {
            return HttpNotFound();
        }

        return View(userBuyer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(UserBuyer userBuyer)
    {
        if (ModelState.IsValid)
        {
            _context.Entry(userBuyer).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(userBuyer);
    }

    public ActionResult List()
    {
        var userBuyers = _context.UserBuyers.ToList();
        return View(userBuyers);
    }

    public ActionResult Details(int id)
    {
        var userBuyer = _context.UserBuyers.Find(id);
        if (userBuyer == null)
        {
            return HttpNotFound();
        }

        return View(userBuyer);
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
        var userBuyer = _context.UserBuyers.Find(id);
        if (userBuyer == null)
        {
            return HttpNotFound();
        }

        _context.UserBuyers.Remove(userBuyer);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
