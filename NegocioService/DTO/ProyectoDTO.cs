using System;

namespace NegocioService.DTO
{
    public class ProyectoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Meta { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }
}
