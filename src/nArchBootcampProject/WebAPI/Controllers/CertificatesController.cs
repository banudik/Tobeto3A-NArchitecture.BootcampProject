using Application.Features.Certificates.Commands.Create;
using Application.Features.Certificates.Commands.Delete;
using Application.Features.Certificates.Commands.Update;
using Application.Features.Certificates.Queries.GetById;
using Application.Features.Certificates.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Auth.Commands.ResetPassword;
using Domain.Entities;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificatesController : BaseController
{
    //[HttpPost]
    //public async Task<ActionResult<CreatedCertificateResponse>> Add([FromBody] CreateCertificateCommand command)
    //{
    //    CreatedCertificateResponse response = await Mediator.Send(command);

    //    return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    //}

    //[HttpPut]
    //public async Task<ActionResult<UpdatedCertificateResponse>> Update([FromBody] UpdateCertificateCommand command)
    //{
    //    UpdatedCertificateResponse response = await Mediator.Send(command);

    //    return Ok(response);
    //}

    //[HttpDelete("{id}")]
    //public async Task<ActionResult<DeletedCertificateResponse>> Delete([FromRoute] Guid id)
    //{
    //    DeleteCertificateCommand command = new() { Id = id };

    //    DeletedCertificateResponse response = await Mediator.Send(command);

    //    return Ok(response);
    //}

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCertificateResponse>> GetCertificate([FromRoute] Guid id, int bootcampId)
    {
        GetByIdCertificateQuery query = new() { Id = id, BootcampId = bootcampId };

        GetByIdCertificateResponse response = await Mediator.Send(query);

        var pdfPath = Path.Combine("GeneratedCertificates", $"{response.Id}.pdf");
        var pdfFileStream = new FileStream(pdfPath, FileMode.Open, FileAccess.Read);
        return File(pdfFileStream, "application/pdf", $"{response.Id}.pdf");

    }

    [HttpGet]
    public async Task<ActionResult<GetListCertificateQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCertificateQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCertificateListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("GenerateCertificate")]
    public async Task<IActionResult> CreateCertificate(CreateCertificateDto createCertificateDto)
    {
        CreateCertificateCommand createCertificateCommand = new()
        {
            UserId = getUserIdFromRequest(),
            CreateCertificateDto = createCertificateDto
        };
        await Mediator.Send(createCertificateCommand);

        return Ok();
    }

    [HttpPost("createanddownloadcertificate")]
    public async Task<IActionResult> CreateAndDownloadCertificate(CreateCertificateDto createCertificateDto)
    {
        CreateCertificateCommand createCertificateCommand = new()
        {
            UserId = getUserIdFromRequest(),
            CreateCertificateDto = createCertificateDto
        };
        CreatedCertificateResponse response = await Mediator.Send(createCertificateCommand);


        //GetByIdCertificateQuery query = new() { Id = createCertificateCommand.UserId, BootcampId = createCertificateDto.BootcampId };

        //GetByIdCertificateResponse response2 = await Mediator.Send(query);

        var pdfPath = Path.Combine("GeneratedCertificates", $"{response.Id}.pdf");
        var pdfFileStream = new FileStream(pdfPath, FileMode.Open, FileAccess.Read);
        return File(pdfFileStream, "application/pdf", $"{response.Id}.pdf");

    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetCertificate(Guid id)
    //{
    //    var query = new GetCertificateQuery { CertificateId = id };
    //    var certificate = await _mediator.Send(query);

    //    if (certificate == null)
    //    {
    //        return NotFound();
    //    }

    //    var pdfPath = Path.Combine("GeneratedCertificates", $"{certificate.Id}.pdf");
    //    var pdfFileStream = new FileStream(pdfPath, FileMode.Open, FileAccess.Read);
    //    return File(pdfFileStream, "application/pdf", $"{certificate.Id}.pdf");
    //}


}