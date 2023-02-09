using Application.Contracts.Persistance;
using Infrastructure.Persistance;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;


namespace UnitTest.Mocks
{
    public static class MokUnitOfWork
    {

        public static Mock<UnitOfWorkRepository> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<ZemogaContext>()
                .UseInMemoryDatabase(databaseName: $"ZemogaContext-{dbContextId}")
                .Options;

            var streamerDbContextFake = new ZemogaContext(options);
            streamerDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWorkRepository>(streamerDbContextFake);
            return mockUnitOfWork;
        }

        public static Mock<IUnitOfWorkRepository> GetUnitOfWorkAuthors()
        {
            var mockUnitOfWork = new Mock<IUnitOfWorkRepository>();
            var mockRepository = MockAuthorRepository.GetRepository();
            mockUnitOfWork.Setup(x => x.AuthorRepository).Returns(mockRepository.Object);
            return mockUnitOfWork;
        }

        public static Mock<IUnitOfWorkRepository> GetUnitOfWorkPosts()
        {
            var mockUnitOfWork = new Mock<IUnitOfWorkRepository>();
            var mockRepository = MockPostRepository.GetRepository();
            mockUnitOfWork.Setup(x => x.PostRepository).Returns(mockRepository.Object);
            return mockUnitOfWork;
        }
    }
}
