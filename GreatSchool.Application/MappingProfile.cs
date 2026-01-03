using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSchool.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateAlunoDto to Aluno
            CreateMap<DTO.Aluno.CreateAlunoDto, Domain.Entities.Aluno>();

            //UpdateAlunoDto to Aluno
            CreateMap<DTO.Aluno.UpdateAlunoDto, Domain.Entities.Aluno>();

            //Aluno to AlunoDto
            CreateMap<Domain.Entities.Aluno, DTO.Aluno.AlunoDto>();

            // Example of more complex mappings:
            // Custom mapping for differing property names
            // CreateMap<Order, OrderDto>()
            //    .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.User.FullName));
        }
    }
}
