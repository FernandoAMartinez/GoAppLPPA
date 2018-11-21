using System;
using Negocio;
using System.Collections.Generic;

namespace NegocioService.DTO
{
    public class VentaDTO
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public List<ContribucionDTO> Contribuciones { get; set; }
    }
}
