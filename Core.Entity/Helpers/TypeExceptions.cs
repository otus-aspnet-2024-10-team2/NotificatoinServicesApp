using System.ComponentModel;

namespace Core.Entity.Helpers;

/// <summary>
/// Тип исключения
/// </summary>
public enum TypeExceptions
{
    /// <summary>
    /// Ошибка с описанием оповещения
    /// </summary>
    [Description("Отсутсвует текст описания уведомления")]
    IsEmptyDescription = 1,
    /// <summary>
    /// Ошибка с наименованием оповещения
    /// </summary>
    [Description("Отсутствует заголовок уведомления")]
    IsEmptyTitle = 2,
    /// <summary>
    /// Ошибка с датой создания
    /// </summary>
    [Description("Некорректная дата создания уведомления")]
    IsUncorrectDateCreated = 3,
    /// <summary>
    /// Ошибка с типом уведомления
    /// </summary>
    [Description("Некорректный тип уведомления")]
    IsUncorrectTypeNotification = 4
}