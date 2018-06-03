using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Modelo
{
    public class dataAccess
    {
        #region Objects
        SqlConnection CN = new SqlConnection(ConfigurationManager.ConnectionStrings["TEST"].ConnectionString);
        SqlCommand CMD = new SqlCommand();
        SqlDataAdapter DA = new SqlDataAdapter();
        #endregion

        #region Singleton
        private static dataAccess _Instance = null;

        public static dataAccess GetInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Modelo.dataAccess();
                }
                return _Instance;
            }
        }
        private dataAccess()
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

        public int ExeNonQuery(string query)
        {
            int n;
            Open();
            CMD.Connection = CN;
            CMD.CommandType = CommandType.Text;
            CMD.CommandText = query;
            n = CMD.ExecuteNonQuery();
            Close();
            return n;
        }

        public int ExeScalarInt(string query)
        {
            int n;
            object obj;
            Open();
            CMD.Connection = CN;
            CMD.CommandType = CommandType.Text;
            CMD.CommandText = query;
            obj = CMD.ExecuteScalar();
            Close();
            n = Convert.ToInt32(obj);
            return n;
        }

        public string ExeScalarString(string query)
        {
            string n;
            object obj;
            Open();
            CMD.Connection = CN;
            CMD.CommandType = CommandType.Text;
            CMD.CommandText = query;
            obj = CMD.ExecuteScalar();
            Close();
            n = obj.ToString();
            return n;
        }

        public DataSet ExecDS(string query)
        {
            Open();
            SqlDataAdapter DA = new SqlDataAdapter(query, CN);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DS.Dispose();
            Close();
            return DS;
        }

        SqlDataReader DR;

        public string ExecDR(string query)
        {
            string res = "";
            Open();
            CMD.Connection = CN;
            CMD.CommandType = CommandType.Text;
            CMD.CommandText = query;
            DR = CMD.ExecuteReader();
            while (DR.Read() == true)
            {
                //res = DR.ToString();
                res = DR.GetString(0);
            }
            Close();
            return res;
        }
        #endregion
    }
}
