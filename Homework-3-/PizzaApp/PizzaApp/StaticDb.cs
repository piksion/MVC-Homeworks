using PizzaApp.Models;

namespace PizzaApp
{
	public static class StaticDb
	{
		public static List<Pizza> pizzas = new List<Pizza>()
		{
			new Pizza()
			{
				Id = 1,
				Name = "Capri",
				Price = 350,
				IsOnPromotion = true,
			},
			new Pizza()
			{
				Id= 2,
				Name = "Pepperoni",
				Price = 400,
				IsOnPromotion = true,
			}
		};
		public static List<Orders> Orders = new List<Orders>()
		{
			new Orders()
			{
				Id = 1,
				Price = 300,
				IsDelivered = false,
				CustomerName = "Vecko",
				OrderDate = new DateTime(2021, 6, 1)
			},
			new Orders()
			{
				 Id = 2,
				Price = 350,
				IsDelivered = true,
				CustomerName = "Petar",
				OrderDate = new DateTime(2022, 8, 10)
			},
			new Orders()
			{

				Id = 3,
				Price = 230,
				IsDelivered = true,
				CustomerName = "Jovana",
				OrderDate = new DateTime(2020, 2, 16)

			}
		};
		public static List<Users> Users = new List<Users>()
		{
			new Users()
			{
				Id = 1,
				UserName = "piksion",
				FirstName = "Petar",
				LastName = "Bozinoski"
			},
			new Users() 
			{
				Id = 2,
				UserName = "princess",
				FirstName = "Jovana",
				LastName = "Bozinoska"
			}
		};

	}
}
