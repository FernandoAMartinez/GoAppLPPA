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

        public static _dataAccess GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new Modelo._dataAccess();
            }
            return _Instance;
        }

        private _dataAccess()
        {
            //nothing
        }

        

        #endregion

        #region Methods

        #endregion
    }
}
