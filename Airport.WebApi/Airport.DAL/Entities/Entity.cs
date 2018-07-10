namespace Airport.DAL.Entities
{
    using Airport.DAL.Interfaces;

    public abstract class Entity<T> : IEntity<T>
    {
        public abstract T Id { get; set; }
    }
}
