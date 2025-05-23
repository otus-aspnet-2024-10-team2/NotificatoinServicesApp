﻿using AutoMapper;
using Core.Entity;
using Core.Entity.Entities;
using Services.Contracts.Notification;

namespace Services.Implementations.Mapping;

public class NotificationMappingProfile : Profile
{
    public NotificationMappingProfile()
    {
        CreateMap<Notification, NotificationDto>();

        CreateMap<CreateNotificationDto, Notification>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.DateSended, m => m.Ignore())
            .ForMember(d => d.Sending, m => m.Ignore())
            .ForMember(d=>d.IsDeleted, m=>m.Ignore())
            .ForMember(d=>d.TypeNotification, m => m.Ignore());

        CreateMap<UpdateNotificationDto, Notification>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.DateSended, m => m.Ignore())
            .ForMember(d => d.Sending, m => m.Ignore())
            .ForMember(d=>d.IsDeleted, m=>m.Ignore());

        CreateMap<SendNotificationDto, Notification>()
            .ForMember(d => d.Id, m => m.Ignore())
            .ForMember(d => d.DateCreated, m => m.Ignore())
            .ForMember(d=>d.IsDeleted, m=>m.Ignore())
            .ForMember(d=>d.FullName, m=> m.Ignore())
            .ForMember(d=>d.PhoneNumber, m=> m.Ignore())
            .ForMember(d=>d.City, m=> m.Ignore());

    }
}