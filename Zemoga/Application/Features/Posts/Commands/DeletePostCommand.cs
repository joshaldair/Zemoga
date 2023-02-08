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
    public class DeletePostCommand : IRequest
    {
        public int Id { get; set; }
        public DeletePostCommand(int id)
        {
            Id = id;
        }

        public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWorkRepository _unitOfWork;
            public DeletePostCommandHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }
            public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
            {
                var post = await _unitOfWork.Repository<Post>().GetByIdAsync(request.Id);
                if (post == null)
                {
                    throw new NotFoundException(nameof(Post), request.Id);
                }

                _mapper.Map(request, post);
                await _unitOfWork.Repository<Post>().DeleteAsync(post);
                return Unit.Value;
            }
        }
    }
}
