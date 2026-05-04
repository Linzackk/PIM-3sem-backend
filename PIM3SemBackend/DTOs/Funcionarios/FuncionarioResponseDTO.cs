namespace PIM_3sem_backend.DTOs.Funcionarios
{
    public class FuncionarioResponseDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public string? Gerente { get; set; } = string.Empty;
    }
}
