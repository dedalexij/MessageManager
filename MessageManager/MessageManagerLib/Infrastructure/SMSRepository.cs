using System;
using System.Collections.Generic;
using System.Linq;
using MessageManagerLib.Domain;
using MessageManagerLib.Domain.Exceptions;

namespace MessageManagerLib.Infrastructure
{
  public class SMSRepository : ISMSRepository
  {
    public SMSRepository()
    {
      _unsentMessages = new List<SMS>();
      _smsQueue =  new Queue<SMS>();
    }

    public void AddSmsToQueue(SMS sms)
    {
      if (_smsQueue.Any(message => message.Id == sms.Id))
        throw new MessageAlreadyInQueueException("SMS already in queue");
      _smsQueue.Enqueue(sms);
    }

    public SMS GetNextSms()
    {
      return _smsQueue.Dequeue();
    }

    public void AddSmsToUnsent(SMS sms)
    { 
      if (_unsentMessages.Any(message => message.Id == sms.Id))
    throw new MessageAlreadyInQueueException("Email already added to collection of unsent");
    _unsentMessages.Add(sms);
    }

    public SMS GetUnsentSms(Guid id)
    {
      SMS sms = _unsentMessages.First(message => message.Id == id);
      if (sms != null) _unsentMessages.Remove(sms);
      return sms;
    }

    private readonly List<SMS> _unsentMessages;
    private readonly Queue<SMS> _smsQueue;
  }
}