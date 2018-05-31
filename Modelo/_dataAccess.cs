using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Modelo
{
    public class _dataAccess
    {
        #region Objects
        SqlConnection CN = new SqlConnection();
        SqlCommand CMD = new SqlCommand();
        SqlDataAdapter DA = new SqlDataAdapter();
        #endregion

        #region Singleton
        private static _dataAccess _Instance = null;

        public static _dataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Modelo._dataAccess();
                }
                return _Instance;
            }
        }
        private _dataAccess()
        {
            //nothing
        }



        #endregion

        #region Methods
        public void Open()
        {
            try
            {
                CN.Open();
            }
            catch
            {
                throw;
            }
        }

        public void Close()
        {
            try
            {
                CN.Close();
                GC.Collect();
            }
            catch
            {
                throw;
            }
        }

        public int ExecSP(SqlCommand CMD)
        {
            int n;
            Open();
            CMD.Connection = CN;
            CMD.CommandType = CommandType.StoredProcedure;
            n = CMD.ExecuteNonQuery();
            Close();
            return n;
        }
        #endregion
    }
}
