using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSAPP.Clases
{
    public class ConceptoPago
    {

        private string codConcepto;
        private string descripcion;
        private string monto;
        private string userReg;
        private string fechaReg;

        public ConceptoPago() { }

        public ConceptoPago(string CodConcepto , string Descripcion , string Monto , string UserReg,string FechaReg) {

            this.codConcepto = CodConcepto;
            this.descripcion = Descripcion;
            this.monto = Monto;
            this.userReg = UserReg;
            this.fechaReg = FechaReg;
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

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                this.descripcion = value;
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

        public string UserReg
        {
            get
            {
                return userReg;
            }

            set
            {
                this.userReg = value;
            }
        }

        public string FechaReg
        {
            get
            {
                return fechaReg;
            }

            set
            {
                this.fechaReg = value;
            }
        }
    }
}