using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class seccion
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

}