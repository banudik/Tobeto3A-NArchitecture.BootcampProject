﻿using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Comment:Entity<int>
{
    public string Context { get; set; }
    public int BootcampId { get; set; }
    public virtual Chapter Chapter { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set;}
    public bool Status { get; set; }

    public Comment()
    {
        
    }

    public Comment(string context, int bootcampId, Chapter chapter, Guid userId, User user, bool status)
    {
        Context = context;
        BootcampId = bootcampId;
        Chapter = chapter;
        UserId = userId;
        User = user;
        Status = status;
    }
}
