using System;
using System.Data;
using System.Data.SqlClient;
using Negocio;

namespace Modelo
{
    public class VentaDAL
    {
        public static int SaveOrUpdate(Venta venta)
        {

            int ret = DataAccess.Instance.Write("Venta_InsertOrUpdate",
                                                CommandType.StoredProcedure,
                                                new SqlParameter[]
                                                {
                                                    //Inicio Modificación - FernandoAMartinez
                                                    //DataAccess.CreateParameter("Id", venta.Id),
                                                    //Fin Modificación - FernandoAMartinez
                                                    DataAccess.CreateParameter("UsuarioId", Convert.ToInt32(venta.UsuarioId)),
                                                    DataAccess.CreateParameter("Fecha", venta.Fecha)
                                                });
            if(ret == 1)
            {
                foreach (Contribucion contribuciones in venta.Contribuciones)
                {

                    ret = DataAccess.Instance.Write("Contribucion_InsertOrUpdate",
                                                    CommandType.StoredProcedure,
                                                    new SqlParameter[] 
                                                    {
                                                        DataAccess.CreateParameter("IdVenta", venta.Id),
                                                        //Inicio Modificación - FernandoAMartinez
                                                        //DataAccess.CreateParameter("IdProy", contribuciones.IdProy),
                                                        DataAccess.CreateParameter("IdProy", contribuciones.Proyecto.Id),
                                                        //Fin Modificación - FernandoAMartinez                                                        
                                                        DataAccess.CreateParameter("Cantidad", contribuciones.Cantidad),
                                                        DataAccess.CreateParameter("Importe", contribuciones.Importe)
                                                    });
                }
            }
            return ret;
        }

        //Inicio Modificación - FernandoAMartinez
        public static int GetNextId(string tabla)
        {
            int ret = 0;
            DataTable table = DataAccess.Instance.Read("Select_NextId",
                                                        CommandType.StoredProcedure,
                                                        new SqlParameter[]
                                                        {
                                                            DataAccess.CreateParameter("Tabla", tabla)
                                                        });
            if (table.Rows.Count == 1)
                if (table.Rows[0][0].ToString() == "")
                    ret = 1;
                else
                    ret = (int)table.Rows[0][0] + 1;

            return ret;
        }
        //Fin Modificación - FernandoAMartinez

        public static Venta GetById(int Id)
        {
            Venta venta = null;
            DataTable table = DataAccess.Instance.Read("Venta_Select",
                                                        CommandType.StoredProcedure,
                                                        new SqlParameter[]
                                                        {
                                                            DataAccess.CreateParameter("Id", Id)
                                                        });

            if (table.Rows.Count == 1)
                venta = ConvertRow(table.Rows[0]);

            return venta;
        }

        private static Venta ConvertRow(DataRow row)
        {
            Venta venta = null;
            if (row != null)
            {
                venta = new Venta();
                venta.Id = Int32.Parse(row[0].ToString());
                venta.Fecha = DateTime.Parse(row[1].ToString());
                venta.UsuarioId = Int32.Parse(row[2].ToString());
            }
            return venta;
        }
    }
}
