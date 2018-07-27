using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageManager.Models.AccountModels;
using MessageManager.Security;
using MessageManagerLib.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageManagerWebAPI.Controllers
{
  [Route("api/account")]
  public class AccountController : Controller
  {
    public AccountController(IUserService userService, IJwtIssuer jwtIssuer)
    {
      _userService = userService;
      _jwtIssuer = jwtIssuer;
    }

    [HttpPost]
    [Route("registration")]
    public IActionResult Registration(RegistrationModel registrationModel)
    {
      var newUser = new User(registrationModel.FirstName,
          registrationModel.LastName,
          registrationModel.Email,
          registrationModel.Password);

      _userService.RegisterUser(newUser);

      var token = _jwtIssuer.IssueJwt(registrationModel.Email);
      return Ok(token);
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromForm] LoginModel loginModel)
    {
      var login = loginModel.Email;
      var pswd = loginModel.Password;
      var answ = _userService.Login(login, pswd);

      if (!answ)
      {
        return BadRequest();
      }

      var token = _jwtIssuer.IssueJwt(loginModel.Email);
      return Ok(token);
    }

    private readonly IUserService _userService;
    private readonly IJwtIssuer _jwtIssuer;
  }
}