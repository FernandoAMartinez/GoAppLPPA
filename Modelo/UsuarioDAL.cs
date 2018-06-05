using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
   public static class UsuarioDAL
    {

        
        public static int SaveOrUpdate(Usuario usuario) {

           int ret = DataAccess.Instance.Write(usuario);
            return ret;
        }


    }
}
