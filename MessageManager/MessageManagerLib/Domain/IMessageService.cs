namespace MessageManagerLib.Domain
{
  public interface IMessageService
  {
    void SendSms(SMS sms);
    void SendEmail(Email email);
    void AddSmsToQueue(SMS sms);
    void AddMailToQueue(Email email);
  }
}