using BookLibrary.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        protected DbSet<T> EntitySet
        {
            get
            {
                return _context.Set<T>();
            }
        }

        public async Task Insert(T entity)
        {
            await EntitySet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T?> GetById(Guid? id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid? id)
        {
            if (id == null)
            {
                return;
            }

            T entity = await EntitySet.FindAsync(id);
            if (entity == null)
            {
                return;
            }

            EntitySet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
