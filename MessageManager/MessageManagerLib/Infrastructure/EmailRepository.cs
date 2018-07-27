using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using MessageManagerLib.Domain;
using MessageManagerLib.Domain.Exceptions;

namespace MessageManagerLib.Infrastructure
{
  public class EmailRepository : IEmailRepository  
  {
    public EmailRepository()
    {
      _emailQueue = new Queue<Email>();
      _unsentMessages = new List<Email>();
    }

    /// <summary>
    /// Adds a new message to the queue
    /// </summary>
    /// <param name="email"></param>
    public void AddMailToQueue(Email email)
    {
      if(_emailQueue.Any(message => message.Id == email.Id))
        throw new MessageAlreadyInQueueException("Email already in queue");
      _emailQueue.Enqueue(email);
    }

    /// <summary>
    /// Returns the next message from the queue
    /// </summary>
    /// <returns></returns>
    public Email GetNextMail()
    {
      return _emailQueue.Dequeue();
    }

    /// <summary>
    /// Add mail to unsent collection
    /// </summary>
    /// <param name="email"></param>
    public void AddMailToUnsent(Email email)
    {
      if (_unsentMessages.Any(message => message.Id == email.Id))
        throw new MessageAlreadyInQueueException("Email already added to collection of unsent");
      _unsentMessages.Add(email);
    }

    /// <summary>
    /// Get unsent mail by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Email GetUnsentMail(Guid id)
    {
      Email email = _unsentMessages.First(mail => mail.Id == id);
      if (email != null) _unsentMessages.Remove(email);
      return email;
    }

    /// <summary>
    /// Determines if there are more messages in the queue
    /// </summary>
    /// <returns></returns>
    public bool HasNext()
    {
      return _emailQueue.Count != 0;
    }

    /// <summary>
    /// Collection of unsent emails
    /// </summary>
    private readonly List<Email> _unsentMessages;

    /// <summary>
    /// Collection of mails in queue
    /// </summary>
    private readonly Queue<Email> _emailQueue;
  }
}