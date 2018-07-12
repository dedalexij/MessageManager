using System;

namespace MessageManagerLib.Domain
{
  public interface ISMSRepository
  {
    void AddSmsToQueue(SMS sms);
    SMS GetNextSms();
    void AddSmsToUnsent(SMS sms);
    SMS GetUnsentSms(Guid id);
  }
}