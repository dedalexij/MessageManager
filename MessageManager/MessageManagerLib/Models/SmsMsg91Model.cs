using System.Collections.Generic;
using MessageManagerLib.Domain;
using Newtonsoft.Json;

namespace MessageManagerLib.Massages
{
  /// <summary>
  /// Sms model for service msg91
  /// </summary>
  [JsonObject]
  public class SmsMsg91Model
  {
    [JsonProperty(PropertyName = "sender")]
    public string Sender { get; set; }

    [JsonProperty(PropertyName = "route")]
    public string Route { get; set; }

    [JsonProperty(PropertyName = "country")]
    public string Country { get; set; }

    [JsonProperty("sms")]
    public List<SMS> Sms { get; set; }
  }
}