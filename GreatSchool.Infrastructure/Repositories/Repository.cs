using GreatSchool.Domain.Entities;
using GreatSchool.Domain.Interfaces;
using GreatSchool.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GreatSchool.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
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
            //prevent entity framework to create a new Aluno instead of updating.
            //because entity framework tracks entities by their primary key (Id)
            //and if the Id is 0, it will create a new entity
            if (entity.Id == 0)
                throw new Exception("Entity ID not found - entity was not updated!");

            entity.UpdatedAt = DateTime.UtcNow;

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
