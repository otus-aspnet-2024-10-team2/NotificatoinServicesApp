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
    private readonly ILogger<NotificationController> _logger;

    public NotificationController(INotificationService notificationService, IMapper mapper,
        IPublishEndpoint publishEndpoint, IBusControl busControl,
        ILogger<NotificationController> logger)
    {
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _busControl = busControl;
        _logger = logger;
    }
    
    /// <summary>
    /// Получить произвольный ИД
    /// </summary>
    /// <returns></returns>
    //[HttpGet]
    public async Task<IActionResult> CreateIdNotification()
    {
        _logger.LogInformation($"Вызов метода получения произвольного GUID уведомления");
        var a = await _notificationService.GetDefaultIdAsync();
        _logger.LogInformation($"Произвольный GUID: {a}");
        return Ok(a);
    }

    /// <summary>
    /// Найти уведомление по ID
    /// </summary>
    /// <returns>Уведомление</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotificationAsync(Guid id)
    {
        _logger.LogInformation($"Начало поиска уведомления по GUID:{id}");
        var notification = await _notificationService.GetNotificationByIdAsync(id);
        if (notification is not null)
        {
            _logger.LogInformation("Уведомление успешно найдено");
            return Ok(_mapper.Map<NotificationModel>(notification));
        }
        else
        {
            _logger.LogWarning($"Уведомление № {id} не найдено в системе");
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
        try
        {
            _logger.LogInformation("Начало процесса создания уведомления.");
            var notification = _mapper.Map<CreateNotificationDto>(notificationModel);
            notification.Id = await _notificationService.GetDefaultIdAsync();
            notificationModel.Id = notification.Id;
            var a = await _notificationService.CreateNewNotificationAsync(notification);
            _logger.LogInformation($"Уведомление успешно создано. GUID: {a}");
            return Ok(a);
        }
        catch (Exception ex)
        {
            var m = $"Ошибка при попытке создать запись в БД, для уведомления № {notificationModel.Id}\n{ex.Message}";
            _logger.LogCritical(m);
            return BadRequest(m);
        }
    }

    /// <summary>
    /// Обновить уведомление
    /// </summary>
    /// <returns></returns>
    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateNotification(Guid id, UpdatingNotificationModel updateNotificationDto)
    {
        try
        {
            _logger.LogInformation($"Начало процесса обновления уведомления № {updateNotificationDto.Id}");
            var updateNotification =
                _mapper.Map<UpdatingNotificationModel, UpdateNotificationDto>(updateNotificationDto);
            await _notificationService.UpdateNotificationAsync(id, updateNotification);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"Ошибка процедуры обновления уведомления GUID: {updateNotificationDto.Id}\n{ex.Message}");
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Отправить уведомление
    /// </summary>
    /// <param name="notificationRequest"></param>
    /// <returns></returns>
    [HttpPost("sending/{id:guid}")]
    public async Task<IActionResult> SendNotification(Guid id, CreateNotificationRequest model)
    {
        try
        {
            _logger.LogInformation("Начало процедуры передачи уведомления");
            var notificat = _notificationService.GetNotificationByIdAsync(id);
            var sendNotification = _mapper.Map<SendNotificationDto>(notificat);
            await _notificationService.SendNotificationAsync(id, sendNotification);
            _logger.LogInformation("Уведомление успешно передано");
            return Ok();
        }
        catch (Exception ex)
        {   
            _logger.LogCritical($"Ошибка процедуры передачи уведомления GUID: {id}\n{ex.Message}");
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Удалить запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNotification(Guid id)
    {
        await _notificationService.DeleteNotificationAsync(id);
        return Ok();
    }

    /// <summary>
    /// Получить все уведомления
    /// </summary>
    /// <returns></returns>
    [HttpGet("list")]
    public async Task<IActionResult> GetAllNotificationsAsync()
    {
        var notifications = await _notificationService.GetAllNotificationsAsync();
        return Ok(notifications);
    }
}