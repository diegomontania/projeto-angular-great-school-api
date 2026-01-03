using GreatSchool.Application.DTO.Aluno;

namespace GreatSchool.Application.Interfaces.Aluno
{
    public interface IAlunoService
    {
        public Task<IEnumerable<AlunoDto>> GetAllAlunosAsync();
        public Task<AlunoDto> GetAlunoByIdAsync(int id);
        public Task<AlunoDto> CreateAlunoAsync(CreateAlunoDto dto);
        public Task<AlunoDto> UpdateAlunoAsync(int id, UpdateAlunoDto dto);
        public Task<bool> DeleteAlunoAsync(int id);
    }
}
