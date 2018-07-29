namespace ClientLight.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}