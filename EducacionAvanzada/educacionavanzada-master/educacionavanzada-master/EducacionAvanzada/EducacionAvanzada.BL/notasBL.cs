using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    class notasBL
    {

        Contexto _contexto;
        public List<notas> Listadenotas { get; set; }

        public notasBL()
        {
            _contexto = new Contexto();
            Listadenotas = new List<notas>();
        }
        public List<notas> Obtenernotas()
        {
            Listadenotas = _contexto.notas
            .Include("Alumno")
            .ToList();

            return Listadenotas;

        }

    }
}
