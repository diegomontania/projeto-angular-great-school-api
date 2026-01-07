namespace GreatSchool.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DddTelefone { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public DateTime DataMatricula { get; private set; } //set privado para evitar que a data de matricula seja alterada apos a criacao do aluno

        //1 aluno está associado a 1 turma - ForeignKey
        //possui um nullable na propriedade ID e na propriedade de navegacao, significa que o relacionamento é opcional. Um aluno pode ter ou não uma turma.
        //porem o Id da turma nem o objeto de navegacao sao necessarios para criacao de um aluno
        public int? TurmaId { get; set; }

        public Turma? Turma { get; set; } //propriedade de navegacao https://stackoverflow.com/a/11508155/13156642

        public void SetMatricula(DateTime dateTime)
        {
            if (DataMatricula == default) // Only set if not already set
                DataMatricula = dateTime;
        }
    }
}
