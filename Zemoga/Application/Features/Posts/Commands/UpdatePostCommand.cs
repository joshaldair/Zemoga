using Application.Contracts.Persistance;
using Application.Exceptions;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Commands
{
    public class UpdatePostCommand : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
        {
            private readonly IUnitOfWorkRepository _unitOfWork;

            public UpdatePostCommandHandler(IUnitOfWorkRepository unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
            {
                var post = await _unitOfWork.Repository<Post>().GetByIdAsync(request.Id);
                if (post == null)
                {
                    throw new NotFoundException(nameof(Post), request.Id);
                }

                post.Title = request.Title;
                post.Description = request.Description;

                await _unitOfWork.Repository<Post>().UpdateAsync(post);

                return Unit.Value;
            }
        }
    }
}
