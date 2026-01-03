using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GreatSchool.Domain.Entities
{
    public class Turma
    {
        [Required]
        [Key()]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Turno { get; set; }

        [MaxLength(4)]
        [Required]
        public int Ano { get; set; }

        //uma turma tem um professor - ForeignKey
        //se nao possuir um nullable na propriedade ID 1 para 1, significa que SEMPRE uma turma precisa ter um professor
        public int ProfessorId { get; set; }

        [Required] //deixando explicito que a turma PRECISA ter um professor
        public Professor Professor { get; set; } //propriedade de navegacao

        //1 turma pode ter N alunos, logo a turma tem uma lista de alunos associados a essa turma
        public ICollection<Aluno> Alunos { get; set; } //propriedade de navegacao https://stackoverflow.com/a/11508155/13156642
    }
}
