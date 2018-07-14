using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace NegocioService
{
    public class SeguridadService
    {
        public int PerformBackup(string path)
        {
            return SeguridadDAL.Perform(path);
        }
    }
}
