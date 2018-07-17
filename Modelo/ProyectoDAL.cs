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
    public static class ProyectoDAL
    {
        public static int SaveOrUpdate(Proyecto proyecto) {

            int ret = DataAccess.Instance.Write("Proyecto_SaveOrUpdate", CommandType.StoredProcedure, new SqlParameter[] {
                DataAccess.CreateParameter("Descripcion", Proyecto.desc),
                DataAccess.CreateParameter("Id", proyecto.Id),
                DataAccess.CreateParameter("Importe", proyecto.Importe)
                DataAccess.CreateParameter("FechaInicio")});

            return ret;
        }



    }
}   