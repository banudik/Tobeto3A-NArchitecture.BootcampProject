using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Chapter: Entity<int>
{
    public int Sort { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Link { get; set; }
    public int BootcampId { get; set; }
    public int Time { get; set; }
    public virtual Bootcamp Bootcamp { get; set; }

    public Chapter()
    {
    }

    public Chapter(int sort, string title, string? description, string link, int bootcampId, int time, Bootcamp bootcamp)
    {
        Sort = sort;
        Title = title;
        Description = description;
        Link = link;
        BootcampId = bootcampId;
        Time = time;
        Bootcamp = bootcamp;
    }
}
