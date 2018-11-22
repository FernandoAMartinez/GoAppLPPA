using Negocio;

namespace NegocioService.DTO
{
    public class TarjetaDTO
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string CardNumber { get; set; }

        public string Desde { get; set; }

        public string Hasta { get; set; }

        public string CCV { get; set; }
    }
}
