using Domain.Common;

namespace Domain;

public class Post : BaseDomainModel
{
    public Post()
    {
        Comments = new HashSet<Comment>();
    }
    public string Description { get; set; }
    public string Title { get; set; }
    public bool IsPending { get; set; }
    public bool IsApproved { get; set; }
    public bool IsBlocked { get; set; }
    public int? AuthorId { get; set; }
    public Author Author { get; set; }

    public ICollection<Comment> Comments { get; set; }

}
