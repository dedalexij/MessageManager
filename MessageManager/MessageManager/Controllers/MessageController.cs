using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageManager.Models.MessageModels;
using MessageManagerLib.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageManagerWebAPI.Controllers
{
  [Produces("application/json")]
  [Route("api/message")]
  public class MessageController : Controller
  {
    public MessageController(IMessageService messageService)
    {
      _messageService = messageService;
    }

    [HttpPut]
    [Route("send/sms")]
    public IActionResult SendSms([FromBody] SmsModel smsModel)
    {
      var sms = new SMS(smsModel.Id, smsModel.RecipientNumbers, smsModel.MessageText);
      _messageService.SendSms(sms);
      return Ok();
    }

    [HttpPut]
    [Route("send/email")]
    public IActionResult SendEmail([FromBody] EmailModel emailModel)
    {
      var email = new Email(emailModel.Id, 
        emailModel.SenderAddress, 
        emailModel.RecipientAddresses, 
        emailModel.SubjectText, emailModel.BodyText);

      _messageService.SendEmail(email);
      return Ok();
    }

    [HttpPut]
    [Route("queue/add/sms")]
    public IActionResult AddSmsToQueue([FromBody] SmsModel smsModel)
    {
      var sms = new SMS(smsModel.Id, smsModel.RecipientNumbers, smsModel.MessageText);
      _messageService.AddSmsToQueue(sms);
      return Ok();
    }

    [HttpPut]
    [Route("queue/add/email")]
    public IActionResult AddEmailToQueue([FromBody] EmailModel emailModel)
    {
      var email = new Email(emailModel.Id,
        emailModel.SenderAddress,
        emailModel.RecipientAddresses,
        emailModel.SubjectText, emailModel.BodyText);

      _messageService.AddMailToQueue(email);
      return Ok();
    }

    private readonly IMessageService _messageService;
  }
}