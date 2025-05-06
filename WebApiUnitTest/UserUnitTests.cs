using System.Diagnostics;
using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Entity;
using Core.Entity.Entities;
using FluentAssertions;
using Infrastructure.Repositories.Implementations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Repositories;
using WebApi.Controllers;
using WebApi.Models.User;

namespace WebApiUnitTest;

public class UserUnitTests
{
    private readonly UserController _userController;
    private readonly Mock<IRepository<User, int>> _mockRepository;
    private readonly CreateUserModel _createUserModel;

    public UserUnitTests()
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        _mockRepository = fixture.Freeze<Mock<IRepository<User, int>>>();
        _userController = fixture.Build<UserController>().OmitAutoProperties().Create();
        _createUserModel = fixture.Freeze<CreateUserModel>();
    }

    /// <summary>
    /// Если не найден пользователь
    /// </summary>
    [Fact]
    public async Task GetUserIsEmptyNotFound()
    {
        //Arrange
        var id = new Random().Next(1,1000);
        User u = null;
        
        //Act 
        _mockRepository.Setup(x => x.GetAsync(id, CancellationToken.None)).ReturnsAsync((u));
        var user = await _userController.GetUserByIdAsync(id);
        
        //Assert
        user.Should().BeAssignableTo<OkObjectResult>();
    }

    public static IEnumerable<object[]> CreateUserModelData()
    {
        var models = new List<object[]>
        {
            new object[]
            {
                new CreateUserModel()
                {
                    Id = 0,
                    Name = "string",
                    Email = "string",
                    PhoneNumber = "string",
                    City = "string",
                    IsActiveUser = true,
                    NotificationTypes = new List<NotificationType>()
                    {
                        NotificationType.Email,
                    },
                    DateCreated = DateTime.Now,
                    UserType = UserType.Administrator
                },
            }
        };
        return models;
    }

    [Theory]
    [MemberData(nameof(CreateUserModelData))]
    public async Task Create_New_User(CreateUserModel createUserModel)
    {
        //Arrange
        var model = createUserModel;
        
        //Act
        var result = _userController.CreateNewUserAsync(model).Result;
        
        //Assert
        result.Should().NotBeNull();
        result.Should().BeAssignableTo<OkObjectResult>();
    }
}