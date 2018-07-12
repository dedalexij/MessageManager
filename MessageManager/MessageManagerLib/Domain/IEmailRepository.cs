using System;
using System.Collections.Generic;

namespace MessageManagerLib.Domain
{
  public interface IEmailRepository
  {
    void AddMailToQueue(Email email);
    Email GetNextMail();
    void AddMailToUnsent(Email email);
    Email GetUnsentMail(Guid id);
  }
}