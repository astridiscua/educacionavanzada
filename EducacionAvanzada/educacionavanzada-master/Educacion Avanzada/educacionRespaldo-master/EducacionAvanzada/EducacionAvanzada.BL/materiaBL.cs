using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class materiaBL
    {
        Contexto _contexto;
        public List<materia> Listadematerias { get; set; }

        public materiaBL()
        {
            _contexto = new Contexto();
            Listadematerias = new List<materia>();
        }
        public List<materia> Obtenermateria()
        {
            Listadematerias = _contexto.Materia
            .Include("Alumno")
            .ToList();

            return Listadematerias;

        }
    }
}


    

