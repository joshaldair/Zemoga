using Application.Features.Authors.Commands;
using Application.Features.Posts.Commands;
using Application.Mappings;
using AutoMapper;
using Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Mocks;
using static Application.Features.Authors.Commands.CreateAuthorCommand;
using static Application.Features.Posts.Commands.CreatePostCommand;

namespace UnitTest.Feature.Post.Command
{
    public class CreatePostCommandUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkRepository> _unitOfWork;
        public CreatePostCommandUnitTest()
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
        public async Task CreatePostCommand_ReturnNumber()
        {
            var post = new CreatePostCommand
            {
                AuthorId = 8001,
                Description = "23",
                Title =" te"
            };

            var handler = new CreatePostCommandHandler(_unitOfWork.Object, _mapper);
            var result = await handler.Handle(post, CancellationToken.None);
            Assert.IsAssignableFrom<int>(result);

        }
    }
}
