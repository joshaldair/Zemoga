using Application.Contracts.Persistance;
using Domain;
using Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class PostRepository : RepositoryBase<Post>, IPostRepository
{
    public PostRepository(ZemogaContext context) : base(context)
    {

    }
}
