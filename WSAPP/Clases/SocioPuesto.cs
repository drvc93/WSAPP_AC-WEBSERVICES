using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSAPP.Clases
{
    public class SocioPuesto
    {
        private string codSocio;
        private string nroPuesto;
        private string estado;
        private string fechaReg;
        private string userReg;
        private string codSeccion;
     
        public SocioPuesto() { }
        
        public SocioPuesto (string CodSocio , string NroPuesto , string Estado , string FechaReg ,string UserReg, string CodSeccion)
        {

            this.CodSocio = CodSocio;
            this.NroPuesto = NroPuesto;
            this.Estado = Estado;
            this.FechaReg = FechaReg;
            this.UserReg =UserReg;
            this.CodSeccion =  CodSeccion;
        }

        public string CodSocio
        {
            get
            {
                return codSocio;
            }

            set
            {
                this.codSocio = value;
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

        public string CodSeccion
        {
            get
            {
                return codSeccion;
            }

            set
            {
                this.codSeccion = value;
            }
        }
    }
}