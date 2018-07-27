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

    /// <summary>
    /// Adds a new message to the queue
    /// </summary>
    /// <param name="sms"></param>
    public void AddSmsToQueue(SMS sms)
    {
      if (_smsQueue.Any(message => message.Id == sms.Id))
        throw new MessageAlreadyInQueueException("SMS already in queue");
      _smsQueue.Enqueue(sms);
    }

    /// <summary>
    /// Returns the next message from the queue
    /// </summary>
    /// <returns></returns>
    public SMS GetNextSms()
    {
      return _smsQueue.Dequeue();
    }

    /// <summary>
    /// Add sms to unsent collection
    /// </summary>
    /// <param name="sms"></param>
    public void AddSmsToUnsent(SMS sms)
    { 
      if (_unsentMessages.Any(message => message.Id == sms.Id))
    throw new MessageAlreadyInQueueException("Email already added to collection of unsent");
    _unsentMessages.Add(sms);
    }

    /// <summary>
    /// Get unsent sms by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public SMS GetUnsentSms(Guid id)
    {
      SMS sms = _unsentMessages.First(message => message.Id == id);
      if (sms != null) _unsentMessages.Remove(sms);
      return sms;
    }

    /// <summary>
    /// Determines if there are more messages in the queue
    /// </summary>
    /// <returns></returns>
    public bool HasNext()
    {
      return _smsQueue.Count != 0;
    }

    /// <summary>
    /// Collection of unsent sms
    /// </summary>
    private readonly List<SMS> _unsentMessages;

    /// <summary>
    /// Collection of sms in queue
    /// </summary>
    private readonly Queue<SMS> _smsQueue;
  }
}