using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistance
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IAuthorRepository AuthorRepository { get; }
        ICommentRepository CommentRepository { get; }
        IPostRepository PostRepository { get; }
        IUserRepository UserRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
    }
}
