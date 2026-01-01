using GreatSchool.API.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Runtime.ConstrainedExecution;

namespace GreatSchool.API.Models
{
    public class Aluno
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

        //1 aluno está associado a 1 turma - ForeignKey
        //possui um nullable na propriedade ID e na propriedade de navegacao, significa que o relacionamento é opcional. Um aluno pode ter ou não uma turma.
        //porem o Id da turma nem o objeto de navegacao sao necessarios para criacao de um aluno
        public int? TurmaId { get; set; }

        public Turma? Turma { get; set; } //propriedade de navegacao https://stackoverflow.com/a/11508155/13156642
    }
}
