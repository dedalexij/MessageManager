using System;
using System.Collections.Generic;

namespace MessageManagerLib.Domain
{
  public class Email
  {
    public Email(Guid id, string senderAddress, List<string> recipientAddresses, string subjectText, string bodyText)
    {
      Id = id;
      SenderAddress = senderAddress ?? throw new ArgumentNullException(nameof(senderAddress));
      RecipientAddresses = recipientAddresses ?? throw new ArgumentNullException(nameof(recipientAddresses));
      SubjectText = subjectText ?? throw new ArgumentNullException(nameof(subjectText));
      BodyText = bodyText ?? throw new ArgumentNullException(nameof(bodyText));
    }

    public Guid Id { get; }
    public string SenderAddress { get; }
    public List<string> RecipientAddresses { get; }
    public string SubjectText { get; }
    public string BodyText { get; }
  }
}