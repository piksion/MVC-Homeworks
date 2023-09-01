using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
	public class PizzaController : Controller
 	{
		public IActionResult GetAllPizzas ()
		{
			List<Pizza> pizzasDb = StaticDb.pizzas;
			return View(pizzasDb);
		}
		public IActionResult Details(int? id)
		{
			if(id == null)
			{
				return RedirectToAction("Error", "Home");	
			}

			Pizza pizza = StaticDb.pizzas.FirstOrDefault(x => x.Id == id);
			if(pizza == null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(pizza);
		}
	}
}
