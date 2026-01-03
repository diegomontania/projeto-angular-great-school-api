using AutoMapper;
using GreatSchool.Application.DTO.Aluno;
using GreatSchool.Application.Interfaces.Aluno;
using GreatSchool.Domain.Interfaces;

namespace GreatSchool.Application.Services
{
    //AlunoDto : Aluno Data Transfer Object - only the properties that will be exposed to the client
    //At this moment, only Id, Nome, Sobrenome and Email will be exposed to the client

    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        async Task<IEnumerable<AlunoDto>> IAlunoService.GetAllAlunosAsync()
        {
            var allAlunos = await _alunoRepository.GetAllAsync();

            //convert List<Aluno> to List<AlunoDto>
            var alunosDTos = _mapper.Map<List<AlunoDto>>(allAlunos);

            return alunosDTos;
        }

        async Task<AlunoDto> IAlunoService.GetAlunoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        async Task<AlunoDto> IAlunoService.CreateAlunoAsync(CreateAlunoDto dto)
        {
            //convert CreateAlunoDto to Aluno
            var aluno = _mapper.Map<Domain.Entities.Aluno>(dto);

            //salvar Aluno
            var retornoAluno = await _alunoRepository.AddAsync(aluno);

            //Convert Aluno to AlunoDto
            var alunoDto = _mapper.Map<AlunoDto>(retornoAluno);

            return alunoDto;
        }

        async Task<AlunoDto> IAlunoService.UpdateAlunoAsync(int id, UpdateAlunoDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAlunoAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
