using Domain;

namespace Application.Contracts.Persistance;

public interface IUserRepository : IAsyncRepository<User>
{
}
