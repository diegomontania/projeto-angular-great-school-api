using System.ComponentModel.DataAnnotations;

namespace GreatSchool.Application.DTO.Aluno
{
    public class CreateAlunoDto
    {
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s]{1,50}$", ErrorMessage = "O sobrenome deve conter apenas letras e ter no máximo 50 caracteres")]
        public string Sobrenome { get; set; }

        [Required]
        [MaxLength(2)]
        [RegularExpression(@"^[1-9][0-9]$", ErrorMessage = "DDD inválido")]
        public string DddTelefone { get; set; }

        [Required]
        [RegularExpression(@"^\d{8,9}$", ErrorMessage = "Número de telefone inválido")]
        public string Telefone { get; set; }

        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required]
        [MaxLength(2)]
        [RegularExpression(@"^[A-Za-z]{2}$", ErrorMessage = "O estado deve conter exatamente 2 letras")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "A data de matrícula é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataMatricula { get; set; }
    }
}
