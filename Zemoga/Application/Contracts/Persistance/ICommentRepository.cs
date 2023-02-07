using Domain;

namespace Application.Contracts.Persistance;

public interface ICommentRepository : IAsyncRepository<Comment>
{
}
