using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class seccionBL
    {

        Contexto _contexto;
        public List<seccion> Listadesecciones { get; set; }

        public seccionBL()
        {
            _contexto = new Contexto();
            Listadesecciones = new List<seccion>();
        }
        public List<notas> Obtenernotas()
        {
            Listadesecciones = _contexto.seccion
            .Include("Alumno")
            .ToList();

            return Listadesecciones;

        }
    }
}
