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

namespace Application.Features.Comments.Commands;

public class DeleteCommentCommand : IRequest
{
    public int Id { get; set; }
    public DeleteCommentCommand(int id)
    {
        Id = id;
    }

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public DeleteCommentCommandHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Repository<Comment>().GetByIdAsync(request.Id);
            if (response == null)
            {
                throw new NotFoundException(nameof(Comment), request.Id);
            }

            _mapper.Map(request, response);
            await _unitOfWork.Repository<Comment>().DeleteAsync(response);
            return Unit.Value;
        }
    }
}
