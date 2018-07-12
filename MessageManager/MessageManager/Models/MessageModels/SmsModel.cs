using System;
using System.Collections.Generic;

namespace MessageManager.Models.MessageModels
{
  public class SmsModel
  {
    public Guid Id { get; private set; }
    public List<string> RecipientNumbers { get; private set; }
    public string MessageText { get; private set; }
  }
}