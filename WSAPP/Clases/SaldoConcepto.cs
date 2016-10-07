using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSAPP.Clases
{
    public class SaldoConcepto
    {

        private string codConcepto;
        private string saldoxConcepto;
        private string pagadoxConceto;

        public SaldoConcepto() { }

        public SaldoConcepto(string Cod , string saldo , string pago)
        {

            this.codConcepto = Cod;
            this.saldoxConcepto = saldo;
            this.pagadoxConceto = pago;
        }
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

        public string SaldoxConcepto
        {
            get
            {
                return saldoxConcepto;
            }

            set
            {
                this.saldoxConcepto = value;
            }
        }

        public string PagadoxConceto
        {
            get
            {
                return pagadoxConceto;
            }

            set
            {
                this.pagadoxConceto = value;
            }
        }
    }
}