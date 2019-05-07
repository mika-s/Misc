using System.Collections.Generic;

namespace DesignPatterns.DDD.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> ListAll();
        T Add(T entity);
        void Remove(T entity);
    }
}