using ORP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ORP.Business.Repositories;

namespace ORP.Buisness.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public User GetUser(int userID)
        {
            return _userRepository.GetUser(userID);
        }

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool UserHasClearance(User user, String ClearanceName)
        {
            return user.Clearance.Name.Equals(ClearanceName);
        }

        public User TryLogIn(User user)
        {
            return _userRepository.LogIn(user);
        }
    }
}