using PizzaApp.Models;
using PizzaApp.ViewModels;

namespace PizzaApp.Mappers
{
	public static class PizzaMapper
	{
		public static PizzaDetailsViewModel PizzaListToPizzaViewModel (Pizza pizzaDb)
		{
			return new PizzaDetailsViewModel
			{
				PizzaId = pizzaDb.Id,
				PizzaName = pizzaDb.Name,
				PizzaPrice = pizzaDb.Price,
				PizzaSize = pizzaDb.PizzaSize,
				PizzaHasExtras = pizzaDb.HasExtras
			};
		}
	}
}
