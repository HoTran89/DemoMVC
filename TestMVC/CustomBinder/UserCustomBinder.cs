using System;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using TestMVC.Models;

namespace TestMVC.CustomBinder
{
    public class UserCustomBinder : System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
            string firstName = request.Form.Get("FirstName");
            string lastName = request.Form.Get("LastName");
            string email = request.Form.Get("Email");
            string date = request.Form.Get("txtDate");
            string month = request.Form.Get("txtMonth");
            string year = request.Form.Get("txtYear");
            UserViewModel user = null;
            try
            {
                user = new UserViewModel()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    DateOfBirth = DateTime.Parse($"{year}-{month}-{date}")
                };

                int minimumOld = int.Parse(WebConfigurationManager.AppSettings["minimumOld"]);
                DateTime now = DateTime.Today;
                int age = now.Year - user.DateOfBirth.Year;
                if (now < user.DateOfBirth.AddYears(age)) age--;
                if (age < minimumOld)
                {
                    bindingContext.ModelState.AddModelError("DateOfBirth", "old too young");
                }
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError("DateOfBirth", ex.Message);
            }
            return user;
        }
    }
}