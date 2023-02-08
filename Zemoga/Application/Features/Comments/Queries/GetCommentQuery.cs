using Application.Contracts.Persistance;
using Application.Features.Authors.Queries.DTO;
using Application.Features.Comments.Queries.DTO;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Queries
{
    public class GetCommentQuery : IRequest<List<CommentDTO>>
    {
        public GetCommentQuery()
        {

        }

        public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, List<CommentDTO>>
        {
            private readonly IUnitOfWorkRepository _unitOfWork;
            private readonly IMapper _mapper;
            public GetCommentQueryHandler(IUnitOfWorkRepository unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<CommentDTO>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
            {
                var lista = await _unitOfWork.CommentRepository.GetAsync(x => x.IsActive == true);
                return _mapper.Map<List<CommentDTO>>(lista);
            }
        }
    }
}
