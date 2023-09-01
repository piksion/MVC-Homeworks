using PizzaApp.Models.Enums;

namespace PizzaApp.ViewModels
{
	public class PizzaDetailsViewModel
	{
		public int PizzaId { get; set; }
		public string PizzaName { get; set;}
		public decimal PizzaPrice { get; set;}
		public PizzaSize PizzaSize { get; set;}
		public bool PizzaHasExtras { get; set; }
		public bool PizzaIsOnPromotion { get; set; }
	}
}
