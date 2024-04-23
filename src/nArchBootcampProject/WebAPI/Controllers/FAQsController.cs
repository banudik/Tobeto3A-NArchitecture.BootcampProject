using Application.Features.FAQs.Commands.Create;
using Application.Features.FAQs.Commands.Delete;
using Application.Features.FAQs.Commands.Update;
using Application.Features.FAQs.Queries.GetById;
using Application.Features.FAQs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FAQsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFAQCommand createFAQCommand)
    {
        CreatedFAQResponse response = await Mediator.Send(createFAQCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFAQCommand updateFAQCommand)
    {
        UpdatedFAQResponse response = await Mediator.Send(updateFAQCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedFAQResponse response = await Mediator.Send(new DeleteFAQCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdFAQResponse response = await Mediator.Send(new GetByIdFAQQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFAQQuery getListFAQQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListFAQListItemDto> response = await Mediator.Send(getListFAQQuery);
        return Ok(response);
    }
}