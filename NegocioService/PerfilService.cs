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
    public class PerfilService
    {

        public PerfilDTO GeyById(int Id) {
            
            Perfil perfil = PerfilDAL.GetById(Id);

            return Convert(perfil);
        }


        private PerfilDTO Convert(Perfil perfil)
        {
            PerfilDTO dto = null;
            if (perfil != null) {
                dto = new PerfilDTO();
                dto.Id = perfil.Id;
                dto.Descripcion = perfil.Descripcion;
            }
            return dto;
        }
    }
    
}
