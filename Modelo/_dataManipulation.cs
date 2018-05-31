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
    public class _dataManipulation
    {
        #region Objects

        #endregion

        public int usp_LoginValidation(string Usu, string Pass)
        {
            //dataAcccess dA = new dataAcccess();
            SqlCommand CMD = new SqlCommand();
            _dataAccess.GetInstance.Open();
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Parameters.Add(new SqlParameter("@Usu", Usu));
            CMD.Parameters.Add(new SqlParameter("@Pass", Pass));
            CMD.CommandText = "usp_LoginValidation";
            _dataAccess.GetInstance.Close();
            return _dataAccess.GetInstance.ExecSP(CMD);
        }
    }
}
