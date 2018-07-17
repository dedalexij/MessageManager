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

    [JsonIgnore]
    public Guid Id { get; }

    [JsonProperty("to")]
    public List<string> RecipientNumbers { get; }

    [JsonProperty("message")]
    public string MessageText { get; }
  }
}