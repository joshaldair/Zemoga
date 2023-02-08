using Application.Contracts.Persistance;
using Application.Exceptions;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;


namespace Application.Features.Posts.Commands
{
    public class CreatePostCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public class CreatePostCommandHanlder : IRequestHandler<CreatePostCommand, int>
        {
            private readonly IUnitOfWorkRepository _unitOfWork;
            private readonly IMapper _mapper;
            public CreatePostCommandHanlder(IUnitOfWorkRepository unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
            {
                var author = await _unitOfWork.Repository<Author>().GetByIdAsync(request.AuthorId);
                if (author == null)
                {
                    throw new NotFoundException(nameof(Author), request.AuthorId);
                }
                var postEntity = _mapper.Map<Post>(request);
                postEntity.IsPending = true;
                var response = await _unitOfWork.Repository<Post>().AddAsync(postEntity);
                return response.Id;
            }
        }

        public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
        {
            public CreatePostCommandValidator()
            {
                RuleFor(p => p.Title)
               .NotEmpty()
               .WithMessage("Title is required")
               .NotNull()
               .MaximumLength(30).WithMessage("{Title} cannot exceed 30 characters");
            }
        }
    }
}
