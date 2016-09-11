using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSAPP
{
    public class Socio
    {
        private int codSocio;
        private string dni;
        private string nombres;
        private string apellidoPat;
        private string apellidoMat;
        private string puesto;
        private string celular;
        private string fechaRegistro;
        private string tipoUsuario;

        public Socio (int codSoc , string Dni , string Nombres , string apellidopat , string apellidomat , string Puesto , string Celular , string FechaReg , string TipoUser)
        {

            this.codSocio = codSoc;
            this.dni = Dni;
            this.nombres = Nombres;
            this.apellidoPat = apellidopat;
            this.apellidoMat = apellidomat;
            this.puesto = Puesto;
            this.celular = Celular;
            this.fechaRegistro = FechaReg;
            this.tipoUsuario = TipoUser;

        }

        public Socio() { }

        public int CodSocio
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

        public string Dni
        {
            get
            {
                return dni;
            }

            set
            {
                this.dni = value;
            }
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

        public string ApellidoPat
        {
            get
            {
                return apellidoPat;
            }

            set
            {
                this.apellidoPat = value;
            }
        }

        public string ApellidoMat
        {
            get
            {
                return apellidoMat;
            }

            set
            {
                this.apellidoMat = value;
            }
        }

        public string Puesto
        {
            get
            {
                return puesto;
            }

            set
            {
                this.puesto = value;
            }
        }

        public string Celular
        {
            get
            {
                return celular;
            }

            set
            {
                this.celular = value;
            }
        }

        public string FechaRegistro
        {
            get
            {
                return fechaRegistro;
            }

            set
            {
                this.fechaRegistro = value;
            }
        }

        public string TipoUsuario
        {
            get
            {
                return tipoUsuario;
            }

            set
            {
                this.tipoUsuario = value;
            }
        }
    }
}