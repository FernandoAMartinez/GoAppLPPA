using Negocio;
using NegocioService.DTO;

namespace NegocioService
{
    public class TarjetaService
    {
        //public TarjetaDTO GetById(int id)
        //{
        //    TarjetaDTO dto = null;
        //    Tarjeta tarjeta = TarjetaService.GetById(id);
        //    if (tarjeta != null)
        //        dto = ToDTO(tarjeta);
        //
        //    return dto;
        //}

        public Tarjeta ToEntity(TarjetaDTO dto)
        {
            Tarjeta tarjeta = new Tarjeta();
            tarjeta.Id = dto.Id;
            tarjeta.UsuarioId = dto.UsuarioId;
            tarjeta.CardNumber = dto.CardNumber;
            tarjeta.Desde = dto.Desde;
            tarjeta.Hasta = dto.Hasta;
            tarjeta.CCV = dto.CCV;
            return tarjeta;
        }

        public TarjetaDTO ToDTO(Tarjeta tarjeta)
        {
            TarjetaDTO dto = new TarjetaDTO();
            dto.Id = tarjeta.Id;
            dto.UsuarioId = tarjeta.UsuarioId;
            dto.CardNumber = tarjeta.CardNumber;
            dto.Desde = tarjeta.Desde;
            dto.Hasta = tarjeta.Hasta;
            dto.CCV = tarjeta.CCV;
            return dto;
        }
    }
}
