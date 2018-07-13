namespace Airport.Common.Interfaces.Entities
{
    public interface IIdGeneratable<T>
    {
        T GetGeneratedId();
    }
}