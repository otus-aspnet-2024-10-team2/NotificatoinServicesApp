namespace Core.Entity;

public class Notification : IEntity<int>
{
    /// <summary>
    /// Идинтификатор
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Текст уведомления
    /// </summary>
    public string Message { get; set; }
}