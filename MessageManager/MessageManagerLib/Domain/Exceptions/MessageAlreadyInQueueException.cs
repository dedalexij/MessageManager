using System;
using System.Runtime.Serialization;

namespace MessageManagerLib.Domain.Exceptions
{
  public class MessageAlreadyInQueueException : Exception
  {
    public MessageAlreadyInQueueException()
    {
    }

    public MessageAlreadyInQueueException(string message) : base(message)
    {
    }

    public MessageAlreadyInQueueException(string message, Exception inner) : base(message, inner)
    {
    }

    protected MessageAlreadyInQueueException(SerializationInfo info, StreamingContext context)
    {
    }
  }
}