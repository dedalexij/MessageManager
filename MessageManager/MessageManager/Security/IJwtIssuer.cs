namespace MessageManager.Security
{
  public interface IJwtIssuer
  {
    string IssueJwt(string id);
  }
}