using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Tarjeta
    {
        //Id
        //UsuarioId
        //NroTarjeta
        //Desde
        //Hasta
        //CCV
        public Tarjeta() { }

        public Tarjeta(int id, int usuarioId, string cardNumber, string desde, string hasta, string ccv)
        {
            Id = id;
            UsuarioId = usuarioId;
            CardNumber = cardNumber;
            Desde = desde;
            Hasta = hasta;
            CCV = ccv;
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _usuarioId;

        public int UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        private string _cardNumber;

        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        private string _desde;

        public string Desde
        {
            get { return _desde; }
            set { _desde = value; }
        }

        private string _hasta;

        public string Hasta
        {
            get { return _hasta; }
            set { _hasta = value; }
        }

        private string _ccv;

        public string CCV
        {
            get { return _ccv; }
            set { _ccv = value; }
        }




    }
}
