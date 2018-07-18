using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Modelo
{
    public static class SeguridadDAL
    {
        public static int Perform(int process, string path)
        {
            
            if (process == 0)
            {
                int ret = 0;
                //path = path.Replace("\\", "/");
                //path = path.Replace('"', "");
                ret = DataAccess.Instance.PerformBackup("New_Backup", CommandType.StoredProcedure, new SqlParameter[]{
                DataAccess.CreateParameter("filepath", path) });

                return ret;
            }
            else if(process == 1)
            {
                int ret = 0;
                //path = path.Replace("\\", "/");
                //path = path.Replace('"', "");
                ret = DataAccess.Instance.PerformRestore("New_Restore", CommandType.StoredProcedure, new SqlParameter[]{
                DataAccess.CreateParameter("filepath", path) });

                return ret;
            }
            else
            {
                return 0; 
            }
        }

        public static DataTable TraerTablas()
        {
            DataTable Tablas = new DataTable();
            Tablas = DataAccess.Instance.Read("Digitos_Verticales",
                                                        CommandType.StoredProcedure,
                                                        null);
            return Tablas;
        }

        public static void ValidarDigitos(int pos, out DataTable lista, out DataTable errores)
        {
            errores = null;
            lista = null;
            DataTable Tablas = DataAccess.Instance.Read("Digitos_Verticales",
                                                        CommandType.StoredProcedure,
                                                        null);
            
            //Validar dígitos Verificadores horizontales
            foreach (DataRow tabla in Tablas.Rows)
            {
                lista = new DataTable();    //Se inicializan las tablas internas
                errores = new DataTable();  //Se inicializan las tablas internas

                DataTable interna = DataAccess.Instance.Read("Get_Digitos",
                                                             CommandType.StoredProcedure,
                                                             new SqlParameter[] { DataAccess.CreateParameter("tabla", 
                                                                                                           Tablas.Rows[pos]["Tabla"].ToString()) });

                DataTable pruebaRows = DataAccess.Instance.Read("Get_Columns",
                                                                CommandType.StoredProcedure,
                                                                new SqlParameter[] { DataAccess.CreateParameter("tabla",
                                                                                                                Tablas.Rows[pos]["Tabla"].ToString()) });

                
                foreach (DataColumn col in pruebaRows.Columns)
                {
                    lista.Columns.Add(col.ColumnName);
                    errores.Columns.Add(col.ColumnName);
                }

                for (int i = 0; i < pruebaRows.Rows.Count; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    int prueba = Convert.ToInt32(interna.Rows[i]["DVH"]);

                    for (int j = 0; j < pruebaRows.Columns.Count; j++)
                    {
                        sb.Append(pruebaRows.Rows[i][j]);
                    }
                    int pruebaDV = GetDV(sb.ToString());
                    DataRow Row = pruebaRows.Rows[i];

                    if (Convert.ToInt64(interna.Rows[i]["DVH"]) == GetDV(sb.ToString()))
                        lista.Rows.Add(Row.ItemArray);
                    else
                        errores.Rows.Add(Row.ItemArray);
                }

            }

            DataTable Verticales = DataAccess.Instance.Read("Digitos_Verticales",
                                                            CommandType.StoredProcedure,
                                                            null);


        }

        public static int GetDV(string param)
        {
            int sum = 0;
            byte[] ASCIIValues = Encoding.ASCII.GetBytes(param);

            int pos = 0;
            foreach (byte b in ASCIIValues)
            {
                sum += b * pos;
                pos += 1;
            }
            return sum;
        }
    }
}
