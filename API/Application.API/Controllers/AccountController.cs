using API.Application.Application.Model;
using Microsoft.AspNetCore.Mvc;
using API.Application.Application.UserMediator.Command;
using Application.Application.Model;
using Application.Application.UserMediator.Query;
using Application.Application.UserMediator.Command;

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

        [HttpDelete("delete-user/{username}")]
        public async Task<ActionResult<string>> DeleteUser(string username) {
            var response = await Mediator.Send(new DeleteUserCommand{Username = username});

            return Ok(response);
        }
    }
}
