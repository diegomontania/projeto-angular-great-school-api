using GreatSchool.Domain.Entities;
using GreatSchool.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GreatSchool.Infrastructure.Data
{
    //fluent api o que pode ser feito, definir nome de tabelas, nome de chaves primarias,
    //ignorar campos na classe para serem ignorados na criacao da tabela, relacionamentos
    //https://www.youtube.com/watch?v=7M501P-23Jg

    //Fluent api - relacionamentos
    //https://www.youtube.com/watch?v=rKnjUnZIQ48

    public class GreatSchoolDBContext : DbContext
    {
        //toda vez que for criado uma propriedade ou objeto com 'virtual' é utilizado o 'LazyLoading' para carrega-los
        //https://stackoverflow.com/a/15247765/13156642
        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Professor> Professores { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }

        public GreatSchoolDBContext() { }

        public GreatSchoolDBContext(DbContextOptions<GreatSchoolDBContext> options) : base(options) { }

        //cria os relacionamentos entre os modelos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //(1-1) uma turma tem um professor e apenas um professor
            modelBuilder.Entity<Turma>()                    //uma turma
                .HasOne(p => p.Professor)                   //tem um professor
                .WithOne(t => t.Turma)                      //e este professor possui uma turma
                .HasForeignKey<Turma>(p => p.ProfessorId);  //e a turma, tem o campo 'ProfessorId' como ForeignKey do professor     

            modelBuilder.Entity<Aluno>()        //na tabela aluno
                .Property(d => d.DataMatricula) //o campo DataMatricula
                .HasColumnType("Date");         //é do tipo Date

            //(1-N) um aluno tem uma turma
            modelBuilder.Entity<Aluno>()        //um aluno
                .HasOne(t => t.Turma)           //tem uma turma
                .WithMany(t => t.Alunos)        //a turma tem muitos alunos
                .HasForeignKey(a => a.TurmaId); //e o aluno, tem o campo 'TurmaId' como ForeignKey da turma

            //falta fazer um exemplo N-N
            //https://www.youtube.com/channel/UCoqYHkQy8q5nEMv1gkcZgSw/search?query=Fluent%20API
        }
    }
}
