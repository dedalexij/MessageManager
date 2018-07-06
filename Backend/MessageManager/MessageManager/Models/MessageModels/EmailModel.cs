using System.Collections.Generic;

namespace MessageManager.Models.MessageModels
{
  public class EmailModel
  {
    public string SenderAddress { get; private set; }
    public List<string> RecipientAddresses { get; private set; }
    public string SubjectText { get; private set; }
    public string BodyText { get; private set; }
  }
}