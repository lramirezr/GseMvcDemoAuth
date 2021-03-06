﻿using Gse.Erp.Auth.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Gse.Erp.Auth.Repository
{
    public class UsuarioRepository : IUsuarioRepository, IDisposable
    {
        private DbContext _dbContext;
        public UsuarioRepository(DbContext db)
        {
            _dbContext = db;
        }

        public void Add(Usuario usuario)
        {
            this._dbContext.Set<Usuario>().Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            this._dbContext.Entry(usuario).State = EntityState.Modified;
        }

        public void Delete(Guid Id)
        {
            Usuario usuario = this._dbContext.Set<Usuario>().Find(Id);
            this._dbContext.Set<Usuario>().Remove(usuario);
        }

        public IEnumerable<Usuario> GetAll()
        {
           return _dbContext.Set<Usuario>()
                .AsNoTracking()
                .ToList();
        }

        public Usuario GetId(Guid Id)
        {
            return _dbContext.Set<Usuario>().Find(Id);
        }

        public void Save()
        {
            this._dbContext.SaveChanges();
        }

        #region IDisposable Support
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
