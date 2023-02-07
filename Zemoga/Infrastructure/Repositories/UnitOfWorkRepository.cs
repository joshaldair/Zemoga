using Application.Contracts.Persistance;
using Domain.Common;
using Infrastructure.Persistance;
using System;
using System.Collections;

namespace Infrastructure.Repositories;

public class UnitOfWorkRepository : IUnitOfWorkRepository
{
    private Hashtable _repositories;//referencia servicios repositorio
    private readonly ZemogaContext _context;

    private IAuthorRepository _authorRepository;
    public IAuthorRepository AuthorRepository => _authorRepository ?? new AuthorRepository(_context);

    private ICommentRepository _commentRepository;
    public ICommentRepository CommentRepository => _commentRepository ?? new CommentRepository(_context);

    private IPostRepository _postRepository;
    public IPostRepository PostRepository => _postRepository ?? new PostRepository(_context);

    private IUserRepository _userRepository;
    public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

    public  ZemogaContext ZemogaContext => _context;
    public UnitOfWorkRepository(ZemogaContext context)
    {
        _context = context;
    }
    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
    {
        if (_repositories == null)
        {
            _repositories = new Hashtable();
        }

        var type = typeof(TEntity).Name;
        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(RepositoryBase<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
            _repositories.Add(type, repositoryInstance);
        }

        return (IAsyncRepository<TEntity>)_repositories[type];
    }
}