using AutoMapper;
using Services.Abstractions;
using Services.Contracts.NotificationDto;
using Services.Repositories;

namespace Services.Implementations;

public class NotificationService(
    INotificationRepository service,
    IMapper mapper) : INotificationService
{
    //private readonly INotificationRepository _notificationRepository;
    private readonly INotificationRepository _service = service ?? throw new ArgumentNullException(nameof(service));
    private readonly IMapper _mapper = mapper  ?? throw new ArgumentNullException(nameof(mapper));

    /// <summary>
    /// Получить произвольный ИД для уведомления
    /// </summary>
    /// <returns></returns>
    public async Task<NotificationDefaultIdDto> GetDefaultIdAsync()
    {
        // var defaultId = await _notificationRepository.GetDefaultIdAsync();
        var defaultId = await _service.GetDefaultIdAsync();
        //return _mapper.Map<int, NotificationDefaultIdDto>(defaultId);
        return _mapper.Map<NotificationDefaultIdDto>(defaultId);
    }
}