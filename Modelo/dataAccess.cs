using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Modelo
{
    public class DataAccess
    {
        private SqlConnection cnn;
        private SqlTransaction tx;

        private static DataAccess instance;

        private DataAccess()
        {
        }

        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccess();
                }
                return instance;
            }
        }

        #region Method Connection

        private void Open()
        {
            try
            {
                cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["GoAppDB"].ConnectionString);
                cnn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Close()
        {
            try
            {
                cnn.Close();
                cnn = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Method Access

        public DataTable Read(string store, CommandType type, SqlParameter[] param = null)
        { // Parte 6 - Login a- Llamada al StoredProcedure
            DataTable tabla = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            Open();
            adapter.SelectCommand = new SqlCommand();
            adapter.SelectCommand.CommandText = store;
            adapter.SelectCommand.CommandType = type;
            if (param != null)
            {
                adapter.SelectCommand.Parameters.AddRange(param);
            }
            adapter.SelectCommand.Connection = cnn;
            adapter.Fill(tabla);
            Close();
            return tabla;
        }

        public int Write(string store, CommandType type, SqlParameter[] param)
        {
            int retorno;
            SqlCommand command = new SqlCommand();
            Open();
            command.CommandText = store;
            command.CommandType = type;
            command.Connection = cnn;
            command.Parameters.AddRange(param);
            tx = cnn.BeginTransaction();
            command.Transaction = tx;
            try
            {
                retorno = command.ExecuteNonQuery();
                tx.Commit();
                return retorno;
            }
            catch (Exception ex)
            {
                retorno = -1;
                tx.Rollback();
                return retorno;
            }
            finally
            {
                Close();
            }

        }

        #endregion

        #region Create Parameter
        public static SqlParameter CreateParameter(string name, string value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.NVarChar;
            return param;
        }

        public static SqlParameter CreateParameter(string name, int value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.Int;
            return param;
        }

        public static SqlParameter CreateParameter(string name, long value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.Int;
            return param;
        }

        public static SqlParameter CreateParameter(string name, bool value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.Bit;
            return param;
        }

        public static SqlParameter CreateParameter(string name, DateTime value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.Date;
            return param;
        }

        public static SqlParameter CreateParameter(string name, Double value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.Decimal;
            return param;
        }

        public static SqlParameter CreateParameter(string name, Decimal value)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.SqlDbType = SqlDbType.Decimal;
            return param;
        }

        public static SqlParameter CreateParameter(string name)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.SqlDbType = SqlDbType.BigInt;
            param.SqlValue = DBNull.Value;
            return param;
        }
        #endregion

        #region Bacup & Restore

        public int PerformRestore(string store, CommandType type, SqlParameter[] param = null)
        {
            int retorno;
            SqlCommand command = new SqlCommand();
            cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString);
            cnn.Open();
            //Open();
            command.CommandText = store;
            command.CommandType = type;
            command.Connection = cnn;
            command.Parameters.AddRange(param);
            try
            {
                retorno = command.ExecuteNonQuery();
                return retorno;
            }
            catch (SqlException ex)
            {
                retorno = -1;
                return retorno;
            }
            finally
            {
                Close();
            }
        }

        public int PerformBackup(string store, CommandType type, SqlParameter[] param = null)
        {
            int retorno;
            SqlCommand command = new SqlCommand();
            Open();
            command.CommandText = store;
            command.CommandType = type;
            command.Connection = cnn;
            command.Parameters.AddRange(param);
            try
            {
                retorno = command.ExecuteNonQuery();
                return retorno;
            }
            catch (SqlException ex)
            {
                retorno = -1;
                return retorno;
            }
            finally
            {
                Close();
            }
        }

        #endregion

    }
}
