using GreatSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSchool.Domain.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Aluno GetById(int id);
        Aluno GetByCPF(string cpf);
        Aluno GetByEmail(string email);
    }
}
