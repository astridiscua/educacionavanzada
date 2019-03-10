using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class materia
    {
        
          
       public int Id { get; set; }

        public int Gradoid { get; set; }
        public Grado Grado { get; set; }

        public int JornadaId { get; set; }
        public Jornada Jornada { get; set; }

        public int SeccionId { get; set; }
        public Jornada Seccion { get; set; }

        public int Anio { get; set; }
    }

    public class MateriaDetalle
    {
        public int Id { get; set; }

        public int NotasId { get; set; }
        public notas notas { get; set; }

        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }

        public int MateriaId { get; set; }
        public materia materia { get; set; }

        public int PrimerParcial { get; set; }
        public int SegundoParcial { get; set; }
        public int TercerParcial { get; set; }
        public int CuartoParcial { get; set; }

        public int NotaFinal { get; set; }
    }
}

