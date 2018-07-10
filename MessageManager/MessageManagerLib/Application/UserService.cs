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

    private readonly IUserRepository _userRepository;
  }
}