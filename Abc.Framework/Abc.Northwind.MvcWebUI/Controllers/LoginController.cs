using System;
using System.Web.Mvc;
using System.Web.Security;
using Abc.Core.CrossCuttingConcerns.Security.Web;

namespace Abc.Northwind.MvcWebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public string Index()
        {
            AuthenticationHelper.CreateAuthCookie(
                new Guid(),
                "engin",
                "engin@gmail.com",
                DateTime.Now.AddMinutes(15),
                new[] { "Admin" },
                false,
                "Engin",
                "Demiroğ",
                "12345");

            return "Now authenticated.";
        }

        public string LogOut()
        {
            FormsAuthentication.SignOut();
            return "Signed out.";
        }
    }
}