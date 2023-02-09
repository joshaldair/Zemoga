using Application.Features.Authors.Commands;
using Application.Features.Posts.Commands;
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
using static Application.Features.Posts.Commands.DeletePostCommand;

namespace UnitTest.Feature.Post.Command
{
    public class DeletePostCommandUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkRepository> _unitOfWork;

        public DeletePostCommandUnitTest()
        {
            _unitOfWork = MokUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            MockPostRepository.AddDataPostRepository(_unitOfWork.Object.ZemogaContext);
        }


        [Fact]
        public async Task Delete()
        {
            var entity = new DeletePostCommand(100);
            var handler = new DeletePostCommandHandler(_mapper, _unitOfWork.Object);
            var result = await handler.Handle(entity, CancellationToken.None);
            Assert.IsAssignableFrom<Unit>(result);
        }
    }
}
