using Microsoft.EntityFrameworkCore;
using PIM_3sem_backend.Models;

namespace PIM_3sem_backend.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate(); // garante que as migrations rodaram

            var perfisExistentes = context.Perfis.Select(p => p.Nome).ToHashSet();

            var perfisParaAdicionar = new[] { "CEO", "Gerente", "Funcionario" }
                .Where(nome => !perfisExistentes.Contains(nome))
                .Select(nome => new Perfil(nome))
                .ToList();

            if (perfisParaAdicionar.Any())
            {
                context.Perfis.AddRange(perfisParaAdicionar);
                context.SaveChanges();
            }
        }
    }
}
