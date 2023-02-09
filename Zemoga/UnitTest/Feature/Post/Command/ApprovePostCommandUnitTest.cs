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
using static Application.Features.Posts.Commands.ApprovePostCommand;
using static Application.Features.Posts.Commands.UpdatePostCommand;

namespace UnitTest.Feature.Post.Command
{
    public class ApprovePostCommandUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWorkRepository> _unitOfWork;

        public ApprovePostCommandUnitTest()
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
            var post = new ApprovePostCommand
            {
                Id = 100,
                IsApprove =  true 
            };

            var handler = new ApprovePostCommandHandler(_unitOfWork.Object);
            var result = await handler.Handle(post, CancellationToken.None);
            Assert.IsAssignableFrom<Unit>(result);
        }
    }
}
