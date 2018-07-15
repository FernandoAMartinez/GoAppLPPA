using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Bitacora
    {

        #region Constructors
        public Bitacora() { }

        public Bitacora(int Id)
        {

        }
        #endregion

        #region Properties

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _accion;

        public string Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private Usuario _usuario;

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        #endregion

        #region Methods
        public int GetDV(string param)
        {
            int sum = 0;
            byte[] ASCIIValues = Encoding.ASCII.GetBytes(param);

            int pos = 0;
            foreach (byte b in ASCIIValues)
            {
                sum += b * pos;
                pos += 1;
            }
            return sum;
        }
        #endregion

    }
}
