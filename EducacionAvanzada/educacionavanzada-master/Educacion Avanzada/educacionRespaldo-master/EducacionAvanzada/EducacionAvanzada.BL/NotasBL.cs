using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class NotasBL
    {
        Contexto _contexto;
        public List<Notas> ListadeNotas { get; set; }

        public NotasBL()
        {
            _contexto = new Contexto();
            ListadeNotas = new List<Notas>();
        }
        public List<Notas>ObtenerNotas()
        {
            ListadeNotas = _contexto.Notas
            .Include("Alumno")
            .ToList();
            
             return ListadeNotas;

        }
    }
}
