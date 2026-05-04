using PIM_3sem_backend.Exceptions;

namespace PIM_3sem_backend.Models
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public Guid IdPerfil { get; private set; }
        public Perfil Perfil { get; private set; }
        public bool Ativo { get; private set; }

        public Usuario(string email, string senha, Guid idPerfil)
        {
            if (string.IsNullOrEmpty(email))
                throw new ModelInvalidoException("Email não pode estar vazio");

            if (string.IsNullOrEmpty(senha))
                throw new ModelInvalidoException("Senha não pode estar vazio");

            if (idPerfil == Guid.Empty)
                throw new ModelInvalidoException("idPerfil não pode estar vazio");

            Id = Guid.NewGuid();
            Email = email;
            Senha = senha;
            IdPerfil = idPerfil;
            Ativo = true;
        }
    }
}
