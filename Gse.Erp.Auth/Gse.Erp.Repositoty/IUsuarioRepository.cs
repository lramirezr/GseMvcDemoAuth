using System;
using System.Collections.Generic;
using Gse.Erp.MvcAuth.Data;

namespace Gse.Erp.MvcAuth.Repository
{
    public interface IUsuarioRepository : IDisposable
    {
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Guid Id);
        void Save();
        IEnumerable<Usuario> GetAll();
        Usuario GetId(Guid Id);
    }
}
