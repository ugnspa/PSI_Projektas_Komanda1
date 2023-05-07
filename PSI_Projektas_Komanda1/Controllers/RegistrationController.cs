using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using PSI_Projektas_Komanda1.Repositories;

namespace PSI_Projektas_Komanda1.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Register()
        {
            return View("~/Views/Home/Register.cshtml");
        }

        [HttpPost]
        public IActionResult Register(string name, string surname, string email, string username, string password)
        {
            User user = new User();
            user.Name = name;
            user.SurName = surname;
            user.UserName= username;
            user.Email = email;
            user.Password= password;
            int id = UserRepo.InsertUser(user);

            if(id == -1)
            {
                ModelState.AddModelError("", "Username taken");
                return View("~/Views/Home/Register.cshtml", ModelState);
            }

            HttpContext.Session.SetString("username", username);
            return View("~/Views/Home/Account.cshtml", UserRepo.FindUserByUsername(username));
        }
    }
}
