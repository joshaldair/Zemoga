using Application.Contracts.Persistance;
using Application.Features.Authors.Queries.DTO;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Queries
{
    public class GetAuthorQuery : IRequest<List<AuthorDTO>>
    {
        public GetAuthorQuery()
        {
                
        }

        public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<AuthorDTO>>
        {
            private readonly IUnitOfWorkRepository _unitOfWork;
            private readonly IMapper _mapper;

            public GetAuthorQueryHandler(IUnitOfWorkRepository unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<AuthorDTO>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
            {
                var lista = await _unitOfWork.AuthorRepository.GetAsync(x => x.IsActive == true);
                return _mapper.Map<List<AuthorDTO>>(lista);

            }
        }
    }
}
