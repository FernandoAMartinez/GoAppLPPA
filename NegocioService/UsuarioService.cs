using Ambiente;
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
    public class UsuarioService
    {
        //public UsuarioDTO GetById(int id) {

        //}

        //public int SaveOrUpdate(UsuarioDTO dto)
        //{


        //}


        public UsuarioDTO GetByLogin(string user, string password) {
            UsuarioDTO dto = null;

            Usuario usuario = UsuarioDAL.GetByLogin(user, password);
            if (usuario != null)
                dto = ToDTO(usuario);

            return dto;
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

        private UsuarioDTO ToDTO(Usuario usuario)
        {
            UsuarioDTO dto = new UsuarioDTO();
            dto.Password = usuario.Password;
            dto.UserName = usuario.UserName;
            dto.Id = usuario.Id;
            dto.IsBlocked = usuario.IsBlocked;
            dto.Tries = usuario.Tries;
            return dto;
        }
    }   
    
}
