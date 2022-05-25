using System.Collections.Generic;

namespace IndieGamesRepositoryAPP.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T ReadById(int id);
        void Create(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        int NextId();
    }
}