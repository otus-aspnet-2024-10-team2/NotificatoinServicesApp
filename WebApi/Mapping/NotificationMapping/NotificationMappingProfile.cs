using AutoMapper;
using Services.Contracts.Notification;
using WebApi.Models.Notification;

namespace WebApi.Mapping.NotificationMapping;

/// <summary>
/// Профиль автомаппера для уведомления
/// </summary>
public class NotificationMappingProfile : Profile
{
    public NotificationMappingProfile()
    {
        CreateMap<NotificationDto, NotificationModel>();
        CreateMap<CreatingNotificationModel, CreateNotificationDto>();
        CreateMap<UpdatingNotificationModel,UpdateNotificationDto>();
        CreateMap<SendingNotificationModel, SendNotificationDto>();
    }
}