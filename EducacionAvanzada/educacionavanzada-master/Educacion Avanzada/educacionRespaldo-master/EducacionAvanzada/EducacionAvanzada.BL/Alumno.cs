using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class Alumno
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre")]
        [MinLength(3, ErrorMessage = "Ingrese mínimo 3 caracteres")]
        [MaxLength(40, ErrorMessage = "Ingrese máximo 40 caracteres")]
        public string Nombre { get; set; }

        public int GradoId { get; set; }
        public Grado Grado { get; set; }
        public int JornadaId { get; set; }
        public Jornada Jornada { get; set; }

        [Required(ErrorMessage = "Ingrese una sección")]
        public string Seccion { get; set; }

        [Display (Name= "Imagen")]
        public string UrlImagen { get; set; }

    }
}
