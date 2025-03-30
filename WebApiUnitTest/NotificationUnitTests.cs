using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Entity;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Services.Contracts.Notification;
using Services.Repositories;
using WebApi.Controllers;
using WebApi.Models.Notification;

namespace WebApiUnitTest;

public class NotificationUnitTests 
{
    private readonly NotificationController _notificationController;
    private readonly Mock<IRepository<Notification, Guid>> _mockRepository;
    private readonly NotificationModel _notificationModel;
    private readonly CreatingNotificationModel _createNotificationModel;

    public NotificationUnitTests()
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        _mockRepository = fixture.Freeze<Mock<IRepository<Notification, Guid>>>();
        _notificationModel = fixture.Freeze<NotificationModel>();
        _createNotificationModel = fixture.Freeze<CreatingNotificationModel>();
        _notificationController = fixture.Build<NotificationController>().OmitAutoProperties().Create();
    }
     
    
    
    /// <summary>
    /// Если не найдено уведомление, выдать ошибку
    /// </summary>
    [Fact]
    public async Task Get_Notification_IsEmpty_NotFound()
    {
        //Arrange
        Guid id = Guid.NewGuid();
        Notification? n = null;
        
        //Act
        _mockRepository.Setup(x => x.GetAsync(id, CancellationToken.None))!.ReturnsAsync((n));
        var result = await _notificationController.GetNotificationAsync(id);
        
        //Assert
        result.Should().BeAssignableTo<OkObjectResult>();
    }

    [Fact]
    public async Task Create_New_Deafult_Notification_And_Save_Database()
    {
        //Arrange
        _createNotificationModel.Title = "Testing unit tests notification";
        _createNotificationModel.Description = "This is a discription for unit tests";
        _createNotificationModel.DateCreated = DateTime.Now.Date;
        
        //Act
        var result = await _notificationController.CreateNotification(_createNotificationModel);
        
        //Assert
        result.Should().NotBe(null);
    }
}