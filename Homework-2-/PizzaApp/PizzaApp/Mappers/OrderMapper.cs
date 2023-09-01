﻿using PizzaApp.Models;
using PizzaApp.ViewModels;

namespace PizzaApp.Mappers
{
	public static class OrderMapper
	{
		//we map from Order domain model (order from db) to OrderListViewModel
		public static OrderListViewModel OrderToOrderListViewModel(Order orderDb)
		{
			return new OrderListViewModel
			{
				PizzaName = orderDb.Pizza.Name,
				UserFullName = $"{orderDb.User.FirstName} {orderDb.User.LastName}"
			};
		}

		//we map from Order domain model (order from db) to OrderDetailsViewModel
		public static OrderDetailsViewModel OrderToOrderDetailsViewModel(Order orderDb)
		{
			return new OrderDetailsViewModel
			{
				PizzaName = orderDb.Pizza.Name,
				UserFullName = $"{orderDb.User.FirstName} {orderDb.User.LastName}",
				OrderPrice = (int)(orderDb.Pizza.Price + 50),
				PaymentMethod = orderDb.PaymentMethod.ToString(),
				UserAddress = orderDb.User.Address
			};
		}
	}
}
