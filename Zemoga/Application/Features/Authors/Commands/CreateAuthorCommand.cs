using Application.Contracts.Persistance;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Commands
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
        {
            private readonly IUnitOfWorkRepository _unitOfWork;
            private readonly IMapper _mapper;

            public CreateAuthorCommandHandler(IUnitOfWorkRepository unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
            {
                var authorEntity = _mapper.Map<Author>(request);
                var response = await _unitOfWork.Repository<Author>().AddAsync(authorEntity);
                return response.Id;
            }
        }

        public class AuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
        {
            public AuthorCommandValidator()
            {
                RuleFor(p => p.Name)
               .NotEmpty()
               .WithMessage("Name is required")
               .NotNull()
               .MaximumLength(30).WithMessage("Name cannot exceed 30 characters");
            }
        }

    }
}
