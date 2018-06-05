using Ambiente;
using Negocio;
using NegocioService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioService
{
    public class UsuarioService
    {
        public UsuarioDTO GetById(int id) {

        }

        public int SaveOrUpdate(UsuarioDTO dto)
        {


        }

        private Usuario ToEntity(UsuarioDTO dto) {
            Usuario usuario = new Usuario();
            usuario.Password = Seguridad.GetInstance.GetMD5(dto.Password);
            usuario.UserName = dto.UserName;
            usuario.Id = dto.Id;
            usuario.IsBlocked = dto.IsBlocked;
            usuario.Tries = dto.Tries;
            return usuario;
        }
    }   
    
}
