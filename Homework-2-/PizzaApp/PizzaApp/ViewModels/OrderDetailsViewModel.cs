﻿namespace PizzaApp.ViewModels
{
	public class OrderDetailsViewModel
	{
		public string UserFullName { get; set; }
		public string PizzaName { get; set; }
		public int OrderPrice { get; set; }
		public string PaymentMethod { get; set; }

		public string UserAddress { get; set; }
	}
}
