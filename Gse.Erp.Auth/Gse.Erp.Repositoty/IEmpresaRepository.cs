using System;
using System.Collections.Generic;
using Gse.Erp.MvcAuth.Data;

namespace Gse.Erp.MvcAuth.Repository
{
    public interface IEmpresaRepository : IDisposable
    {
        void Add(Empresa empresa);
        void Update(Empresa empresa);
        void Delete(Guid Id);
        void Save();
        IEnumerable<Empresa> GetAll();
        Empresa GetId(Guid Id);
    }
}
