using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSAPP.Clases
{
    public class Evento
    {

        private string codEvento;
        private string anio;
        private string mes;
        private string dia;
        private string hora;
        private string descripCorta; 

        public string CodEvento
        {
            get
            {
                return codEvento;
            }

            set
            {
                this.codEvento = value;
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

        public string Dia
        {
            get
            {
                return dia;
            }

            set
            {
                this.dia = value;
            }
        }

        public string Hora
        {
            get
            {
                return hora;
            }

            set
            {
                this.hora = value;
            }
        }

        public string DescripCorta
        {
            get
            {
                return descripCorta;
            }

            set
            {
                this.descripCorta = value;
            }
        }
    }
}