using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSAPP.Clases
{
    public class Banco
    {

        private string codBanco;
        private string nombreLargo;
        private string nombreCorto;
        private string nroCuenta;

        public Banco() { }

        public Banco(string Codbanco, string NombreL, string NombreC, string NroCuenta) {

            this.codBanco = CodBanco;
            this.nombreLargo = NombreL;
            this.nombreCorto = NombreC;
            this.nroCuenta = NroCuenta;
        }
        public string CodBanco
        {
            get
            {
                return codBanco;
            }

            set
            {
                this.codBanco = value;
            }
        }

        public string NombreLargo
        {
            get
            {
                return nombreLargo;
            }

            set
            {
                this.nombreLargo = value;
            }
        }

        public string NombreCorto
        {
            get
            {
                return nombreCorto;
            }

            set
            {
                this.nombreCorto = value;
            }
        }

        public string NroCuenta
        {
            get
            {
                return nroCuenta;
            }

            set
            {
                this.nroCuenta = value;
            }
        }
    }
}