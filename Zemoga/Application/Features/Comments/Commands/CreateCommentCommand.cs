
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

namespace Application.Features.Comments.Commands;

public class CreateCommentCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IUnitOfWorkRepository unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Repository<Post>().GetByIdAsync(request.PostId);
            if (post == null)
            {
                throw new NotFoundException(nameof(Post), request.PostId);
            }

            var entity = _mapper.Map<Comment>(request);
            var response = await _unitOfWork.Repository<Comment>().AddAsync(entity);
            return response.Id;
        }
    }

    public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentValidator()
        {
               RuleFor(p => p.Description)
              .NotEmpty()
              .WithMessage("Name is required")
              .NotNull();

            RuleFor(p => p.UserId)
             .NotEmpty()
             .WithMessage("User Id is required")
             .NotNull().GreaterThan(0);

            RuleFor(p => p.PostId)
             .NotEmpty()
             .WithMessage("Post Id is required")
             .NotNull()
             .GreaterThan(0);
        }
    }
}
