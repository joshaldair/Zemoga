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

public class UpdateCommentCommand : IRequest
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }

    public class UpdateCommentCommandHanlder : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHanlder(IUnitOfWorkRepository unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Repository<Post>().GetByIdAsync(request.PostId);
            if (post == null)
            {
                throw new NotFoundException(nameof(Post), request.PostId);
            }

            var user = await _unitOfWork.Repository<User>().GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            var comment = await _unitOfWork.Repository<Comment>().GetByIdAsync(request.Id);
            if (comment == null)
            {
                throw new NotFoundException(nameof(Comment), request.Id);
            }

            _mapper.Map(request, comment);
            await _unitOfWork.Repository<Comment>().UpdateAsync(comment);

            return Unit.Value;
        }
    }

    public class UpdateCommentValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentValidator()
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
