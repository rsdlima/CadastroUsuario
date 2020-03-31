using CadastroUsuario.api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.api.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> All { get; }
        void Alterar(params TEntity[] obj);
        TEntity Buscar(int id);
        void Excluir(int id);
        void Incluir(params TEntity[] obj);
    }
}
