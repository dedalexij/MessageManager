using System;
using System.Collections.Generic;

namespace MessageManager.Models.MessageModels
{
  public class SmsModel
  {
    public string SenderNumber { get; private set; }
    public string RecipientNumbers { get; private set; }
    public string MessageText { get; private set; }
  }
}