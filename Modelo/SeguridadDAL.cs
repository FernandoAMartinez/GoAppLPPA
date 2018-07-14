using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
                return -1; 
            }
        }
    }
}
