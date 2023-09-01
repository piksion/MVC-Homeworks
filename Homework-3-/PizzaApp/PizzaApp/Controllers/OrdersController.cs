using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
	
	public class OrdersController : Controller
	{
		[Route("ListOrders")]
		public IActionResult Index()
		{
			List<Orders> orders = StaticDb.Orders.ToList();
			return View(orders);
		}
		
		//public IActionResult Details(int? id)
		//{
		//	if(id == null)
		//	{
		//		return RedirectToAction("Error", "Home");
		//	}
		//	return View();
		//}
		public IActionResult JsonData()
		{
			List<Orders> orders = StaticDb.Orders.ToList();
			return new JsonResult(orders);
		}
		public IActionResult RedirectToHome()
		{
			return RedirectToAction("Index", "Home");
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return RedirectToAction("Error", "Orders");
			}

			Orders order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
			if (order == null)
			{
				return RedirectToAction("Error", "Orders");
			}

			return View(order);
		}
	}
}
