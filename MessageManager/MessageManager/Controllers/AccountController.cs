using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageManager.Models.AccountModels;
using MessageManagerLib.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageManagerWebAPI.Controllers
{
  [Produces("application/json")]
  [Route("api/account")]
  public class AccountController : Controller
  {
    public AccountController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpPost]
    [Route("registration")]
    public IActionResult Registration([FromBody] RegistrationModel registrationModel)
    {
            var newUser = new User(registrationModel.FirstName, 
                registrationModel.LastName, 
                registrationModel.Email, 
                registrationModel.Password);

            _userService.RegisterUser(newUser);
      return Ok();
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] LoginModel loginModel)
    {
            var login = loginModel.Email;
            var pswd = loginModel.Password;
            var answ = CheckLogin(login, pswd);
            
      return Ok();
    }

    private readonly IUserService _userService;
  }
}