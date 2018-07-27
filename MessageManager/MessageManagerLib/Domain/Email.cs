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

    /// <summary>
    /// Guid of email
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// E-mail address of the sender
    /// </summary>
    public string SenderAddress { get; }

    /// <summary>
    /// Recipient email addresses
    /// </summary>
    public List<string> RecipientAddresses { get; }

    /// <summary>
    /// Email header
    /// </summary>
    public string SubjectText { get; }

    /// <summary>
    /// Email content
    /// </summary>
    public string BodyText { get; }

    /// <summary>
    /// Email attachment
    /// </summary>
    public Attachment Attachment_ { get; }
  }
}