using CadastroUsuario.api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.api.Data.Repository
{
    public class RepositorioEF<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly UsuarioContext _context;

        public RepositorioEF(UsuarioContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> All => _context.Set<TEntity>().AsEnumerable();

        public void Alterar(params TEntity[] obj)
        {
            _context.Set<TEntity>().UpdateRange(obj);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var obj = _context.Find<TEntity>(id);
            _context.Set<TEntity>().RemoveRange(obj);
            _context.SaveChanges();
        }

        public TEntity Buscar(int key)
        {
            return _context.Find<TEntity>(key);
        }

        public void Incluir(params TEntity[] obj)
        {
            _context.Set<TEntity>().AddRange(obj);
            _context.SaveChanges();
        }
    }
}
