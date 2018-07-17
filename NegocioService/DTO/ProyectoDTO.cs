using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioService.DTO
{
    class ProyectoDTO
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public double Importe { get; set; }

        public string FechaIncio { get; set; }

    }
}
