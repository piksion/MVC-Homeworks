using Microsoft.AspNetCore.Mvc;
using PizzaApp.Mappers;
using PizzaApp.Models;
using PizzaApp.ViewModels;

namespace PizzaApp.Controllers
{
	public class PizzaController : Controller
 	{
		
		public IActionResult Details(int? id)
		{
			if(id == null)
			{
				return new EmptyResult();
			}

			Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
			if(pizza == null)
			{
				return new EmptyResult();
			}
			return View(pizza);
		}
		public IActionResult Index()
		{
			List<Pizza> pizzas = StaticDb.Pizzas;

			List<PizzaDetailsViewModel>pizzaDetailsViewModels = pizzas.Select(x => PizzaMapper.PizzaListToPizzaViewModel(x)).ToList();
			return View(pizzaDetailsViewModels);
		}
	}
}
