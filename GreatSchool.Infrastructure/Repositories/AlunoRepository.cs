using GreatSchool.Domain.Entities;
using GreatSchool.Domain.Interfaces;
using GreatSchool.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSchool.Infrastructure.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(GreatSchoolDBContext context) : base(context)
        {

        }

        public Aluno GetByCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public Aluno GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Aluno GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
