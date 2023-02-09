using Application.Features.Authors.Commands;
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
using static Application.Features.Authors.Commands.DeleteAuthorCommand;

namespace UnitTest.Feature.Author.Command
{
    public class DeleteAuthorCommandUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkRepository> _unitOfWork;

        public DeleteAuthorCommandUnitTest()
        {
            _unitOfWork = MokUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            MockAuthorRepository.AddDataAuthorRepository(_unitOfWork.Object.ZemogaContext);
        }

        [Fact]
        public async Task Delete()
        {
            var entity = new DeleteAuthorCommand(8001);
            var handler = new DeleteAuthorCommandHandler(_mapper, _unitOfWork.Object);
            var result = await handler.Handle(entity, CancellationToken.None);
            Assert.IsAssignableFrom<Unit>(result);
        }
    }
}
