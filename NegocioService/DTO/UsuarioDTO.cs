using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioService.DTO
{
    public class UsuarioDTO
    {

        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsBlocked { get; set; }

        public int Tries { get; set; }
    }
}
