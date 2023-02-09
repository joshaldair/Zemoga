using Application.Contracts.Persistance;
using Application.Features.Authors.Queries;
using Application.Features.Authors.Queries.DTO;
using Application.Mappings;
using AutoMapper;
using Infrastructure.Repositories;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Mocks;
using static Application.Features.Authors.Queries.GetAuthorQuery;

namespace UnitTest.Feature.Author.Queries
{
    public class GetAuthorQueryUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWorkRepository> _unitOfWork;

        public GetAuthorQueryUnitTest()
        {
            _unitOfWork = MokUnitOfWork.GetUnitOfWorkAuthors();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

  
        }


        [Fact]
        public async Task GetAuthor()
        {
            var handler = new GetAuthorQueryHandler(_unitOfWork.Object, _mapper);
            var result = await handler.Handle(new GetAuthorQuery { }, CancellationToken.None);

            Assert.IsAssignableFrom<List<AuthorDTO>>(result);
            Assert.Equal(5, result.Count);

        }
    }
}
