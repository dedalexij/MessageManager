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
      _userCollection = new List<User>();
    }

    public void AddUser(User newUser)
    {
      if (_userCollection.All(user => user.Email != newUser.Email))
      {
        _userCollection.Add(newUser);
      }
      else
      {
        throw new UserAlreadyExistsException("User already exists");
      }
    }

    public bool CheckLogin(string email, string password)
    {
      if (_userCollection.Any(user => user.Email == email && user.Password == password))
        return true;

      return false;
    }

    private readonly List<User> _userCollection;
  }
}