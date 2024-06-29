using Application.Features.Contact.SendEmail;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContactController : BaseController
{
    private readonly IMediator _mediator;

    public ContactController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("send-email")]
    public async Task<IActionResult> SendEmail([FromBody] ContactFormModel model)
    {
        await _mediator.Send(new SendEmailCommand(model));
        return Ok(new { message = "Email sent successfully" });
    }
}

