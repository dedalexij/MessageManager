using System;

namespace MessageManager.Security
{
  public class SecuritySettings
  {
    public SecuritySettings(string encryptionKey, string issue, TimeSpan expirationPeriod)
    {
      EncryptionKey = encryptionKey ?? throw new ArgumentNullException(nameof(encryptionKey));
      Issue = issue ?? throw new ArgumentNullException(nameof(issue));
      ExpirationPeriod = expirationPeriod;
    }

    public string EncryptionKey { get; }
    public string Issue { get; }
    public TimeSpan ExpirationPeriod { get; }
  }
}
