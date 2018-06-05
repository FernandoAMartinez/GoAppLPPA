using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
   public static class UsuarioDAL
    {
        
        public static int SaveOrUpdate(Usuario usuario) {

           int ret = DataAccess.Instance.Write("Usuario_InsertOrUpdate",new SqlParameter[]{
               DataAccess.CreateParameter("UserName", usuario.UserName),
               DataAccess.CreateParameter("Password", usuario.Password),
               DataAccess.CreateParameter("IsBlocked", usuario.IsBlocked),
               DataAccess.CreateParameter("Tries", usuario.Tries),
               DataAccess.CreateParameter("Id", usuario.Id)});

            return ret;
        }


    }
}
