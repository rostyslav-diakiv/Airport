namespace Airport.DAL.Interfaces.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}