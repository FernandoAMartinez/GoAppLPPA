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
        public static int SaveOrUpdate(Proyecto proyecto)
        {

            int ret = DataAccess.Instance.Write("Proyecto_InsertOrUpdate", CommandType.StoredProcedure, new SqlParameter[]{
               DataAccess.CreateParameter("Nombre", proyecto.Nombre),
               DataAccess.CreateParameter("MetaRecaud", proyecto.MetaRecaud),
               DataAccess.CreateParameter("FechaInicio", proyecto.FechaInicio),
               DataAccess.CreateParameter("FechaFin", proyecto.FechaFin),
               DataAccess.CreateParameter("DVH", SeguridadDAL.GetDV(proyecto.Nombre + proyecto))});

            return ret;
        }

        //Inicio Modificación - FernandoAMartinez - 12.11.2018
        public static DataTable ConsultaProyectos()
        {
            return DataAccess.Instance.Read("Proyecto_Consulta",
                                                    CommandType.StoredProcedure,
                                                    null);
        }
        //Fin Modificación - FernandoAMartinez - 12.11.2018

        //Inicio Modificación - FernandoAMartinez - 13.11.218
        public static int Proyecto_InsertOrUpdate(Proyecto proyecto)
        {
            int ret = DataAccess.Instance.Write("Proyecto_InsertOrUpdate",
                                                CommandType.StoredProcedure,
                                                new SqlParameter[]
                                                {
                                                    DataAccess.CreateParameter("Nombre", proyecto.Nombre),
                                                    DataAccess.CreateParameter("Meta", proyecto.MetaRecaud),
                                                    DataAccess.CreateParameter("FechaInicio", proyecto.FechaInicio),
                                                    DataAccess.CreateParameter("FechaFin", proyecto.FechaFin)
                                                });
            return ret;
        }
        //Fin Modificación - FernandoAMartinez - 13.11.2018

       public static Proyecto GetById(int Id)
       {
            Proyecto proyecto = null;
            DataTable table = DataAccess.Instance.Read("Proyecto_Select", 
                                                        CommandType.StoredProcedure, 
                                                        new SqlParameter[]
                                                        {
                                                            DataAccess.CreateParameter("Id", Id)
                                                        });

            if (table.Rows.Count == 1)
                proyecto = ConvertRow(table.Rows[0]);

            return proyecto;
        }

        private static Proyecto ConvertRow(DataRow row)
        {
            Proyecto proyecto = null;
            if (row != null)
            {
                proyecto = new Proyecto();
                proyecto.Id = Int32.Parse(row[0].ToString());
                proyecto.Nombre = row[1].ToString();
                proyecto.MetaRecaud = Convert.ToDouble(row[2]);
                proyecto.FechaInicio = (DateTime)row[3];
                proyecto.FechaFin = (DateTime)row[4];
            }
            return proyecto;
        }


    }
}
