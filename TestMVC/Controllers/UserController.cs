using App.Service;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TestMVC.CustomBinder;
using TestMVC.DAL;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        private UserContext db = new UserContext();

        public ActionResult Index()
        {
            var users = userService.GetAll();

            return View(Mapper.Map<List<UserViewModel>>(users));
            //return View(db.Users.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([ModelBinder(typeof(UserCustomBinder))] UserViewModel request)
        {
            if (ModelState.IsValid)
            {
                CreateUserRequest createUserRequest = Mapper.Map<CreateUserRequest>(request);
                userService.CreateUser(createUserRequest);
                //User user = new User(createUserRequest.FirstName, createUserRequest.LastName, createUserRequest.Email, createUserRequest.DateOfBirth);
                //db.Users.Add(user);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.isErrorBirthDate = ModelState["DateOfBirth"].Errors.Count > 0;
            }

            return View(request);
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
