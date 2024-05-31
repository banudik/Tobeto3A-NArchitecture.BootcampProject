using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Queries.GetListByBootcampId;
public class GetListCommentListByBootcampIdItemDto : IDto
{
    public int Id { get; set; }
    public string Context { get; set; }
    public int BootcampId { get; set; }
    public string BootcampName { get; set; }
    public Guid UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public bool Status { get; set; }
}
