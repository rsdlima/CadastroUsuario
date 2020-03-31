using CadastroUsuario.api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.api.Domain.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> All();
        void Alterar(params Usuario[] obj);
        Usuario Buscar(int id);
        void Excluir(int id);
        void Incluir(params Usuario[] obj);
    }
}
