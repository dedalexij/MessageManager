using System;
using System.Collections.Generic;

namespace MessageManager.Models.MessageModels
{
  public class SmsModel
  {
    public Guid Id { get; set; }
    public List<string> RecipientNumbers { get; set; }
    public string MessageText { get; set; }
    public bool Queue { get; set; }
  }
}