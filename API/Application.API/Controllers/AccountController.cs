using API.Application.Application.UserMediator.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Application.API.Controllers
{
    [Authorize]
    public class AccountController : ApiControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<RegisterUserCommand>> Register(RegisterUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
