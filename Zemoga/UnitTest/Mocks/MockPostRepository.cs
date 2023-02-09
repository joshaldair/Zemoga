using Application.Contracts.Persistance;
using AutoFixture;
using Domain;
using Infrastructure.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mocks
{
    public class MockPostRepository
    {
        public static Mock<IPostRepository> GetRepository()
        {

            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var entity = fixture.CreateMany<Post>(5).ToList();
            var mockRepository = new Mock<IPostRepository>();
            mockRepository.Setup(x => x.GetAsync(f => f.IsActive == true)).ReturnsAsync(entity);
            return mockRepository;
        }

        public static void AddDataPostRepository(ZemogaContext context)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var entity = fixture.CreateMany<Post>().ToList();
            entity.Add(fixture.Build<Post>()
             .With(tr => tr.Id, 100)
             .With(tr => tr.IsBlocked, false)
             .Create()
         );

            context.Posts!.AddRange(entity);
            context.SaveChanges();
        }
    }
}
