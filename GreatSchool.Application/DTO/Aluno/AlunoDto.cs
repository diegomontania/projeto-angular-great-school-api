using System.ComponentModel.DataAnnotations;

namespace GreatSchool.Application.DTO.Aluno
{
    //Aluno Data Transfer Object - only the properties that will be exposed to the client

    public class AlunoDto
    {
        [Required]
        [Key()]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s]{1,50}$", ErrorMessage = "O nome deve conter apenas letras e ter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s]{1,50}$", ErrorMessage = "O sobrenome deve conter apenas letras e ter no máximo 50 caracteres")]
        public string Sobrenome { get; set; }

        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
    }
}
