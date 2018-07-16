using System;
using System.Collections.Generic;
using MessageManagerLib.Domain;
using MessageManagerLib.Massages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace MessageManagerUnitTests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      var smsModel = new SmsMsg91Model
      {
        Country = "7",
        Route = "1",
        Sender = "1",
        Sms = new List<SMS>() {new SMS(Guid.NewGuid(), new List<string>() {"123456789"}, "KEK")}
      };

      var jsonMessage = JsonConvert.SerializeObject(smsModel);

      int i = 1;
    }
  }
}
