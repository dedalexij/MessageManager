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

    public void AddMailToQueue(Email email)
    {
      if(_emailQueue.Any(message => message.Id == email.Id))
        throw new MessageAlreadyInQueueException("Email already in queue");
      _emailQueue.Enqueue(email);
    }

    public Email GetNextMail()
    {
      return _emailQueue.Dequeue();
    }

    public void AddMailToUnsent(Email email)
    {
      if (_unsentMessages.Any(message => message.Id == email.Id))
        throw new MessageAlreadyInQueueException("Email already added to collection of unsent");
      _unsentMessages.Add(email);
    }

    public Email GetUnsentMail(Guid id)
    {
      Email email = _unsentMessages.First(mail => mail.Id == id);
      if (email != null) _unsentMessages.Remove(email);
      return email;
    }

    private readonly List<Email> _unsentMessages;
    private readonly Queue<Email> _emailQueue;
  }
}