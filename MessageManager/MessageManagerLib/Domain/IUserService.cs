namespace MessageManagerLib.Domain
{
    public interface IUserService
    {
        void RegisterUser(User newUser);
        bool CheckLogin(string email, string password);
    }
}