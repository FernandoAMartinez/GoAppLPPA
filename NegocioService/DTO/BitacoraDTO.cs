using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioService.DTO
{
    public class BitacoraDTO
    {

        public int Id { get; set; }

        public string Accion { get; set; }
        
        public string Descripcion { get; set; }
        
        public DateTime Fecha { get; set; }
        
        public UsuarioDTO Usuario { get; set; } 

    }
}
