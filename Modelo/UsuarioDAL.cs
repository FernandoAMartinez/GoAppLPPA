using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
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


        public static Usuario GetByLogin(string UserName, string Password)
        {
            Usuario usuario = null;
            DataTable table = DataAccess.Instance.Read("Usuario_Select", new SqlParameter[]{
               DataAccess.CreateParameter("UserName", UserName),
               DataAccess.CreateParameter("Password", Password)});

            if (table.Rows.Count == 1)
                usuario = Convert(table.Rows[0]);

            return usuario;
        }


        private static Usuario Convert(DataRow row)
        {
            Usuario usuario = null;
            if (row != null) {
                usuario.Id = Int32.Parse(row[0].ToString());
                usuario.UserName = row[1].ToString();
                usuario.Password = row[2].ToString();
                usuario.IsBlocked = Boolean.Parse(row[3].ToString());
                usuario.Tries = Int32.Parse(row[0].ToString());
            }
            return usuario;
        }
    }
}
