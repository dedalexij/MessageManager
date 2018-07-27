using System;
using MessageManagerLib.Domain;

namespace MessageManagerLib.Application
{
  public class UserService : IUserService
  {
    public UserService(IUserRepository userRepository)
    {
      _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    /// <summary>
    /// Adds a new account to repository
    /// </summary>
    /// <param name="newUser"></param>
    public void RegisterUser(User newUser)
    {
      _userRepository.AddUser(newUser);
    }

    /// <summary>
    /// Verifies the correctness of the entered data by the user during authorization
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool Login(string email, string password)
    {
      return _userRepository.CheckLogin(email, password);
    }

    /// <summary>
    /// 
    /// </summary>
    private readonly IUserRepository _userRepository;
  }
}