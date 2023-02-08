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
    public class ApprovePostCommand : IRequest
    {
        public int Id { get; set; }
        public bool IsApprove { get; set; }

        public class ApprovePostCommandHandler : IRequestHandler<ApprovePostCommand>
        {
            private readonly IUnitOfWorkRepository _unitOfWork;

            public ApprovePostCommandHandler(IUnitOfWorkRepository unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Unit> Handle(ApprovePostCommand request, CancellationToken cancellationToken)
            {
                var post = await _unitOfWork.Repository<Post>().GetByIdAsync(request.Id);
                if (post == null)
                {
                    throw new NotFoundException(nameof(Post), request.Id);
                }
                post.IsPending = false;
                post.IsApproved = request.IsApprove;
                post.IsBlocked = request.IsApprove ? post.IsBlocked : true;


                await _unitOfWork.Repository<Post>().UpdateAsync(post);

                return Unit.Value;
            }
        }
    }
}
