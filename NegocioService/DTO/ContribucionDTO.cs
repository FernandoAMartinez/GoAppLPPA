using System;
using System.Collections.Generic;

namespace NegocioService.DTO
{
    public class ContribucionDTO
    {
        public int IdVenta { get; set; }

        //Inicio Modificación - FernandoAMartinez
        //public int IdProy { get; set; }
        public ProyectoDTO Proyecto {get; set;}
        //Fin Modificación - FernandoAMartinez


        public int Cantidad { get; set; }

        public int Importe { get; set; }
    }
}
