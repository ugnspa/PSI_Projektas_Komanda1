using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using PSI_Projektas_Komanda1.Repositories;

namespace PSI_Projektas_Komanda1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View("~/Views/Home/Login.cshtml");
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            bool correctLogin = CheckUserPassword(username, password);
   
            if (correctLogin)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View("~/Views/Home/Login.cshtml", ModelState);
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }


        public static bool CheckUserPassword(string username, string password)
        {
            bool userExists = UserRepo.CheckUserExistanceByUsername(username);
            if (userExists)
            {
                User user = UserRepo.FindUserByUsername(username);
                // Presumably the passwords should be hashed for security in the future
                return user.Password.Equals(password);
            }
            else
            {
                return false;
            }
        }

        public static void TestUserAdd()
        {
            Console.WriteLine("Testing InsertUser() method");
            Console.WriteLine("----------------------------");
            for (int i = 0; i < 10; i++)
            {
                User user = new User();
                user.ID = i;
                user.Name = "test" + i;
                user.SurName = "test" + i;
                user.Email = "test" + i;
                user.UserName = "test" + i;
                user.Password = "test" + i;

                // Checking if username is available and can be used
                if (UserRepo.CheckUsernameAvailability(user.UserName))
                {
                    Console.WriteLine("User '{0}' added into dabase", user.UserName);
                    UserRepo.InsertUser(user);
                }
                else
                {
                    Console.WriteLine("Username '{0}' is already in use", user.UserName);
                }
            }
            Console.WriteLine("----------------------------");
        }

        public static void TestUserPasswordCheck()
        {
            Console.WriteLine("Testing CheckUserPassword() method");
            Console.WriteLine("----------------------------");
            for (int i = 0; i < 10; i++)
            {
                User user = new User();
                user.ID = i;
                user.Name = "test" + i;
                user.SurName = "test" + i;
                user.Email = "test" + i;
                user.UserName = "test" + i;
                user.Password = "test" + i;

                // Checking if username is available and can be used
                if (UserRepo.CheckUserExistanceByUsername(user.UserName))
                {
                    bool passwordCorrect = CheckUserPassword(user.UserName, user.Password);
                    if (passwordCorrect)
                        Console.WriteLine("User '{0}' password is correct ({1})", user.UserName, user.Password);
                    else
                        Console.WriteLine("User '{0}' password is incorrect ({1})", user.UserName, user.Password);
                }
                else
                {
                    Console.WriteLine("User '{0}' doesn't exist", user.UserName);
                }
            }
            Console.WriteLine("----------------------------");
        }
    }
}
