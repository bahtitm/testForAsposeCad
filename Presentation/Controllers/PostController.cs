using Application.Posts.Commands.CreatePost;
using Application.Posts.Commands.DeleteDocument;
using Application.Posts.Commands.UpdateDocument;
using Application.Posts.Queries.GetAll;
using Application.Posts.Queries.GetDetail;
using Application.Posts.Queries.GetSearchedPost;
using Domain.Enums;
using ForAspose.Authorization.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForAspose.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator mediator;
        public PostController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //[PermissionRequirement(ClaimType.Post, ClaimValue.Read)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await mediator.Send(new GetAllPostQuery()));
        }

        //[PermissionRequirement(ClaimType.Post, ClaimValue.Read)]
        [HttpGet("search")]
        public async Task<IActionResult> Search(string search)
        {

            return Ok(await mediator.Send(new GetSearchedPostQuery(search)));
        }

        //[PermissionRequirement(ClaimType.Post, ClaimValue.Read)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetDetailPostQuery(id)));
        }

        

        

        //[PermissionRequirement(ClaimType.Post, ClaimValue.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        

        //[PermissionRequirement(ClaimType.Post, ClaimValue.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePostCommand command)
        {
            //if (id != command.Id)
            //{
            //    return BadRequest($"Check request: {id} not equals {command.Id}");
            //}
            command.Id = id;
            await mediator.Send(command);
            return NoContent();
        }

        //[PermissionRequirement(ClaimType.Post, ClaimValue.FullAccess)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeletePostCommand(id));
            return NoContent();
        }
    }
}
