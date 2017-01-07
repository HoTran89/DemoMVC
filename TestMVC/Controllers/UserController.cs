using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestMVC.CustomBinder;
using TestMVC.DAL;
using TestMVC.Entity;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class UserController : Controller
    {
        private UserContext db = new UserContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([ModelBinder(typeof(UserCustomBinder))] UserViewModel createUserRequest)
        {
            if (ModelState.IsValid)
            {
                User user = new User(createUserRequest.FirstName, createUserRequest.LastName, createUserRequest.Email, createUserRequest.DateOfBirth);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.isErrorBirthDate = ModelState["DateOfBirth"].Errors.Count > 0;
            }

            return View(createUserRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
