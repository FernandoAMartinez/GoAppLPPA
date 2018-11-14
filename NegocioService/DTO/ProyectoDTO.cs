using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioService.DTO
{
    public class ProyectoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public double Meta { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }
}
