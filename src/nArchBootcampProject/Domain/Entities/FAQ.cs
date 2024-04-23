using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class FAQ: Entity<int>
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public string Category { get; set; }

    public FAQ()
    {
    }

    public FAQ(int id, string question, string answer, string category)
    {
        Id = id;
        Question = question;
        Answer = answer;
        Category = category;
    }
}
