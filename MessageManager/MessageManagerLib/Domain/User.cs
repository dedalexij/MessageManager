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
    /// <summary>
    /// First name of the user
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Last name of the user
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Email address of the user
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Password of the user
    /// </summary>
    public string Password { get; private set; }
  }
}