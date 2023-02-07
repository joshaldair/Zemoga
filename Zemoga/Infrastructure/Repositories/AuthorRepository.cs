using Application.Contracts.Persistance;
using Domain;
using Infrastructure.Persistance;


namespace Infrastructure.Repositories;

public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(ZemogaContext context) : base(context)
    {

    }
}
