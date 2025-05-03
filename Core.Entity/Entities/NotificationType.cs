namespace Core.Entity;
/// <summary>
/// Тип рассылки
/// </summary>
public enum NotificationType
{
    /// <summary>
    /// Электронная почта
    /// </summary>
    EMAIL = 1,
    /// <summary>
    /// СМС
    /// </summary>
    SMS = 2,
    /// <summary>
    /// Месенджер
    /// </summary>
    MESSANGER = 3,
    /// <summary>
    /// Всеми типами рассылки
    /// </summary>
    ALL = 4,
    /// <summary>
    /// Ничего не получать
    /// </summary>
    NO_WAY = 5
}