using API.Application.Application.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Application.Application.UserMediator.Command;

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

        [HttpGet("get")]
        public ActionResult GetUsers()
        {
            return Ok("Those are users");
        }
    }
}
