using System;
using System.Data;
using System.Data.SqlClient;
using Negocio;

namespace Modelo
{
    public class ContribucionDAL
    {
        public static int SaveOrUpdate(Contribucion contribucion)
        {

            int ret = DataAccess.Instance.Write("Contribucion_InsertOrUpdate", 
                                                CommandType.StoredProcedure, 
                                                new SqlParameter[]
                                                {
                                                    DataAccess.CreateParameter("IdVenta", contribucion.IdVenta),
                                                    //Inicio Modificación - FernandoAMartinez
                                                    //DataAccess.CreateParameter("IdProy", Convert.ToInt32(contribucion.IdProy)),
                                                    DataAccess.CreateParameter("IdProy", Convert.ToInt32(contribucion.Proyecto.Id)),
                                                    //Fin Modificación - FernandoAMartinez
                                                    DataAccess.CreateParameter("Cantidad", contribucion.Cantidad),
                                                    DataAccess.CreateParameter("Importe", contribucion.Importe)
                                                });
            return ret;
        }

        public static Contribucion GetById(int Id)
        {
            Contribucion contribucion = null;
            DataTable table = DataAccess.Instance.Read("Contribucion_Select",
                                                        CommandType.StoredProcedure,
                                                        new SqlParameter[]
                                                        {
                                                            DataAccess.CreateParameter("Id", Id)
                                                        });

            if (table.Rows.Count == 1)
                contribucion = ConvertRow(table.Rows[0]);

            return contribucion;
        }

        private static Contribucion ConvertRow(DataRow row)
        {
            Contribucion contribucion = null;
            if (row != null)
            {
                contribucion = new Contribucion();
                contribucion.IdVenta = Int32.Parse(row[0].ToString());
                //Inicio Modificación - FernandoAMartinez
                //contribucion.IdProy = Int32.Parse(row[1].ToString());
                contribucion.Proyecto = ProyectoDAL.GetById(Int32.Parse(row[1].ToString()));
                //Fin Modificación - FernandoAMartinez
                contribucion.Cantidad = Int32.Parse(row[2].ToString());
                contribucion.Importe = Int32.Parse(row[3].ToString());
            }
            return contribucion;
        }
    }
}
