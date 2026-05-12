using Moq;
using PIM_3sem_backend.DTOs.Departamentos;
using PIM_3sem_backend.DTOs.Usuarios;
using PIM_3sem_backend.Models;
using PIM_3sem_backend.Repositories.Departamentos;
using PIM_3sem_backend.Repositories.Funcionarios;
using PIM_3sem_backend.Services.Departamentos;
using PIM_3sem_backend.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM3SemTestes.Funcionarios
{
    public class FuncionarioServiceTest
    {
        private Guid IdTeste = Guid.NewGuid();

        private Funcionario CriarFuncionarioModel()
        {
            return new Funcionario("Nome", 4321, "Teste", IdTeste, IdTeste, IdTeste);
        }

        private DepartamentoResponseDTO CriarDepartamentoModel()
        {
            return new DepartamentoResponseDTO() { Id = IdTeste, Nome = "Teste" };
        }

        private UsuarioResponseDTO CriarUsuarioGerenteResponse()
        {
            return new UsuarioResponseDTO()
            {
                Id = IdTeste,
                Email = "email",
                Perfil = "Gerente",
                Status = "Ativo"
            };
        }

        private UsuarioCreateDTO CriarUsuarioCreate()
        {
            return new UsuarioCreateDTO() { Email = "email", IdPerfil = IdTeste, Senha = "Senha" };
        }

        [Fact]
        public async Task DeveCriarNovoGerente()
        {
            var funcionario = CriarFuncionarioModel();
            var departamento = CriarDepartamentoModel();
            var usuario = CriarUsuarioCreate();
            var usuarioResponse = CriarUsuarioGerenteResponse();

            var mockDepartamento = new Mock<IDepartamentoService>();
            mockDepartamento.Setup(x => x.ObterPorId(IdTeste))
                .ReturnsAsync(departamento);

            var mockUsuario = new Mock<IUsuarioService>();
            mockUsuario.Setup(x => x.CriarUsuario(usuario))
                .ReturnsAsync(usuarioResponse);

            var mock = new Mock<IFuncionarioRepository>();
            var 

        }
    }
}
