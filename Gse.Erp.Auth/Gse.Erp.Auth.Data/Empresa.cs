﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gse.Erp.Auth.Data
{
    public class Empresa
    {
        public Guid Id { get; set; }
        public string Cif { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid? UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}