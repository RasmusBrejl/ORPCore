﻿using ORP.Models;
using ORP.Models.Context;
using System.Linq;

namespace ORP.Business.Repositories
{
    public class UserRepository
    {
        public User LogIn(User user)
        {
            using (var context = new OrpContext())
            {
                return context.Users.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            }
        }

        public User GetUser(int userId)
        {
            using (var context = new OrpContext())
            {
                return context.Users.FirstOrDefault(x => x.UserId == userId);
            }
        }
    }
}