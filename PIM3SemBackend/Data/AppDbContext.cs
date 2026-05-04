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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Nome)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasMany<Funcionario>()
                    .WithOne()
                    .HasForeignKey(f => f.IdDepartamento)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.Senha)
                    .IsRequired();

                entity.Property(u => u.IdPerfil)
                    .IsRequired();

                entity.Property(u => u.Ativo)
                    .IsRequired();

                entity.HasOne(u => u.Perfil)
                    .WithMany()
                    .HasForeignKey(u => u.IdPerfil)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.Property(f => f.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(f => f.Salario) // Alterar caso use a tabela Salario
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");

                entity.Property(f => f.Cargo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(f => f.IdDepartamento)
                    .IsRequired();

                entity.HasOne<Funcionario>()
                    .WithMany()
                    .HasForeignKey(f => f.IdGerente)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany<PontoRegistro>()
                    .WithOne()
                    .HasForeignKey(pr => pr.IdFuncionario)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Salario>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Valor)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");

                entity.Property(s => s.DataInicio)
                    .IsRequired();

                entity.Property(s => s.DataFim)
                    .IsRequired(false);

                entity.Property(s => s.MotivoAlteracao)
                    .IsRequired(false);
            });

            modelBuilder.Entity<PontoRegistro>(entity =>
            {
                entity.HasKey(pr => pr.Id);

                entity.Property(pr => pr.Data)
                    .IsRequired();

                entity.Property(pr => pr.HoraEntrada)
                    .IsRequired();

                entity.Property(pr => pr.HoraSaida)
                    .IsRequired(false);

                entity.Property(pr => pr.Status)
                    .IsRequired();
            });
        }
    }
}
