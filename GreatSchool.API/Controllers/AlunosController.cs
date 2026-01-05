using System.Collections.Generic;
using System.Threading.Tasks;
using GreatSchool.Application.DTO.Aluno;
using GreatSchool.Application.Interfaces.Aluno;
using Microsoft.AspNetCore.Mvc;

namespace GreatSchool.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoDto>>> GetAlunos()
        {
            var alunos = await _alunoService.GetAllAlunosAsync();
            return Ok(alunos);
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoDto>> GetAluno(int id)
        {
            var aluno = await _alunoService.GetAlunoByIdAsync(id);

            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }

        // PUT: api/Alunos/5 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, AlunoDto alunoDto)
        {
            var alunoAtualizado = await _alunoService.UpdateAlunoAsync(id, alunoDto);

            if (alunoAtualizado == null)
                return NotFound(); 
            
            return Ok(alunoAtualizado);

        }

        // POST: api/Alunos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AlunoDto>> PostAluno(CreateAlunoDto alunoDto)
        {
            var alunoCriado = await _alunoService.CreateAlunoAsync(alunoDto);
            return CreatedAtAction("GetAlunoAsync", new { id = alunoCriado.Id }, alunoDto);
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlunoDto>> DeleteAluno(int id)
        {
            var aluno = await _alunoService.DeleteAlunoAsync(id);

            if (!aluno)
                return NotFound();

            return Ok(aluno);
        }
    }
}
