using System;
using System.Collections.Generic;
using System.Text;

//following the steps : IRepository -> Repository -> ClassRepository

/* 1.IRepository(Generic Interface)
    Purpose: Common operations ALL entities need (Get, Add, Update, Delete)
    Example: Every entity needs basic CRUD operations

2. Repository (Generic Implementation)
    Purpose: Implements the common operations using Entity Framework
    Benefit: Write the EF code ONCE, use it for ALL entities

3. IAlunoRepository (Specific Interface for the Aluno entity)
    Purpose: Operations ONLY Aluno needs (GetByCPF, GetByEmail)
    Why: Not all entities have CPF or Email - only Aluno does
*/

//The last 'IClassRepository' is the class who implement especific methods for that class.
//(probaly?) the others class of this project will need implement IRepository and Repository evey time.

//needs to be implemented IRepository<T> interface in anothers class, because this will make an "contract"
//with essential methods to my class Repository<T>
//in another words, all methods here are essential to all class

namespace GreatSchool.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(int id);
    }
}
