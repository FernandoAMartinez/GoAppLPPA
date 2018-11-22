using Negocio;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public static class TarjetaDAL
    {
        public static Tarjeta GetCard(int Id)
        {
            Tarjeta tarjeta = null;
            DataTable table = DataAccess.Instance.Read("Tarjeta_Select", 
                                                        CommandType.StoredProcedure, 
                                                        new SqlParameter[]
                                                        {
                                                           DataAccess.CreateParameter("Id", Id)
                                                        });

            if (table.Rows.Count == 1)
                tarjeta = Convert(table.Rows[0]);

            return tarjeta;
        }


        private static Tarjeta Convert(DataRow row)
        {
            Tarjeta tarjeta = null;
            if (row != null)
            {
                tarjeta = new Tarjeta();
                tarjeta.Id = Int32.Parse(row[0].ToString());
                tarjeta.UsuarioId = Int32.Parse(row[1].ToString());
                tarjeta.CardNumber = row[2].ToString();
                tarjeta.Desde = row[3].ToString();
                tarjeta.Hasta = row[4].ToString();
                tarjeta.CCV = row[5].ToString();
            }
            return tarjeta;
        }

    }
}
