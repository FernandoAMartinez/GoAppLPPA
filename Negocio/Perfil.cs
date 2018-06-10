using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class Perfil
    {

        #region Constructors
        public Perfil() { }

        public Perfil(int Id)
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

        #endregion



    }
}
