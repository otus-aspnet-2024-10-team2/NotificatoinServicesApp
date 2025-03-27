using AutoMapper;
using Services.Abstractions;
using Services.Contracts.NotificationDto;
using Services.Repositories;

namespace Services.Implementations;

public class NotificationService : INotificationService 
{
    //private readonly INotificationRepository _notificationRepository;
    //private readonly INotificationRepository _service = service ;

    private readonly INotificationRepository _service;

    public NotificationService(INotificationRepository repository)
    {
        _service = repository;
    }


    //private readonly IMapper _mapper = mapper  ?? throw new ArgumentNullException(nameof(mapper));
    //private readonly IUnitOfWork unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    /// <summary>
    /// Получить произвольный ИД для уведомления
    /// </summary>
    /// <returns></returns>
    public async Task<Guid> GetDefaultIdAsync()
    {
        // var defaultId = await _notificationRepository.GetDefaultIdAsync();
        var defaultId = await _service.GetDefaultIdAsync();
        //return _mapper.Map<int, NotificationDefaultIdDto>(defaultId);
        //return _mapper.Map<NotificationDefaultIdDto>(defaultId);
        return defaultId;
    }
}