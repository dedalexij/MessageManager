using System.Collections.Generic;

namespace MessageManagerLib.Domain
{
  public interface IUserRepository
  {
    void AddUser(User newUser);
    bool CheckLogin(string email, string password);
  }
}