using Negocio;
using Modelo;
using NegocioService;
using NegocioService.DTO;

namespace NegocioService
{
    public class ContribucionService
    {
        private ProyectoService _proyectoService;

        public ProyectoService ProyectoService
        {
            get
            {
                if (_proyectoService == null)
                    _proyectoService = new ProyectoService();

                return _proyectoService;
            }
        }

        public int SaveOrUpdate(ContribucionDTO dto)
        {
            return ContribucionDAL.SaveOrUpdate(ToEntity(dto));
        }

        public ContribucionDTO GetById(int id)
        {
            ContribucionDTO dto = null;
            Contribucion contribucion = ContribucionDAL.GetById(id);
            if (contribucion != null)
                dto = ToDTO(contribucion);

            return dto;
        }

        public Contribucion ToEntity(ContribucionDTO dto)
        {
            Contribucion contribucion = new Contribucion();
            contribucion.IdVenta = dto.IdVenta;
            //Inicio Modificación - FernandoAMartinez
            //contribucion.IdProy = dto.IdProy;
            contribucion.Proyecto = ProyectoService.ToEntity(dto.Proyecto);
            //Fin Modificación - FernandoAMartinez
            contribucion.Cantidad = dto.Cantidad;
            contribucion.Importe = dto.Importe;
            return contribucion;
        }

        public ContribucionDTO ToDTO(Contribucion contribucion)
        {
            ContribucionDTO dto = new ContribucionDTO();
            dto.IdVenta = contribucion.IdVenta;
            //Inicio Modificación - FernandoAMartinez
            //dto.IdProy = contribucion.IdProy;
            dto.Proyecto = ProyectoService.ToDTO(contribucion.Proyecto);
            //Fin Modificación - FernandoAMartinez
            dto.Cantidad = contribucion.Cantidad;
            dto.Importe = contribucion.Importe;
            return dto;
        }
    }
}
