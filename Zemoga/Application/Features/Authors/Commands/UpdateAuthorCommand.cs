using Application.Contracts.Persistance;
using Application.Exceptions;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Commands;

public class UpdateAuthorCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IUnitOfWorkRepository unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Repository<Author>().GetByIdAsync(request.Id);
            if(author == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            _mapper.Map(request, author);
            await _unitOfWork.Repository<Author>().UpdateAsync(author);

            return Unit.Value;
        }
    }

    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(p => p.Name)
           .NotEmpty()
           .WithMessage("Name is required")
           .NotNull()
           .MaximumLength(30).WithMessage("Name cannot exceed 30 characters");
        }
    }
}
