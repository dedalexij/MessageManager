using System;
using MessageManagerLib.Domain;

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
      
    }

    public void SendEmail(Email email)
    {

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