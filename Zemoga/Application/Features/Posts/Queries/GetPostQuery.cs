using Application.Contracts.Persistance;
using Application.Features.Authors.Queries.DTO;
using Application.Features.Posts.Queries.DTO;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Queries
{
    public class GetPostQuery : IRequest<List<PostDTO>>
    {

        public GetPostQuery()
        {

        }

        public class GetPostQueryHandler : IRequestHandler<GetPostQuery, List<PostDTO>>
        {
            private readonly IUnitOfWorkRepository _unitOfWork;
            private readonly IMapper _mapper;
            public GetPostQueryHandler(IUnitOfWorkRepository unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<PostDTO>> Handle(GetPostQuery request, CancellationToken cancellationToken)
            {
                var lista = await _unitOfWork.PostRepository.GetAsync(x => x.IsActive == true, includeProperties: "Comments");
                return _mapper.Map<List<PostDTO>>(lista);
            }
        }

    }
}
