using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducacionAvanzada.Web.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            var alumnosBL = new AlumnosBL();
            var listaAlumno = alumnosBL.ObtenerAlumnos();

            return View(listaAlumno);
        }
    }
}