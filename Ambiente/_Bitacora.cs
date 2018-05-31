using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Ambiente
{
    public class _Bitacora
    {
        #region Objects

        #endregion

        #region Properties
        private int _iBitacora;

        public int iBitacora
        {
            get { return _iBitacora; }
            set { _iBitacora = value; }
        }

        private int _iCriticidad;

        public int iCriticidad
        {
            get { return _iCriticidad; }
            set { _iCriticidad = value; }
        }

        private string _sClase;

        public string sClase
        {
            get { return _sClase; }
            set { _sClase = value; }
        }

        private string _sUser;

        public string sUser
        {
            get { return _sUser; }
            set { _sUser = value; }
        }

        private string _sDescripcion;

        public string sDescripcion
        {
            get { return _sDescripcion; }
            set { _sDescripcion = value; }
        }

        private DateTime _dtFechaHora;

        public DateTime dtFechaHora
        {
            get { return _dtFechaHora; }
            set { _dtFechaHora = value; }
        }

        #endregion

        #region Methods
        public void AltaBitácora(){
            //INSERT INTO BITACORAS VALUES (ID, CRITICIDAD, CLASE, USUARIO, DESCRIPCIÓN, FECHAHORA)
        }

        #endregion
    }
}
