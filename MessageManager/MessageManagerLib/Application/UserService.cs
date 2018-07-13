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

    public void RegisterUser(User newUser)
    {
      _userRepository.AddUser(newUser);
    }

    public bool CheckLogin(string email, string password)
    {
      return _userRepository.CheckLogin(email, password);
    }

    private readonly IUserRepository _userRepository;
  }
}