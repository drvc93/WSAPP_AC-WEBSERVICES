using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSAPP.Clases
{
    public class DetalleSaldo
    {

        private string codConcepto ;
        private string mes;
        private string anio;
        private string estado;
        private string monto;

        public string CodConcepto
        {
            get
            {
                return codConcepto;
            }

            set
            {
                this.codConcepto = value;
            }
        }

        public string Mes
        {
            get
            {
                return mes;
            }

            set
            {
                this.mes = value;
            }
        }

        public string Anio
        {
            get
            {
                return anio;
            }

            set
            {
                this.anio = value;
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

        public DetalleSaldo() { }

        public DetalleSaldo (string CodConcepto , string Mes , string Anio,string Estado, string Monto) {


            this.CodConcepto = CodConcepto;
            this.Mes = Mes;
            this.Anio = Anio;
            this.Estado = Estado;
            this.Monto = Monto;


        }

    }
}