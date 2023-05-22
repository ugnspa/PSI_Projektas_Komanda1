using Microsoft.AspNetCore.Mvc;
using PSI_Projektas_Komanda1.Repositories;

namespace PSI_Projektas_Komanda1.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Orders()
		{
			string username = HttpContext.Session.GetString("username");
			if (string.IsNullOrEmpty(username))
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				User user = UserRepo.FindUserByUsername(username);

				return View("~/Views/Home/Orders.cshtml", OrderRepo.ReadUserOrders(user));
			}
		}

		[HttpGet]
		public IActionResult OrderDetails(int id)
		{
			Order order = OrderRepo.FindOrder(id);
			return View("~/Views/Home/OrderDetails.cshtml", order);
		}
	}
}
