namespace PIM_3sem_backend.DTOs.Funcionarios
{
    public class FuncionarioCreateDTO
    {
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public string Cargo { get; set; }
        public Guid IdDepartamento { get; set; }
        public Guid? IdGerente { get; set; }
    }
}
