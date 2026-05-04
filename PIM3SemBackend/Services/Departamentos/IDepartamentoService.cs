using PIM_3sem_backend.DTOs.Perfis;

namespace PIM_3sem_backend.Services.Departamentos
{
    public interface IDepartamentoService
    {
        Task<DepartamentoResponseDTO> ObterPorId(Guid departamentoId);
        Task<IReadOnlyCollection<DepartamentoResponseDTO>> ObterTodos();
    }
}
