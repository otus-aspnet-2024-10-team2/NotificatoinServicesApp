using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts.Notification;
using WebApi.Models.Notification;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;
    private readonly IBusControl _busControl;

    public NotificationController(INotificationService notificationService, IMapper mapper,
        IPublishEndpoint publishEndpoint, IBusControl busControl)
    {
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _busControl = busControl;
    }
    
    /// <summary>
    /// Получить произвольный ИД
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> CreateIdNotification()
    {
        var a = await _notificationService.GetDefaultIdAsync();
        return Ok(a);
    }

    /// <summary>
    /// Найти уведомление по ID
    /// </summary>
    /// <returns>Уведомление</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotificationAsync(Guid id)
    {
        var notification = await _notificationService.GetNotificationByIdAsync(id);
        if (notification is not null)
        {
            return Ok(_mapper.Map<NotificationModel>(notification));
        }
        else
        {
            return NotFound("Уведомление не найдено");
        }
    }

    /// <summary>
    /// Создать уведомление
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateNotification(CreatingNotificationModel notificationModel)
    {
        var notification = _mapper.Map<CreateNotificationDto>(notificationModel);
        var a = await _notificationService.CreateNewNotificationAsync(notification);
        return Ok(a);
    }

    /// <summary>
    /// Обновить уведомление
    /// </summary>
    /// <returns></returns>
    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateNotification(Guid id, UpdatingNotificationModel updateNotificationDto)
    {
        var updateNotification = _mapper.Map<UpdatingNotificationModel, UpdateNotificationDto>(updateNotificationDto);
        await _notificationService.UpdateNotificationAsync(id, updateNotification);
        return Ok();
    }

    /// <summary>
    /// Отправить уведомление
    /// </summary>
    /// <param name="notificationRequest"></param>
    /// <returns></returns>
    [HttpPost("sending/{id:guid}")]
    public async Task<IActionResult> SendNotification(Guid id, CreateNotificationRequest model)
    {
        var notificat = _notificationService.GetNotificationByIdAsync(id);
        var sendNotification = _mapper.Map<SendNotificationDto>(notificat);
        await _notificationService.SendNotificationAsync(id, sendNotification);
        return Ok();    
    }
}