using System;
using System.Collections.Generic;

namespace Gse.Erp.MvcAuth.Dtos
{
    public class Usuario
    {
        public string Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenya { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public DateTime FechaModificacion { get; set; }
        public List<Empresa> Empresas { get; set; }
    }
}