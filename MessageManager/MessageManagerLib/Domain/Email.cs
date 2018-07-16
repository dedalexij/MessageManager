using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace MessageManagerLib.Domain
{
  public class Email
  {
    public Email(Guid id, string senderAddress, List<string> recipientAddresses, 
      string subjectText, string bodyText, Stream attachmentStream, string contentType)
    {
      Attachment_ = new Attachment(attachmentStream, new ContentType(contentType));
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
    public Attachment Attachment_ { get; }
  }
}