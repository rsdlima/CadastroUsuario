using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.api.Domain.Model
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int SexoId { get; set; }

        public bool Ativo { get; set; }

        public Sexo Sexo { get; set; }
    }
    public class Usuarios
    {
        public Usuario[] ListaUsuarios { get; set; }
    }
}
