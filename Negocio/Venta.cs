using System;
using System.Collections.Generic;

namespace Negocio
{
    public class Venta
    {
        public Venta() { }

        public Venta(int id, int usuarioId, DateTime fecha, List<Contribucion> contribuciones)
        {
            Id = id;
            UsuarioId = usuarioId;
            Fecha = fecha;
            Contribuciones = contribuciones;
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

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private List<Contribucion> _contribuciones;

        public List<Contribucion> Contribuciones
        {
            get { return _contribuciones; }
            set { _contribuciones = value; }
        }

    }
}
