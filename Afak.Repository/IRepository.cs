using AfakProject.Data.GenericModels;

namespace Afak.Repository
{
    public interface IRepository<T> where T : IBaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}