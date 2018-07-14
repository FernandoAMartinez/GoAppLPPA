using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public static class SeguridadDAL
    {
        public static int Perform(string path)
        {
            int ret = 0;
            //path = path.Replace("\\", "/");
            //path = path.Replace('"', "");
            ret = DataAccess.Instance.Perform("New_Backup", CommandType.StoredProcedure, new SqlParameter[]{
                DataAccess.CreateParameter("filepath", @path) });

            return ret;
        }
    }
}
