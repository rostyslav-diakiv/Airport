namespace Airport.DAL.Entities
{
    using Airport.Common.Interfaces.Entities;

    public abstract class Entity<T> : IEntity<T>, IIdGeneratable<T>
    {
        public abstract T Id { get; set; }

        public abstract T GetGeneratedId();
    }
}
