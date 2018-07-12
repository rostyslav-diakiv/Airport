namespace Airport.Common.Interfaces.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}