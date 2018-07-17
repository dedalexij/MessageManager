using System;
using System.Collections.Generic;
using System.Net.Mail;
using MessageManagerLib.Domain;
using MessageManagerLib.Massages;
using Newtonsoft.Json;
using RestSharp;

namespace MessageManagerLib.Application
{
  public class MessageService : IMessageService
  {
    public MessageService(IEmailRepository emailRepository, ISMSRepository smsRepository)
    {
      this._emailRepository = emailRepository ?? throw new ArgumentNullException(nameof(emailRepository));
      this._smsRepository = smsRepository ?? throw new ArgumentNullException(nameof(smsRepository));
    }

    public void SendSms(SMS sms)
    {
      var client = new RestClient("http://api.msg91.com/api/v2/sendsms");
      var request = new RestRequest(Method.POST);

      var smsModel = new SmsMsg91Model()
      {
        Country = "7",
        Route = "1",
        Sender = "senderId",
        Sms = new List<SMS>() {sms}
      };

      var jsonSms = JsonConvert.SerializeObject(smsModel);

      request.AddHeader("content-type", "application/json");
      request.AddHeader("authkey", "");
      request.AddParameter("application/json", jsonSms, ParameterType.RequestBody);

      IRestResponse response = client.Execute(request);

    }

    public void SendEmail(Email email)
    {
      var client = new SmtpClient();
      var message = new MailMessage();

      message.Sender = new MailAddress("a@a.com");
      message.Body = email.BodyText;
      message.Subject = email.SubjectText;
      message.Attachments.Add(email.Attachment_);
      email.RecipientAddresses.ForEach(address => message.To.Add(address));

      client.Send(message);

    }

    public void SendSmsFromQueue()
    {
      if (_smsRepository.HasNext())
      {
        SendSms(_smsRepository.GetNextSms());
      }
    }

    public void SendEmailFromQueue()
    {
      if (_emailRepository.HasNext())
      {
        SendEmail(_emailRepository.GetNextMail());
      }
    }

    public void AddSmsToQueue(SMS sms)
    {
      _smsRepository.AddSmsToQueue(sms);
    }

    public void AddMailToQueue(Email email)
    {
      _emailRepository.AddMailToQueue(email);
    }

    private readonly IEmailRepository _emailRepository;
    private readonly ISMSRepository _smsRepository;
  }
}