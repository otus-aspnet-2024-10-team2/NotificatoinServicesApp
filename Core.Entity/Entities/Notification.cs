using Core.Entity.Exceptions;
using Core.Entity.Helpers;

namespace Core.Entity;

public class Notification : IEntity<Guid>
{
    /// <summary>
    /// Идинтификатор
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Текст уведомления
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Дата создания, по умолчанию - текущая дата
    /// </summary>
    public DateTime DateCreated { get; set; } = DateTime.Now;
    /// <summary>
    /// Дата рассылки
    /// </summary>
    public DateTime? DateSended { get; set; }
    /// <summary>
    /// Признак рассылки
    /// </summary> 
    public bool Sending { get; set; } = false;
    /// <summary>
    /// Тип рассылки
    /// </summary>
    public NotificationType TypeNotification { get; set; }

    public Notification( string title, string description,
        DateTime dateCreated)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new NotificationException(TypeExceptions.IsEmptyTitle);

        if (string.IsNullOrWhiteSpace(description))
            throw new NotificationException(TypeExceptions.IsEmptyDescription);

        if (!CheckDateCreated(dateCreated))
            throw new NotificationException(TypeExceptions.IsUncorrectDateCreated);
        
        Title = title;
        Description = description;
        DateCreated = dateCreated;
    }

    /// <summary>
    /// Проверка на коррекность времени создания.  
    /// </summary>
    /// <param name="dateCreated">Дата создания, по умолчанию, текущая дата</param>
    /// <returns></returns>
    private bool CheckDateCreated(DateTime dateCreated)
    {
        return (dateCreated >= DateTime.Now.AddDays(-7)) 
               && dateCreated <= DateTime.Now.Date ? true : false;
    }
}