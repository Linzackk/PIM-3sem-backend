using Microsoft.EntityFrameworkCore;
using PIM_3sem_backend.Models;

namespace PIM_3sem_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Salario> Salarios { get; set; }
        public DbSet<PontoRegistro> PontosRegistro { get; set; }

    }
}
