using API.Application.API.Controllers;
using API.Application.Application.Model;
using API.Application.Application.UserMediator.Query;
using Application.Application.UserMediator.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Authorize]
    public class UsersController : ApiControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult<GetUserResponse>> GetUsers()
        {
            var response = await Mediator.Send(new GetUsersQuery());
            return Ok(response);
        }

        [HttpGet("{username}", Name="GetUser")]
        public async Task<ActionResult<GetUserResponse>> GetUserByUsername(string username) {
            var response = await Mediator.Send(new GetUserByUsernameQuery{
                Username = username,
            });
            return Ok(response);
        }
    }
}