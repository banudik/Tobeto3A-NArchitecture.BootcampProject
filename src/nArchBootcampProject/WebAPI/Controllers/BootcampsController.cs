using Application.Features.Bootcamps.Commands.Create;
using Application.Features.Bootcamps.Commands.Delete;
using Application.Features.Bootcamps.Commands.Update;
using Application.Features.Bootcamps.Queries.GetById;
using Application.Features.Bootcamps.Queries.GetList;
using Application.Features.Bootcamps.Queries.GetListByApplicationId;
using Application.Features.Bootcamps.Queries.GetListByBootcampState;
using Application.Features.Bootcamps.Queries.GetListByInstructorId;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BootcampsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] CreateBootcampCommand createBootcampCommand)
    {
        CreatedBootcampResponse response = await Mediator.Send(createBootcampCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UpdateBootcampCommand updateBootcampCommand)
    {
        UpdatedBootcampResponse response = await Mediator.Send(updateBootcampCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedBootcampResponse response = await Mediator.Send(new DeleteBootcampCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdBootcampResponse response = await Mediator.Send(new GetByIdBootcampQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBootcampQuery getListBootcampQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBootcampListItemDto> response = await Mediator.Send(getListBootcampQuery);
        return Ok(response);
    }

    [HttpGet("getbootcampListByBootcampNameSearch")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, string? Search, Guid? instructorId)
    {
        GetListByContainsBootcampNameQuery getListBootcampQuery = new() { PageRequest = pageRequest, Search = Search, InstructorId = instructorId };
        GetListResponse<GetListBootcampListItemDto> response = await Mediator.Send(getListBootcampQuery);
        return Ok(response);
    }

    [HttpGet("getbootcampbyinstructorid")]
    public async Task<IActionResult> GetListBootcampByInstructorId([FromQuery] PageRequest pageRequest, Guid instructorId)
    {
        GetListBootcampByInstructorIdQuery query = new() { PageRequest = pageRequest, InstructorId = instructorId };
        var result = await Mediator.Send(query);
        return Ok(result);
    }


    [HttpGet("getbootcampbyapplication")]
    public async Task<IActionResult> GetListBootcampByApplication([FromQuery] PageRequest pageRequest, Guid applicantId)
    {
        GetListByApplicationQuery query = new() { PageRequest = pageRequest, ApplicantId = applicantId };
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("getbootcampbybootcampstate")]
    public async Task<IActionResult> GetListBootcampByBootcampState([FromQuery] PageRequest pageRequest, short bootcampStateId)
    {
        GetListBootcampByBootcampStateQuery query = new() { PageRequest = pageRequest, BootcampStateId = bootcampStateId };
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}
