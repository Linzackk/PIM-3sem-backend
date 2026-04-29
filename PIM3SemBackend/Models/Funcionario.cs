using PIM_3sem_backend.Exceptions;

namespace PIM_3sem_backend.Models
{
    public class Funcionario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Salario { get; private set; }
        public string Cargo { get; private set; }
        public Guid IdDepartamento { get; private set; }
        public Guid? IdGerente { get; private set; }

        public Funcionario(string nome, decimal salario, string cargo, Guid idDepartamento, Guid? idGerente)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ModelInvalidoException("Nome não pode estar vazio.");

            if (salario <= 0)
                throw new ModelInvalidoException("Salario deve ser maior que 0.");

            if (string.IsNullOrEmpty(cargo))
                throw new ModelInvalidoException("Cargo não pode estar vazio.");

            if (Guid.Empty == idDepartamento)
                throw new ModelInvalidoException("ID do departamento não pode estar vazio.");

            if (idGerente.HasValue && idGerente.Value == Guid.Empty)
                throw new ModelInvalidoException("ID do Gerente inválido.");

            Id = Guid.NewGuid();
            Nome = nome;
            Salario = salario;
            Cargo = cargo;
            IdDepartamento = idDepartamento;
            IdGerente = idGerente;
        }
    }
}
