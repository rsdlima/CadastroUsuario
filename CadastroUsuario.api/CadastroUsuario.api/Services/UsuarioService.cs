using CadastroUsuario.api.Domain.Model;
using CadastroUsuario.api.Domain.Repositories;
using CadastroUsuario.api.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _repo;

        public UsuarioService(IRepository<Usuario> postRepository)
        {
            _repo = postRepository;
        }

        public IEnumerable<Usuario> All()
        {
            return _repo.All;
        }

        public void Alterar(params Usuario[] usuarios)
        {
            _repo.Alterar(usuarios);
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public Usuario Buscar(int id)
        {
           return _repo.Buscar(id);
        }

        public void Incluir(params Usuario[] usuarios)
        {
            _repo.Incluir(usuarios);
        }
    }
}
