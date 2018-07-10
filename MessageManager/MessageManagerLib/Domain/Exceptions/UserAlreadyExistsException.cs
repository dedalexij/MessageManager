using System;
using System.Runtime.Serialization;

namespace MessageManagerLib.Domain.Exceptions
{
  public class UserAlreadyExistsException : Exception
  {
    public UserAlreadyExistsException()
    {
    }

    public UserAlreadyExistsException(string message) : base(message)
    {
    }

    public UserAlreadyExistsException(string message, Exception inner) : base(message, inner)
    {
    }

    protected UserAlreadyExistsException(SerializationInfo info, StreamingContext context)
    {
    }
  }
}