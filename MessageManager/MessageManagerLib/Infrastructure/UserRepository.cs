using System;
using System.Collections.Generic;
using System.Linq;
using MessageManagerLib.Domain;
using MessageManagerLib.Domain.Exceptions;

namespace MessageManagerLib.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            UserCollection = new List<User>();
        }

        public void AddUser(User newUser)
        {
            if (!UserCollection.Any(user => user.Email == newUser.Email))
            {
                UserCollection.Add(newUser);
            }
            else
            {
                throw new UserAlreadyExistsException("User already exists");
            }
        }

        public bool CheckLogin(string email, string password)
        {
            User check = new User("", "", email, password);
            if (!UserCollection.Any(user => user.Email == check.Email) && !UserCollection.Any(user => user.Password == check.Email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> UserCollection { get; private set; }
    }
}