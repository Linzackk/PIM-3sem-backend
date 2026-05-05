using Microsoft.AspNetCore.Mvc;
using PIM_3sem_backend.DTOs.Funcionarios;
using PIM_3sem_backend.Services.Funcionarios;

namespace PIM_3sem_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _service;
        public FuncionarioController(IFuncionarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarNovoFuncionario([FromBody] FuncionarioCreateDTO novoFuncionario)
        {
            var funcionarioCriado = await _service.CriarFuncionario(novoFuncionario);
            return CreatedAtAction(nameof(ObterPorId), new { funcionarioId = funcionarioCriado.Id }, funcionarioCriado);
        }

        [HttpGet("{funcionarioId}")]
        public async Task<IActionResult> ObterPorId(Guid funcionarioId)
        {
            var funcionario = await _service.ObterPorId(funcionarioId);
            return Ok(funcionario);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var funcionarios = await _service.ObterTodos();
            return Ok(funcionarios);
        }

        [HttpGet("Gerentes/{gerenteId}")]
        public async Task<IActionResult> ObterFuncionariosDoGerente(Guid gerenteId)
        {
            var funcionarios = await _service.ObterFuncionarioDoGerente(gerenteId);
            return Ok(funcionarios);
        }

        [HttpGet("Gerentes")]
        public async Task<IActionResult> ObterTodosGerentes()
        {
            var gerentes = await _service.ObterTodosGerentes();
            return Ok(gerentes);
        }

        [HttpPatch("{funcionarioId}")]
        public async Task<IActionResult> AtualizarFuncionario([FromBody] FuncionarioUpdateDTO funcionarioAtualizado, Guid funcionarioId)
        {
            await _service.AtualizarFuncionario(funcionarioAtualizado, funcionarioId);
            return NoContent();
        }

        [HttpDelete("{funcionarioId}")]
        public async Task<IActionResult> RemoverFuncionario(Guid funcionarioId)
        {
            await _service.RemoverFuncionario(funcionarioId);
            return NoContent();
        }
    }
}
