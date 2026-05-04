using PIM_3sem_backend.DTOs.Usuarios;
using PIM_3sem_backend.Models;
using PIM_3sem_backend.Repositories.Usuarios;

namespace PIM_3sem_backend.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        private UsuarioResponseDTO CriarUsuarioResponse(Usuario usuario)
        {
            return new UsuarioResponseDTO()
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Perfil = usuario.Perfil.Nome,
                Status = usuario.Ativo ? "Ativo" : "Desativado"
            };
        }
    }
}
