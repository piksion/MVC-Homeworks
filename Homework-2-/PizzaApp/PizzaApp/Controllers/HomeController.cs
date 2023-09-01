using Microsoft.AspNetCore.Mvc;
using PizzaApp.Mappers;
using PizzaApp.Models;
using PizzaApp.ViewModels;
using System.Diagnostics;

namespace PizzaApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
		[Route("AboutUs")]
		public IActionResult AboutUs()
		{
			return View();
		}
		public IActionResult Contact()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		public IActionResult SeeUsers()
		{
			List<User> users = StaticDb.Users;

			List<UserViewModel> usersViewModel = users.Select(x => UserMapper.UserToUserViewModel(x)).ToList();	

			return View(usersViewModel);
		}
	}
}