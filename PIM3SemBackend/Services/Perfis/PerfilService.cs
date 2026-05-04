using PIM_3sem_backend.DTOs.Perfis;
using PIM_3sem_backend.Exceptions;
using PIM_3sem_backend.Models;
using PIM_3sem_backend.Repositories.Perfis;

namespace PIM_3sem_backend.Services.Perfis
{
    public class PerfilService : IPerfilService
    {
        private readonly PerfilRepository _repository;
        public PerfilService(PerfilRepository repository)
        {
            _repository = repository;
        }
        private PerfilResponseDTO CriarPerfilReponse(Perfil perfil)
        {
            return new PerfilResponseDTO() { Id = perfil.Id, Nome = perfil.Nome };
        }

        public async Task<PerfilResponseDTO> ObterPorId(Guid perfilId)
        {
            var perfil = await _repository.ObterPorId(perfilId);
            if (perfil == null)
                throw new PerfilNotFoundException();

            return CriarPerfilReponse(perfil);
        }

        public async Task<IReadOnlyCollection<PerfilResponseDTO>> ObterTodos()
        {
            var perfis = await _repository.ObterTodos();
            var response = new List<PerfilResponseDTO>();
            foreach (var perfil in perfis)
                response.Add(CriarPerfilReponse(perfil));

            return response;
        }
    }
}
