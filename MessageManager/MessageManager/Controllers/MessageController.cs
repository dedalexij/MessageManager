using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageManager.Models.MessageModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageManagerWebAPI.Controllers
{
  [Produces("application/json")]
  [Route("api/message")]
  public class MessageController : Controller
  {
    public MessageController()
    {
    }

    [HttpPut]
    [Route("send/sms")]
    public IActionResult SendSms([FromBody] SmsModel smsModel)
    {
      return Ok();
    }

    [HttpPut]
    [Route("send/email")]
    public IActionResult SendEmail([FromBody] EmailModel emailModel)
    {
      return Ok();
    }
  }
}