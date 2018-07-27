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

    /// <summary>
    /// Adds a new user to collection
    /// </summary>
    /// <param name="newUser"></param>
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

    /// <summary>
    /// Verifies the correctness of the entered data by the user during authorization
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool CheckLogin(string email, string password)
    {
      if (_userCollection.Any(user => user.Email == email && user.Password == password))
        return true;

      return false;
    }

    /// <summary>
    /// Collection of user accounts
    /// </summary>
    private readonly List<User> _userCollection;
  }
}