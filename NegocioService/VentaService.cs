using Negocio;
using Modelo;
using System.Data;
using NegocioService;
using NegocioService.DTO;
using System.Collections.Generic;

namespace NegocioService
{
    public class VentaService
    {
        private ContribucionService _contribucionService;

        public ContribucionService ContribucionService
        {
            get
            {
                if (_contribucionService == null)
                    _contribucionService = new ContribucionService();

                return _contribucionService;
            }
        }

        public int SaveOrUpdate(VentaDTO dto)
        {
            return VentaDAL.SaveOrUpdate(ToEntity(dto));
        }

        //Inicio Modificación - FernandoAMartinez
        public int GetNextId(string tabla)
        {
            return VentaDAL.GetNextId(tabla);
        }
        //Fin Modificación - FernandoAMartinez

        public VentaDTO GetById(int id)
        {
            VentaDTO dto = null;
            Venta venta = VentaDAL.GetById(id);
            if (venta != null)
                dto = ToDTO(venta);

            return dto;
        }

        //TODO: MODIFICAR CAMPOS DE OBJETO
        private Venta ToEntity(VentaDTO dto)
        {
            Venta venta = new Venta();
            //Inicio Modificación - FernandoAMartinez
            venta.Contribuciones = new List<Contribucion>();
            //Fin Modificación - FernandoAMartinez
            venta.Id = dto.Id;
            venta.UsuarioId = dto.UsuarioId;
            venta.Fecha = dto.Fecha;
            //venta.Contribuciones = null;
            foreach (ContribucionDTO cont in dto.Contribuciones)
            {
                venta.Contribuciones.Add(ContribucionService.ToEntity(cont));
            }
            //venta.Contribuciones = dto.Contribuciones;
            return venta;
        }

        //TODO: MODIFICAR CAMPOS DE OBJETO
        private VentaDTO ToDTO(Venta venta)
        {
            VentaDTO dto = new VentaDTO();
            dto.Id = venta.Id;
            dto.UsuarioId = venta.UsuarioId;
            dto.Fecha = venta.Fecha;
            foreach (Contribucion cont in venta.Contribuciones)
            {
                dto.Contribuciones.Add(ContribucionService.ToDTO(cont));
            }
            //dto.Contribuciones = venta.Contribuciones;
            return dto;
        }
    }
}
