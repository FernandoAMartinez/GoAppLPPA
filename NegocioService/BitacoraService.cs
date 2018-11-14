using Modelo;
using Negocio;
using NegocioService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioService
{
    public class BitacoraService
    {

        public int Insert(BitacoraDTO dto)
        {
            Bitacora bitacora = ToEntity(dto);
            return BitacoraDAL.Insert(bitacora);
        }

        public List<BitacoraDTO> GetAll()
        {
            List<BitacoraDTO> ret = new List<BitacoraDTO>();
            List<Bitacora> bitacoras = BitacoraDAL.GetAll();
            bitacoras.ForEach(b =>{
                ret.Add(ToDTO(b));
            });

            return ret;
        }

        private Bitacora ToEntity(BitacoraDTO dto)
        {
            Bitacora bitacora = null;
            if (dto != null) {
                bitacora = new Bitacora();
                bitacora.Id = dto.Id;
                bitacora.Accion = dto.Accion;
                bitacora.Descripcion = dto.Descripcion;
                bitacora.Fecha = dto.Fecha;
                bitacora.Usuario = new Usuario() { Id = dto.Usuario.Id };
            }

            return bitacora;
        }

        private BitacoraDTO ToDTO(Bitacora entity)
        {
            BitacoraDTO dto = null;
            if (entity != null) {
                dto = new BitacoraDTO();
                dto.Id = entity.Id;
                dto.Accion = entity.Accion;
                dto.Descripcion = entity.Descripcion;
                dto.Fecha = entity.Fecha;
                if (entity.Usuario != null)
                    dto.Usuario = new UsuarioDTO() { Id = entity.Usuario.Id, UserName = entity.Usuario.UserName };
                else
                    dto.Usuario = new UsuarioDTO(); 
            }
            return dto;
        }
    }
}
