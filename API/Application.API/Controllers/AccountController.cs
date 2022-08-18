using API.Application.Application.Model;
using Microsoft.AspNetCore.Mvc;
using API.Application.Application.UserMediator.Command;
using Application.Application.Model;
using Application.Application.UserMediator.Query;

namespace API.Application.API.Controllers
{
    public class AccountController : ApiControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserRegisterResponse>> Register([FromBody] RegisterUserCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponse>> Login([FromBody] LoginUserQuery query) {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
