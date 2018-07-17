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
      var sms = new SmsMsg91Model()
      {
        Country = "7",
        Route = "1",
        Sender = "asfdaf",
        Sms = new List<SMS>() {new SMS(Guid.NewGuid(), new List<string>() {"123456789"}, "asffgsfd")}
      };

      var json = JsonConvert.SerializeObject(sms);
    }
  }
}
