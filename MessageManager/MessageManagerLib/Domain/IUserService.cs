namespace MessageManagerLib.Domain
{
  public interface IUserService
  {
    void RegisterUser(User newUser);
    bool Login(string email, string password);
  }
}