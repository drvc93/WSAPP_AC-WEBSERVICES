using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSAPP.Clases
{
    public class SocioPregunta
    {

        private string codEncuesta;
        private string orden;
        private string codSocio;
        private string valor;
        private string fechaRegistro;
        private string tipo;
        private string pregunta; 

        public SocioPregunta() { }

        public SocioPregunta(string codEncuesta , string orden , string codSocio , string  valor, string fechaRegistro) {

            this.codEncuesta = codEncuesta;
            this.orden = orden;
            this.codSocio = codSocio;
            this.valor = valor;
            this.fechaRegistro = fechaRegistro;

        }

        public string CodEncuesta
        {
            get
            {
                return codEncuesta;
            }

            set
            {
                codEncuesta = value;
            }
        }

        public string Orden
        {
            get
            {
                return orden;
            }

            set
            {
                orden = value;
            }
        }

        public string CodSocio
        {
            get
            {
                return codSocio;
            }

            set
            {
                codSocio = value;
            }
        }

        public string Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
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
                fechaRegistro = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public string Pregunta
        {
            get
            {
                return pregunta;
            }

            set
            {
                pregunta = value;
            }
        }
    }
}