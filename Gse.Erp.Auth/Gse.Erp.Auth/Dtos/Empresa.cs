using System;

namespace Gse.Erp.MvcAuth.Dtos
{
    public class Empresa
    {
        public string Id { get; set; }
        public string Cif { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioId { get; set; }
    }
}