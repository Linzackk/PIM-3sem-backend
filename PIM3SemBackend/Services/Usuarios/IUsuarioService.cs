using PIM_3sem_backend.DTOs.Usuarios;

namespace PIM_3sem_backend.Services.Usuarios
{
    public interface IUsuarioService
    {
        Task CriarUsuario(UsuarioCreateDTO novoUsuario);
        Task<UsuarioResponseDTO> ObterPorId(Guid usuarioId);
        Task<IReadOnlyCollection<UsuarioResponseDTO>> ObterTodos();
        Task DesativarAcesso();
        Task RemoverUsuario(Guid usuarioId);
    }
}
