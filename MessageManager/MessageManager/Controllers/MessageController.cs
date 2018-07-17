using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageManager.Models.MessageModels;
using MessageManagerLib.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest;

namespace MessageManagerWebAPI.Controllers
{
  //[Authorize]
  [Route("api/message")]
  public class MessageController : Controller
  {
    public MessageController(IMessageService messageService)
    {
      _messageService = messageService;
    }

    [HttpPost]
    [Route("send/sms")]
    public IActionResult SendSms(SmsModel smsModel)
    {
      var sms = new SMS(smsModel.Id, smsModel.RecipientNumbers, smsModel.MessageText);
      if (smsModel.Queue)
        _messageService.AddSmsToQueue(sms);
      else _messageService.SendSms(sms);
      return Ok();
    }

    [HttpPost]
    [Route("send/email")]
    public IActionResult SendEmail(EmailModel emailModel)
    {
      var email = new Email(emailModel.Id, 
        emailModel.SenderAddress, 
        emailModel.RecipientAddresses, 
        emailModel.SubjectText, emailModel.BodyText, 
        emailModel.File.OpenReadStream(), emailModel.File.ContentType);

      if (emailModel.Queue)
        _messageService.AddMailToQueue(email);
      else _messageService.SendEmail(email);
      return Ok();
    }

    [HttpPut]
    [Route("queue/add/sms")]
    public IActionResult AddSmsToQueue(SmsModel smsModel)
    {
      var sms = new SMS(smsModel.Id, smsModel.RecipientNumbers, smsModel.MessageText);
      _messageService.AddSmsToQueue(sms);
      return Ok();
    }

    [HttpPut]
    [Route("queue/add/email")]
    public IActionResult AddEmailToQueue(EmailModel emailModel)
    {
      var email = new Email(emailModel.Id,
        emailModel.SenderAddress,
        emailModel.RecipientAddresses,
        emailModel.SubjectText, emailModel.BodyText,
        emailModel.File.OpenReadStream(), emailModel.File.ContentType);

      _messageService.AddMailToQueue(email);
      return Ok();
    }

    private readonly IMessageService _messageService;
  }
}