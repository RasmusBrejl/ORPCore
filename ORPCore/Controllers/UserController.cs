using Microsoft.AspNetCore.Mvc;
using ORPCore.Business.Repositories;
using ORPCore.Business.Services;
using ORPCore.Models;

namespace ORPCore.Controllers
{

    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService(new UserRepository());
        }

        [HttpGet]
        public bool CreateUser()
        {
            var repo = new TestRepository();
            repo.AddUser();
            return true;
        }

        [HttpGet]
        public User GetUser(string username, string password)
        {
            var user = new User
            {
                Name = username,
                Password = password
            };
            user = _userService.TryLogIn(user);
            return user;
        }
    }
}