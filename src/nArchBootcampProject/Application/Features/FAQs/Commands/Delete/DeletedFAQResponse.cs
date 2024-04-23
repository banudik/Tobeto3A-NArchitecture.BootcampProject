using NArchitecture.Core.Application.Responses;

namespace Application.Features.FAQs.Commands.Delete;

public class DeletedFAQResponse : IResponse
{
    public int Id { get; set; }
}