using Application.Features.Authors.Commands;
using Application.Mappings;
using AutoMapper;
using Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTest.Mocks;
using static Application.Features.Authors.Commands.CreateAuthorCommand;

namespace UnitTest.Feature.Author.Command;

public class CreateAuthorCommandUnitTest
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWorkRepository> _unitOfWork;

    public CreateAuthorCommandUnitTest()
    {
        _unitOfWork = MokUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task CreateAuthorCommand_ReturnNumber()
    {
        var author = new CreateAuthorCommand
        {
            Name = "1"

        };

        var handler = new CreateAuthorCommandHandler(_unitOfWork.Object, _mapper);
        var result = await handler.Handle(author, CancellationToken.None);
        Assert.IsAssignableFrom<int>(result);  
         
    }
}
