using System.ComponentModel.DataAnnotations;

namespace GreatSchool.Domain.Entities
{
    public class Professor
    {
        [Required]
        [Key()]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string SobreNome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Disciplina { get; set; }

        [Required] //deixando explicito que o professor tem apenas uma turma
        public Turma Turma { get; set; } //propriedade de navegacao
    }
}
