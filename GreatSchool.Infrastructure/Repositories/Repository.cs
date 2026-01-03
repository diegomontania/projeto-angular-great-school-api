using GreatSchool.Domain.Interfaces;
using GreatSchool.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GreatSchool.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GreatSchoolDBContext _context;

        //perform database operations
        protected DbSet<T> DbSet { get; }

        public Repository(GreatSchoolDBContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
