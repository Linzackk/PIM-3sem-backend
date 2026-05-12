using Microsoft.AspNetCore.Mvc;
using PIM_3sem_backend.DTOs.Login;
using PIM_3sem_backend.Services.Usuarios;

namespace PIM_3sem_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> FazerLogin([FromBody] FazerLoginDTO login)
        {
            var sucesso = await _usuarioService.FazerLogin(login);
            return Ok(sucesso);
        }
    }
}
