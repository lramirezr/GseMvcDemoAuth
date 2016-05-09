using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gse.Erp.MvcAuth.Repository
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string NombreUsuario { get; set; }
        public Byte[] Contrasenya { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
