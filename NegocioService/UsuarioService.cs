using Modelo;
using Negocio;
using NegocioService.DTO;
using NegocioService.Helper;

namespace NegocioService
{
    public class UsuarioService
    {
        //public UsuarioDTO GetById(int id) {

        //}

        public int SaveOrUpdate(UsuarioDTO dto)
        {
            return UsuarioDAL.SaveOrUpdate(ToEntity(dto));

        }


        public UsuarioDTO GetByLogin(string user, string password) {
            UsuarioDTO dto = null;
            //Parte 3: Iniciar sesión con Credenciales ingresadas
            Usuario usuario = UsuarioDAL.GetByLogin(user, Seguridad.GetInstance.GetMD5(password));
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
            dto.Perfil = new PerfilDTO(){ Id = usuario.Perfil.Id, Descripcion = usuario.Perfil.Descripcion }; 
            return dto;
        }
    }   
    
}
