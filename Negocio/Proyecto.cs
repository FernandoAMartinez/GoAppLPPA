using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class Proyecto
    {
        #region Constructors
        public Proyecto() { }

        public Proyecto(string desc, string importe, string fecini)
        {
            _descripcion = desc;
            _importe = importe;
            _fechainicio = fecini;
        }
        #endregion


        #region Properties
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _decripcion;
        public string Descripcion
        {
            get { return _decripcion;}
            set { _decripcion = value;}
        }

        private string _importe;
        public string Importe
        {
            get { return _importe; }
            set { _importe = value; }
        }
        
        private string _fechainicio
        public string Fechainicio
        {
            get { return _fechainicio; }
            set { _fechainicio = value; }
        }
  

        #endregion
    }
}
