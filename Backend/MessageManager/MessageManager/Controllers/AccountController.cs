using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageManager.Models.AccountModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageManagerWebAPI.Controllers
{
  [Produces("application/json")]
  [Route("api/account")]
  public class AccountController : Controller
  {
    public AccountController()
    {
    }

    [HttpPost]
    [Route("registration")]
    public IActionResult Registration([FromBody] RegistrationModel registrationModel)
    {
      return Ok();
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] LoginModel loginModel)
    {
      return Ok();
    }
  }
}