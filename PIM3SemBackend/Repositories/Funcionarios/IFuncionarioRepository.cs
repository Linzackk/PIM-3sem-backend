using PIM_3sem_backend.Models;

namespace PIM_3sem_backend.Repositories.Funcionarios
{
    public interface IFuncionarioRepository
    {
        Task CriarFuncionario(Funcionario novoFuncionario);
        Task<Funcionario?> ObterPorId(Guid funcionarioId);
        Task<List<Funcionario>> ObterTodos();
        Task<List<Funcionario>> ObterFuncionarioDoGerente(Guid gerenteId);
        Task AtualizarFuncionario(Funcionario funcionarioAtualizado);
        Task RemoverFuncionario(Funcionario funcionario);

    }
}
