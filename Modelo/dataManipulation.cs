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
    public class dataManipulation
    {
        #region Objects

        #endregion

        #region Singleton
        private static dataManipulation _Instance = null;

        public static dataManipulation GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new dataManipulation();
                }
                return _Instance;
            }
        }
        private dataManipulation()
        {
            //nothing
        }
        #endregion


        public int usp_LoginValidation(string Usu, string Pass)
        {
            //dataAcccess dA = new dataAcccess();
            SqlCommand CMD = new SqlCommand();
            dataAccess.GetInstance.Open();
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Parameters.Add(new SqlParameter("@Usu", Usu));
            CMD.Parameters.Add(new SqlParameter("@Pass", Pass));
            CMD.CommandText = "usp_LoginValidation";
            dataAccess.GetInstance.Close();
            return dataAccess.GetInstance.ExecSP(CMD);
        }

        public int usp_BlockUser(string Usu)
        {
            //dataAcccess dA = new Model.dataAcccess();
            SqlCommand CMD = new SqlCommand();
            dataAccess.GetInstance.Open();
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Parameters.Add(new SqlParameter("@usu", Usu));
            CMD.CommandText = "usp_BlockUser";
            dataAccess.GetInstance.Close();
            return dataAccess.GetInstance.ExecSP(CMD);
        }

        public int usp_ResetTries(string Usu)
        {
            //dataAcccess dA = new Model.dataAcccess();
            SqlCommand CMD = new SqlCommand();
            dataAccess.GetInstance.Open();
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Parameters.Add(new SqlParameter("@usu", Usu));
            CMD.CommandText = "usp_ResetTries";
            dataAccess.GetInstance.Close();
            return dataAccess.GetInstance.ExecSP(CMD);
        }

        public int usp_setBitacora(int Bit, string Action, int Priority, string Type, string Class, string Usu, DateTime Date, DateTime Time)
        {
            //dataAcccess dA = new dataAcccess();
            SqlCommand CMD = new SqlCommand();
            dataAccess.GetInstance.Open();
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Parameters.Add(new SqlParameter("@BIT", Bit));
            CMD.Parameters.Add(new SqlParameter("@ACTION", Action));
            CMD.Parameters.Add(new SqlParameter("@PRIORITY", Priority));
            CMD.Parameters.Add(new SqlParameter("@TYPE", Type));
            CMD.Parameters.Add(new SqlParameter("@CLASS", Class));
            CMD.Parameters.Add(new SqlParameter("@USER", Usu));
            CMD.Parameters.Add(new SqlParameter("@DATE", Date));
            CMD.Parameters.Add(new SqlParameter("@TIME", Time));
            CMD.CommandText = "usp_setBitacora";
            dataAccess.GetInstance.Close();
            return dataAccess.GetInstance.ExecSP(CMD);
        }


    }
}
