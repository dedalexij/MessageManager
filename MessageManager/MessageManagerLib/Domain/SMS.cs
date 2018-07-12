using System;
using System.Collections.Generic;

namespace MessageManagerLib.Domain
{
  public class SMS
  {
    public SMS(Guid id, List<string> recipientNumbers, string messageText)
    {
      Id = id;
      RecipientNumbers = recipientNumbers ?? throw new ArgumentNullException(nameof(recipientNumbers));
      MessageText = messageText ?? throw new ArgumentNullException(nameof(messageText));
    }

    public Guid Id { get; private set; }
    public List<string> RecipientNumbers { get; private set; }
    public string MessageText { get; private set; }
  }
}