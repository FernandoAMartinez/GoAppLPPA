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
            ret = DataAccess.Instance.Write("Bitacora_Insert", 
                                            CommandType.StoredProcedure,
                                            new SqlParameter[]{DataAccess.CreateParameter("Accion", bitacora.Accion),
                                                               DataAccess.CreateParameter("Descripcion", bitacora.Descripcion),
                                                               DataAccess.CreateParameter("Fecha", bitacora.Fecha),
                                                               DataAccess.CreateParameter("Usuario_Id", bitacora.Usuario.Id),
                                                               DataAccess.CreateParameter("DVH", bitacora.GetDV(Convert.ToString(GetNextId("Bitacora")) +
                                                                                                                Convert.ToString(bitacora.Accion) +
                                                                                                                Convert.ToString(bitacora.Descripcion) +
                                                                                                                Convert.ToString(bitacora.Fecha) +
                                                                                                                Convert.ToString(bitacora.Usuario.Id)))
                                                                   });

            return ret;
        }

        //Inicio Modificación - FernandoAMartinez - 05.11.2018
        public static int GetNextId(string tabla)
        {
            int ret = 0;
            DataTable table =  DataAccess.Instance.Read("Select_NextId",
                                                        CommandType.StoredProcedure,
                                                        new SqlParameter[] { DataAccess.CreateParameter("Tabla", tabla) });

            if (table.Rows.Count == 1)
                if (table.Rows[0][0].ToString() == "")
                    ret = 1;
                else
                    ret = (int)table.Rows[0][0] + 1;

            return ret;
        }
        //Fin Modificación - FernandoAMartinez - 05.11.2018

        public static List<Bitacora> GetAll()
        {
            List<Bitacora> bitacoras = new List<Bitacora>();
            DataTable table = DataAccess.Instance.Read("Bitacora_Select", CommandType.StoredProcedure);
            foreach (DataRow row in table.Rows) {
                bitacoras.Add(ConvertRow(row));
            }

            return bitacoras;
        }

        private static Bitacora ConvertRow(DataRow row)
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
