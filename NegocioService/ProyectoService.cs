using Modelo;
using Negocio;
using NegocioService.DTO;
using NegocioService.Helper;
using System.Data;

namespace NegocioService
{
    public class ProyectoService
    {
        public int SaveOrUpdate(ProyectoDTO dto)
        {
            return ProyectoDAL.SaveOrUpdate(ToEntity(dto));
        }

        //Inicio Modificación - FernandoAMartinez
        public DataTable ConsultaProyectos()
        {
            return ProyectoDAL.ConsultaProyectos();
        }
        //Fin Modificación - FernandoAMartinez

        public ProyectoDTO GetById(int id)
        {
            ProyectoDTO dto = null;
            Proyecto proyecto = ProyectoDAL.GetById(id);
            if (proyecto != null)
                dto = ToDTO(proyecto);

            return dto;
        }

        public Proyecto ToEntity(ProyectoDTO dto)
        {
            Proyecto proyecto = new Proyecto();
            proyecto.Id = dto.Id;
            proyecto.Nombre = dto.Nombre;
            proyecto.MetaRecaud = dto.Meta;
            proyecto.FechaInicio = dto.FechaInicio;
            proyecto.FechaFin = dto.FechaFin;
            return proyecto;
        }

        public ProyectoDTO ToDTO(Proyecto proyecto)
        {
            ProyectoDTO dto = new ProyectoDTO();
            dto.Id = proyecto.Id;
            dto.Nombre = proyecto.Nombre;
            dto.Meta = proyecto.MetaRecaud;
            dto.FechaInicio = proyecto.FechaInicio;
            dto.FechaFin = proyecto.FechaFin;
            return dto;
        }
    }
}
