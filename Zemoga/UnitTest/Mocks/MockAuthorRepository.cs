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
    public static class MockAuthorRepository
    {

        public static void AddDataAuthorRepository(ZemogaContext context)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var entity = fixture.CreateMany<Author>().ToList();
            entity.Add(fixture.Build<Author>()
             .With(tr => tr.Id, 8001)
             .Create()
         );

            context.Authors!.AddRange(entity);
            context.SaveChanges();
        }

        public static Mock<IAuthorRepository> GetRepository()
        {
            
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var entity = fixture.CreateMany<Author>(5).ToList();
            var mockRepository = new Mock<IAuthorRepository>();
            mockRepository.Setup(x => x.GetAsync(f => f.IsActive == true)).ReturnsAsync(entity);
            return mockRepository;
        }
    }
}
