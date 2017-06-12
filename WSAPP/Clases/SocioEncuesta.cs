using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSAPP.Clases
{
    public class SocioEncuesta
    {
        private string codEcnuesta;
        private string descripcion;
        private string fecha;

        public SocioEncuesta() { }

        public SocioEncuesta(string codEncuesta, string descripcion, string fecha) {

            this.CodEcnuesta = codEncuesta;
            this.Descripcion = descripcion;
            this.Fecha = fecha;


        }

        public string CodEcnuesta
        {
            get
            {
                return codEcnuesta;
            }

            set
            {
                codEcnuesta = value;
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
                descripcion = value;
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
                fecha = value;
            }
        }
    }
}