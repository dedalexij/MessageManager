using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MessageManager.Security
{
  public class JwtIssuer
  {
    private readonly SecuritySettings _securitySettings;

    public JwtIssuer(SecuritySettings securitySettings)
    {
      _securitySettings = securitySettings;
    }

    public string IssueJwt(string id)
    {
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securitySettings.EncryptionKey));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var claims = new Claim[]
      {
        new Claim("UserId", id)
      };
      var token = new JwtSecurityToken(_securitySettings.Issue, claims: claims,
        expires: DateTime.UtcNow.Add(_securitySettings.ExpirationPeriod),
        signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
