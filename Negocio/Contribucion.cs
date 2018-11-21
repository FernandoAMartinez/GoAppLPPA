using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public  class Contribucion
    {
        public Contribucion() { }

        public Contribucion(int idVenta, Proyecto proy, int cantidad, int importe)
        {
            IdVenta = idVenta;
            //IdProy = idProy;
            Proyecto = proy;
            Cantidad = cantidad;
            Importe = importe;
        }

        private int _idVenta;

        public int IdVenta
        {
            get { return _idVenta; }
            set { _idVenta = value; }
        }

        //Inicio Modificación - FernandoAMartinez
        //private int _idProy;

        //public int IdProy
        //{
        //    get { return _idProy; }
        //    set { _idProy = value; }
        //}
        private Proyecto _proyecto;

        public Proyecto Proyecto
        {
            get { return _proyecto; }
            set { _proyecto = value; }
        }

        //Fin Modificación - FernandoAMartinez

        private int _cantidad;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private int _importe;

        public int Importe
        {
            get { return _importe; }
            set { _importe = value; }
        }



    }
}
