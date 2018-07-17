using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;

namespace NegocioService
{
    public class SeguridadService
    {
        public int PerformBackup(string path)
        {
            return SeguridadDAL.Perform(0, path);
        }

        public int PerformRestore(string path)
        {
            return SeguridadDAL.Perform(1, path);
        }

        public DataTable ValidarDigitos(int pos)
        {
            DataTable tabla, errores = new DataTable();
            SeguridadDAL.ValidarDigitos(pos, out tabla, out errores);

            return errores;
        }

        public DataTable TraerTablas()
        {
            return SeguridadDAL.TraerTablas();
        }
    }
}
