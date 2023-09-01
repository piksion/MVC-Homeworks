namespace PizzaApp.Models
{
	public class Orders
	{
			public int Id { get; set; }
			public string CustomerName { get; set; }
			public int Price { get; set; }
			public bool IsDelivered { get; set; }
			public DateTime OrderDate { get; set; }
	}
}
