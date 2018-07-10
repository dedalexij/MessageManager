using System;

namespace MessageManagerLib.Domain
{
  public class User
  {
    public User(string firstName, string lastName, string email, string password)
    {
      FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
      LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
      Email = email ?? throw new ArgumentNullException(nameof(email));
      Password = password ?? throw new ArgumentNullException(nameof(password));
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
  }
}