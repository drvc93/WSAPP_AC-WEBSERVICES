using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSAPP.Clases
{
    public class Seccion 
    {

        private string codigo;
        private string descripcion;
        private string fecha;


        public Seccion( string Codigo , string Descripcion , string Fecha) {

            this.codigo = Codigo;
            this.descripcion = Descripcion;
            this.fecha = Fecha;
        }
        public Seccion() { }

        public string Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                this.codigo = value;
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

        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                this.fecha = value;
            }
        }
    }
}