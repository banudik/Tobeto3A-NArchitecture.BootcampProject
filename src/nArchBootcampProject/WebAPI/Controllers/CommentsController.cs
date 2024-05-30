using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using Application.Features.Comments.Queries.GetById;
using Application.Features.Comments.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Bootcamps.Queries.GetList;
using Application.Features.Bootcamps.Queries.getListDynamic;
using NArchitecture.Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCommentCommand createCommentCommand)
    {
        CreatedCommentResponse response = await Mediator.Send(createCommentCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCommentCommand updateCommentCommand)
    {
        UpdatedCommentResponse response = await Mediator.Send(updateCommentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCommentResponse response = await Mediator.Send(new DeleteCommentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCommentResponse response = await Mediator.Send(new GetByIdCommentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCommentQuery getListCommentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCommentListItemDto> response = await Mediator.Send(getListCommentQuery);
        return Ok(response);
    }

    [HttpPost("dynamic")]
    public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamic)
    {
        GetListBootcampDynamicQuery bootcampDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
        GetListResponse<GetListBootcampListItemDto> response = await Mediator.Send(bootcampDynamicQuery);
        return Ok(response);

    }
}