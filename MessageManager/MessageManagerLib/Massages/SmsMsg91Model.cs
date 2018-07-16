using System.Collections.Generic;
using MessageManagerLib.Domain;
using Newtonsoft.Json;

namespace MessageManagerLib.Massages
{
  public class SmsMsg91Model
  {
    [Newtonsoft.Json.JsonProperty(PropertyName = "sender")]
    public string Sender { get; set; }

    [Newtonsoft.Json.JsonProperty(PropertyName = "route")]
    public string Route { get; set; }

    [Newtonsoft.Json.JsonProperty(PropertyName = "country")]
    public string Country { get; set; }

    [Newtonsoft.Json.JsonProperty(PropertyName = "sms")]
    public List<SMS> Sms { get; set; }
  }
}