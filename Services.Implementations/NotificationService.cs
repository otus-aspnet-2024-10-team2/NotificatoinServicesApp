using AutoMapper;
using Core.Entity;
using Core.Entity.Events;
using MassTransit;
using Services.Abstractions;
using Services.Contracts.Notification;
using Services.Contracts.NotificationDto;
using Services.Repositories;

namespace Services.Implementations;

public class NotificationService : INotificationService 
{
    private readonly INotificationRepository _service;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;
    public NotificationService(INotificationRepository repository,
        IMapper mapper, 
        IPublishEndpoint publishEndpoint)
    {
        _service = repository;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint; 
    }
   
    
    /// <summary>
    /// Получить произвольный ИД для уведомления
    /// </summary>
    /// <returns></returns>
    public async Task<Guid> GetDefaultIdAsync()
    {
        return await _service.GetDefaultIdAsync();
    }

    /// <summary>
    /// Получить уведомление 
    /// </summary>
    /// <param name="id">GUID уведомления</param>
    /// <returns>ДТО уведомления</returns>
    public async Task<NotificationDto> GetNotificationByIdAsync(Guid id)
    {
        var notification = await _service.GetAsync(id);
        return _mapper.Map<Notification, NotificationDto>(notification);
    }
    
    /// <summary>
    /// Добавить уведомление в БД
    /// </summary>
    /// <param name="createNotificationDto"></param>
    /// <returns></returns>
    public async Task<Guid> CreateNewNotificationAsync(CreateNotificationDto createNotificationDto)
    {
        var notification = _mapper.Map<CreateNotificationDto, Notification>(createNotificationDto);
        var n =  _service.Add(notification); 
        await _service.SaveChangesAsync();
        return n.Id;
    }
    
    /// <summary>
    /// Обновить сведенения по уведомлению
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateNotificationDto"></param>
    /// <exception cref="Exception"></exception>
    public async Task UpdateNotificationAsync(Guid id, UpdateNotificationDto updateNotificationDto)
    {
        var notification = await _service.GetAsync(id);
        if (notification is null)
            throw new Exception($"Уведомление № {id}, не найдено");
        notification.TypeNotification = updateNotificationDto.TypeNotification;
        notification.Description = updateNotificationDto.Description;
        notification.Title = updateNotificationDto.Title;
        _service.Update(notification);
        await _service.SaveChangesAsync();
    }

    /// <summary>
    /// Публикуем уведомление
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sendNotificationDto"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task SendNotificationAsync(Guid id, SendNotificationDto sendNotificationDto)
    {
        var notification = _mapper.Map<SendNotificationDto, Notification>(sendNotificationDto);
        await _publishEndpoint.Publish(new NotificationCreatedEvent
        {
            Id = id,
            Description = notification.Description,
            Title = notification.Title,
        });
        
    }

    public async Task MarkNotificationAsReadAsync(Guid id)
    {
        await _service.MarkAsReadAsync(id);
    }
    
    /// <summary>
    /// Удалить уведомление из БД
    /// </summary>
    /// <param name="id"></param>
    public async Task DeleteNotificationAsync(Guid id)
    {
        var notification = await _service.GetAsync(id);
        notification.IsDeleted = true;
        _service.Delete(id);
        await _service.SaveChangesAsync();
    }

    public async Task<ICollection<Notification>> GetAllNotificationsAsync(bool noTracking = false)
    {
        ICollection<Notification> notifications = await _service.GetAllAsync(noTracking);
        return notifications;
    }
}