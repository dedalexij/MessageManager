using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace MessageManager.Models.MessageModels
{
  public class EmailModel
  {
    public Guid Id { get; set; }
    public string SenderAddress { get; set; }
    public List<string> RecipientAddresses { get; set; }
    public string SubjectText { get; set; }
    public string BodyText { get; set; }
    public IFormFile File { get; set; }
    public bool Queue { get; set; }
  }
}