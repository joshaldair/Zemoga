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

namespace Application.Features.Authors.Commands;

public class DeleteAuthorCommand : IRequest
{
    public int Id { get; set; }

    public DeleteAuthorCommand(int id)
    {
        Id = id;
    }

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public DeleteAuthorCommandHandler(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Repository<Author>().GetByIdAsync(request.Id);
            if (author == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            _mapper.Map(request, author);
            await _unitOfWork.Repository<Author>().DeleteAsync(author);
            return Unit.Value;
        }
    }
}
