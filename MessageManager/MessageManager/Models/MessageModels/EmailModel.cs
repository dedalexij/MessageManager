using System;
using System.Collections.Generic;

namespace MessageManager.Models.MessageModels
{
  public class EmailModel
  {
    public Guid Id { get; private set; }
    public string SenderAddress { get; private set; }
    public List<string> RecipientAddresses { get; private set; }
    public string SubjectText { get; private set; }
    public string BodyText { get; private set; }
  }
}