﻿namespace Core.Entity;
/// <summary>
/// Тип рассылки
/// </summary>
public enum NotificationType
{
    /// <summary>
    /// Электронная почта
    /// </summary>
    EMAIL,
    /// <summary>
    /// СМС
    /// </summary>
    SMS,
    /// <summary>
    /// Месенджер
    /// </summary>
    MESSANGER,
    /// <summary>
    /// Всеми типами рассылки
    /// </summary>
    ALL,
    /// <summary>
    /// Ничего не получать
    /// </summary>
    NO_WAY
}