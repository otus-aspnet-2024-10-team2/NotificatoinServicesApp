namespace Core.Entity.Base
{
    public interface IEntity<out TId>
    {
        TId Id { get; }
    }
}
