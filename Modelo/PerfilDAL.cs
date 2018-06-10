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
    public static class PerfilDAL
    {
        public static Perfil GetById(int Id)
        {
            Perfil perfil = null;
            DataTable table = DataAccess.Instance.Read("Perfil_Select", CommandType.StoredProcedure,new SqlParameter[]{
               DataAccess.CreateParameter("Id", Id)});
            if(table.Rows.Count == 1)
                perfil = Convert(table.Rows[0]);

            return perfil;
        }


        private static Perfil Convert(DataRow row)
        {
            Perfil perfil = null;
            if (row != null)
            {
                perfil.Id = Int32.Parse(row[0].ToString());
                perfil.Descripcion = row[1].ToString();
            }
            return perfil;
        }

    }
}
