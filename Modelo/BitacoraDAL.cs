using Modelo;
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
    public static class BitacoraDAL
    {
        public static int Insert(Bitacora bitacora)
        {
            int ret = 0;
            ret = DataAccess.Instance.Write("Bitacora_Insert", CommandType.StoredProcedure,new SqlParameter[]{
               DataAccess.CreateParameter("Accion", bitacora.Accion),
            DataAccess.CreateParameter("Descripcion", bitacora.Descripcion),
            DataAccess.CreateParameter("Fecha", bitacora.Fecha),
            DataAccess.CreateParameter("Usuario_Id", bitacora.Usuario.Id)});

            return ret;
        }

        public static List<Bitacora> GetAll()
        {
            List<Bitacora> bitacoras = new List<Bitacora>();
            // Parte 5 - Creacion de parametros 
            DataTable table = DataAccess.Instance.Read("Bitacora_Select", CommandType.StoredProcedure);
            foreach (DataRow row in table.Rows) {
                bitacoras.Add(Convert(row));
            }

            return bitacoras;
        }

        private static Bitacora Convert(DataRow row)
        {
            Bitacora bitacora = null;
            if (row != null)
            {
                bitacora = new Bitacora();
                bitacora.Id = Int32.Parse(row[0].ToString());
                bitacora.Accion = row[1].ToString();
                bitacora.Descripcion = row[2].ToString();
                bitacora.Fecha = DateTime.Parse(row[3].ToString());
                bitacora.Usuario = UsuarioDAL.GetById(Int32.Parse(row[4].ToString()));
            }
            return bitacora;
        }

    }
}
