using API.Application.API.Controllers;
using API.Application.Application.Model;
using API.Application.Application.PhotoMediatr;
using API.Application.Application.UserMediator.Query;
using Application.Application.Model;
using Application.Application.PhotoMediatr;
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

        [HttpPost("add-photo")]
        public async Task<ActionResult<AddPhotoResponse>> AddPhoto([FromForm] AddPhotoCommand command) {
            AddPhotoResponse response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPatch("set-main-photo")]
        public async Task<ActionResult<SetMainPhotoResponse>> SetMainPhoto([FromBody] SetMainPhotoCommand command) {
            try {
                SetMainPhotoResponse response = await Mediator.Send(command);

                return Ok(response);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-photo")]
        public async Task<ActionResult<string>> DeletePhoto([FromBody] DeletePhotoCommand command) {
            try {
                string response = await Mediator.Send(command);

                return Ok(response);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}