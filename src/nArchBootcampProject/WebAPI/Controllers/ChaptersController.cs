using Application.Features.Chapters.Commands.Create;
using Application.Features.Chapters.Commands.Delete;
using Application.Features.Chapters.Commands.Update;
using Application.Features.Chapters.Queries.GetById;
using Application.Features.Chapters.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Chapters.Queries.GetListByBootcampId;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChaptersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateChapterCommand createChapterCommand)
    {
        CreatedChapterResponse response = await Mediator.Send(createChapterCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateChapterCommand updateChapterCommand)
    {
        UpdatedChapterResponse response = await Mediator.Send(updateChapterCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedChapterResponse response = await Mediator.Send(new DeleteChapterCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdChapterResponse response = await Mediator.Send(new GetByIdChapterQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListChapterQuery getListChapterQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListChapterListItemDto> response = await Mediator.Send(getListChapterQuery);
        return Ok(response);
    }

    [HttpGet("getlistbybootcampid")]
    public async Task<IActionResult> GetListByBootcampId([FromQuery] PageRequest pageRequest,int bootcampId)
    {
        GetListChapterByBootcampIdQuery getListChapterQuery = new() { PageRequest = pageRequest ,BootcampId = bootcampId};
        GetListResponse<GetListChapterListItemDto> response = await Mediator.Send(getListChapterQuery);
        return Ok(response);
    }
}