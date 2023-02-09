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
using static Application.Features.Authors.Commands.UpdateAuthorCommand;
using static Application.Features.Posts.Commands.UpdatePostCommand;

namespace UnitTest.Feature.Post.Command
{
    public class UpdatePostCommandUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkRepository> _unitOfWork;

        public UpdatePostCommandUnitTest()
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
        public async Task UpdatePostCommand_ReturnsUnit()
        {
            var post = new UpdatePostCommand
            {
                Id = 100,
                Description = "34",
                Title = "34"
            };

            var handler = new UpdatePostCommandHandler(_unitOfWork.Object);
            var result = await handler.Handle(post, CancellationToken.None);
            Assert.IsAssignableFrom<Unit>(result);
        }
    }
}
