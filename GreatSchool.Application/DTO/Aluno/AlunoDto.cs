using System.ComponentModel.DataAnnotations;

namespace GreatSchool.Application.DTO.Aluno
{
    //Aluno Data Transfer Object - only the properties that will be exposed to the client
    //DTOs dont should inherit from BaseEntity
    //DTOs CAN inhrit from 'BaseDTO' if you have one

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
        [MaxLength(2)]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "O DDD do telefone deve conter exatamente 2 dígitos numéricos")]
        public string DddTelefone { get; set; }

        [Required]
        [MaxLength(9)]
        [RegularExpression(@"^\d{8,9}$", ErrorMessage = "O telefone deve conter entre 8 e 9 dígitos numéricos")]
        public string Telefone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataMatricula { get; private set; }

        [Required]
        //[MaxLength(2)]
        //[RegularExpression(@"^[a-zA-ZÀ-ÿ\s]{1, 2}$", ErrorMessage = "A sigla do estado deve conter apenas letras e ter no máximo 2 caracteres")]
        public string Estado { get; set; }

        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
    }
}
