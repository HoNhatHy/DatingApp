using API.Application.Application.Model;
using Microsoft.AspNetCore.Mvc;
using API.Application.Application.UserMediator.Command;
using API.Application.Application.UserMediator.Query;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        [HttpGet()]
        public async Task<ActionResult<GetUserResponse>> GetUsers()
        {
            var response = await Mediator.Send(new GetUserQuery());
            return Ok(response);
        }
    }
}
