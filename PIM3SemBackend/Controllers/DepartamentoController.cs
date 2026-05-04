using Microsoft.AspNetCore.Mvc;
using PIM_3sem_backend.Services.Departamentos;

namespace PIM_3sem_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _service;
        public DepartamentoController(IDepartamentoService service)
        {
            _service = service;
        }

        [HttpGet("{departamentoId}")]
        public async Task<IActionResult> ObterPorId(Guid departamentoId)
        {
            var departamento = await _service.ObterPorId(departamentoId);
            return Ok(departamento);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var departamentos = await _service.ObterTodos();
            return Ok(departamentos);
        }
    }
}
