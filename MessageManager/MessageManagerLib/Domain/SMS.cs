using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MessageManagerLib.Domain
{
  [JsonObject(MemberSerialization.OptIn)]
  public class SMS
  {
    public SMS(Guid id, List<string> recipientNumbers, string messageText)
    {
      Id = id;
      RecipientNumbers = recipientNumbers ?? throw new ArgumentNullException(nameof(recipientNumbers));
      MessageText = messageText ?? throw new ArgumentNullException(nameof(messageText));
    }

    /// <summary>
    /// Guid of SMS message
    /// </summary>
    [JsonIgnore]
    public Guid Id { get; }

    /// <summary>
    /// Message recipient numbers
    /// </summary>
    [JsonProperty("to")]
    public List<string> RecipientNumbers { get; }

    /// <summary>
    /// SMS message text
    /// </summary>
    [JsonProperty("message")]
    public string MessageText { get; }
  }
}