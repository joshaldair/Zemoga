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
using static Application.Features.Authors.Commands.UpdateAuthorCommand;

namespace UnitTest.Feature.Author.Command
{
    public class UpdateAuthorCommandUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkRepository> _unitOfWork;

        public UpdateAuthorCommandUnitTest()
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
        public async Task UpdateAuthorCommand_ReturnsUnit()
        {
            var author = new UpdateAuthorCommand
            {
                Name = "2",
                Id = 8001
            };

            var handler = new UpdateAuthorCommandHandler( _unitOfWork.Object, _mapper);
            var result = await handler.Handle(author, CancellationToken.None);
            Assert.IsAssignableFrom<Unit>(result);
        }
    }
}
