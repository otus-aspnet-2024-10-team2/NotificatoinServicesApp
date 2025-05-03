namespace Core.Entity;
/// <summary>
/// Тип рассылки
/// </summary>
public enum NotificationType
{
    /// <summary>
    /// Электронная почта
    /// </summary>
    Email,
    /// <summary>
    /// СМС
    /// </summary>
    Sms,
    /// <summary>
    /// Месенджер
    /// </summary>
    Messenger,
    /// <summary>
    /// Всеми типами рассылки
    /// </summary>
    All,
    /// <summary>
    /// Ничего не получать
    /// </summary>
    NoWay
}