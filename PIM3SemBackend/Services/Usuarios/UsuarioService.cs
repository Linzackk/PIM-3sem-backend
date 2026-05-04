using PIM_3sem_backend.DTOs.Usuarios;
using PIM_3sem_backend.Exceptions.NotFound;
using PIM_3sem_backend.Models;
using PIM_3sem_backend.Repositories.Usuarios;
using PIM_3sem_backend.Services.Perfis;

namespace PIM_3sem_backend.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IPerfilService _perfilService;
        public UsuarioService(IUsuarioRepository repository, IPerfilService perfilService)
        {
            _repository = repository;
            _perfilService = perfilService;
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

        private Usuario CriarUsuarioModel(UsuarioCreateDTO novoUsuario)
        {
            return new Usuario(novoUsuario.Email, novoUsuario.Senha, novoUsuario.IdPerfil);
        }
        private async Task<Usuario> BuscarUsuario(Guid usuarioId)
        {
            var usuario = await _repository.ObterPorId(usuarioId);
            if (usuario == null)
                throw new UsuarioNotFoundException();
            return usuario;
        }

        public async Task CriarUsuario(UsuarioCreateDTO createDTO)
        {
            var novoUsuario = CriarUsuarioModel(createDTO);
            var perfil = _perfilService.ObterPorId(createDTO.IdPerfil);

            await _repository.CriarUsuario(novoUsuario);
        }

        public async Task<UsuarioResponseDTO> ObterPorId(Guid usuarioId)
        {
            var usuario = await BuscarUsuario(usuarioId);
            return CriarUsuarioResponse(usuario);
        }

        public async Task<IReadOnlyCollection<UsuarioResponseDTO>> ObterTodos()
        {
            var usuarios = await _repository.ObterTodos();
            var response = new List<UsuarioResponseDTO>();

            foreach (var usuario in usuarios)
                response.Add(CriarUsuarioResponse(usuario));

            return response;
        }

        public async Task AlterarAcesso(Guid usuarioId)
        {
            var usuario = await BuscarUsuario(usuarioId);
            usuario.AlterarAcesso();

            await _repository.AtualizarUsuario(usuario);
        }

        public async Task RemoverUsuario(Guid usuarioId)
        {
            var usuario = await BuscarUsuario(usuarioId);
            await _repository.RemoverUsuario(usuario);
        }

    }
}
