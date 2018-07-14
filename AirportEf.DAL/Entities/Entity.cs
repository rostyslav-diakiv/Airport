namespace AirportEf.DAL.Entities
{
    using Airport.Common.Interfaces.Entities;

    public abstract class Entity<T> : IEntity<T>
    {
        public abstract T Id { get; set; }
    }
}
