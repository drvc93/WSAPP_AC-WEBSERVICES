using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSAPP.Clases
{
    public class CPagos
    {

        private string nombres;
        private string fechaPago;
        private string seccion;
        private string monto;
        private string banco;
        private string nroPuesto;
        private string estado;

        public CPagos() { }

        public CPagos (string Nombre, string FechaP , string Seccion ,string Monto , string Banco , string NroPuesto ,string Estado)
        {

            this.nombres = Nombre;
            this.fechaPago = FechaP;
            this.seccion = Seccion;
            this.monto = Monto;
            this.banco = Banco;
            this.nroPuesto = NroPuesto;
            this.estado = Estado;

        }

        public string Nombres
        {
            get
            {
                return nombres;
            }

            set
            {
                this.nombres = value;
            }
        }

        public string FechaPago
        {
            get
            {
                return fechaPago;
            }

            set
            {
                this.fechaPago = value;
            }
        }

        public string Seccion
        {
            get
            {
                return seccion;
            }

            set
            {
                this.seccion = value;
            }
        }

        public string Monto
        {
            get
            {
                return monto;
            }

            set
            {
                this.monto = value;
            }
        }

        public string Banco
        {
            get
            {
                return banco;
            }

            set
            {
                this.banco = value;
            }
        }

        public string NroPuesto
        {
            get
            {
                return nroPuesto;
            }

            set
            {
                this.nroPuesto = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                this.estado = value;
            }
        }
    }
}