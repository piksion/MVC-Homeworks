using Microsoft.AspNetCore.Mvc;
using PizzaApp.Mappers;
using PizzaApp.Models;
using PizzaApp.Models.Enums;
using PizzaApp.ViewModels;

namespace PizzaApp.Controllers
{
	
	public class OrderController : Controller
	{
		public IActionResult GetAllOrders()
		{
			//domain model. they represent our enttites(tables)
			//we mainly use in the business logic, reading from db...
			List<Order> ordersDb = StaticDb.Orders;

			//in most cases we don't send domain models to the UI
			//they contain extra data, sensitive data, maybe we need to modify data
			//return View(ordersDb);

			//we send viewmodels to the views
			//FIRST WAY
			//List<OrderListViewModel> orderListViewModels = new List<OrderListViewModel>();
			//foreach (Order order in ordersDb)
			//{
			//	OrderListViewModel orderListViewModel = new OrderListViewModel
			//	{
			//		PizzaName = order.Pizza.Name,
			//		UserViewModel = $"{order.User.FirstName} {order.User.FirstName}"
			//	};
			//	orderListViewModels.Add(orderListViewModel);
			//}

			////SECOND WAY
			//List<OrderListViewModel> orderListViewModels = ordersDb.Select(x => new OrderListViewModel
			//{
			//	PizzaName = x.Pizza.Name,
			//	UserViewModel = $"{x.User.FirstName} {x.User.LastName}"
			//}).ToList();	

			//THIRD WAY
			List<OrderListViewModel> orderListViewModels =
				ordersDb.Select(x => OrderMapper.OrderToOrderListViewModel(x)).ToList();
			return View(orderListViewModels);
		}

		//we want to get the details for an order with a given id
		// we want to show: user fullname, pizza name, price (price of pizza + 50 for delivery), payment nethod

		public IActionResult DetailsExample(int? id) 
		{
			if(id == null)
			{
				return RedirectToAction("Error", "Home");
			}

			Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
			if(orderDb == null)
			{
				return RedirectToAction("Error", "Home");
			}
			//we need to send title that will be displayed in the Header tag
			ViewData["Title"] = "Order details";
			ViewData["DateTime"] = DateTime.Now.ToShortDateString();

			//we need to map from domain mode (entity from db) to view model
			OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);

			//OrderDetailsViewModel orderDetailsViewModel1 = new OrderDetailsViewModel

			//	{
			//	PizzaName = orderDb.Pizza.Name,
			//	UserViewModel = $"{orderDb.User.FirstName} {orderDb.User.LastName}",
			//	OrderPrice = orderDb.Pizza.Price + 50,
			//	PaymentMethod = orderDb.PaymentMethod.ToString(),
			//};
			ViewBag.User = orderDb.User;

			return View(orderDetailsViewModel);

		}

		public IActionResult Details(int? id) 
		{ 
			if(id == null)
			{
				//return the GeneralError View.First look in Order folder,the in Shared folder
				return View("GeneralError", new GeneralErrorViewModel
				{
					ErrorMessage = "You must proviede an id to view details!"
				});
			}
			Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
			if( orderDb == null)
			{
				return View("ResourceNotFound");
			}
			ViewData["Title"] = "Order details";

			OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);
			return View(orderDetailsViewModel);
			
		}
		public IActionResult Delete(int id)
		{
			if(id <= 0)
			{
				return View("GeneralError", new GeneralErrorViewModel
				{
					ErrorMessage = "Id is invalid"
				});
			}
			
			Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
			if(orderDb == null)
			{
				return View("ResourceNotFound");
			}
			OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);
			return View(orderDetailsViewModel);
		}
	}
}
