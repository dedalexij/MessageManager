using System.Collections.Generic;

namespace MessageManagerLib.Domain
{
  public interface IUserRepository
  {
    void AddUser(User newUser);
    List<User> UserCollection { get; }
  }
}