using GreatSchool.Domain.Entities;
using GreatSchool.Domain.Interfaces;
using GreatSchool.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var t = await DbSet.FindAsync(id);

                if (t != null)
                    return t;
                else
                    throw new Exception($"Entity {id} not found");
            }
            catch (Exception)
            {
                throw new Exception($"Entity {id} not found");
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            DbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            DbSet.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
