namespace BookLibrary.Data.Repositories.Abstract
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task Insert(T entity);
        Task<List<T>> GetAll();
        Task<T?> GetById(Guid? id);
        Task Update(T entity);
        Task Delete(Guid? id);
    }
}
