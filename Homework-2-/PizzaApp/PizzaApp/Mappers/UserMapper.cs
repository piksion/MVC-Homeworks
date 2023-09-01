using PizzaApp.Models;
using PizzaApp.ViewModels;

namespace PizzaApp.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel UserToUserViewModel (User userDb)
        {
            return new UserViewModel
            {
                UserFullName = $"{userDb.FirstName} {userDb.LastName}"
            };
        }
    }
}
