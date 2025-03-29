using AutoMapper;
using Core.Entity;
using Services.Abstractions;
using Services.Contracts.Notification;
using Services.Contracts.NotificationDto;
using Services.Repositories;

namespace Services.Implementations;

public class NotificationService : INotificationService 
{
    private readonly INotificationRepository _service;
    private readonly IMapper _mapper;
    public NotificationService(INotificationRepository repository,
        IMapper mapper)
    {
        _service = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить произвольный ИД для уведомления
    /// </summary>
    /// <returns></returns>
    public async Task<Guid> GetDefaultIdAsync()
    {
        var defaultId = await _service.GetDefaultIdAsync();
        return defaultId;
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
}