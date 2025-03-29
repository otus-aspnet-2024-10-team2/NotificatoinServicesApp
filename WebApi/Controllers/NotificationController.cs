using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts.Notification;
using WebApi.Models.Notification;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public NotificationController(INotificationService notificationService, IMapper mapper)
    {
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    /// <summary>
    /// Получить произвольный ИД
    /// </summary>
    /// <param name="id"></param>
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
    /// <param name="id">GUID</param>
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
    /// <param name="notificationModel"></param>
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
    /// <param name="id">Guid Уведомления</param>
    /// <param name="updateNotificationDto">Модель обновления</param>
    /// <returns></returns>
    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateNotification(Guid id, UpdatingNotificationModel updateNotificationDto)
    {
        var updateNotification = _mapper.Map<UpdatingNotificationModel, UpdateNotificationDto>(updateNotificationDto);
        await _notificationService.UpdateNotificationAsync(id, updateNotification);
        return Ok();
    }
}