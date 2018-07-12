namespace Airport.BLL.Interfaces
{
    using System.Collections.Generic;

    public interface IService<TDto, TRequest, TKey>
    {
        IEnumerable<TDto> GetAllEntity();

        TDto GetEntityById(TKey id);

        TDto CreateEntity(TRequest request);

        TDto UpdateEntityById(TRequest request, TKey id);

        bool DeleteEntityById(TKey id);
    }
}