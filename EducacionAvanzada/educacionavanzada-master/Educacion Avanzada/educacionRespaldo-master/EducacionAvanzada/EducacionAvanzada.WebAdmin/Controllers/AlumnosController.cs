using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducacionAvanzada.WebAdmin.Controllers
{
    public class AlumnosController : Controller
    {
        AlumnosBL _alumnosBL;
        GradosBL _gradosBL;
        JornadasBL _jornadasBL;

        public AlumnosController()
        {
            _alumnosBL = new AlumnosBL();
            _gradosBL = new GradosBL();
            _jornadasBL = new JornadasBL();
        }

        // GET: Alumnos
        public ActionResult Index()
        {
            var listadeAlumnos = _alumnosBL.ObtenerAlumnos();

            return View(listadeAlumnos);
        }

        public ActionResult Crear()
        {
            var nuevoAlumno = new Alumno();
            var grados = _gradosBL.ObtenerGrados();
            var jornadas = _jornadasBL.ObtenerJornadas();

            ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
            ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");

            return View(nuevoAlumno);
        }

        [HttpPost]
        public ActionResult Crear(Alumno alumno, HttpPostedFileBase imagen)
        {
            var grados = _gradosBL.ObtenerGrados();
            var jornadas = _jornadasBL.ObtenerJornadas();

            if (ModelState.IsValid)
            {
                if (alumno.Nombre != alumno.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio o al final");
                    bolsaDeVista();
                    return View(alumno);
                }

                if (alumno.GradoId == 0 || alumno.JornadaId == 0)
                {
                    if (alumno.GradoId == 0)
                    {
                        ModelState.AddModelError("Grado", "Seleccione un grado");
                    }

                    if (alumno.JornadaId == 0)
                    {
                        ModelState.AddModelError("Jornada", "Seleccione una Jornada");
                    }

                    bolsaDeVista();
                    ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
                    ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");

                    return View(alumno);
                }

                if (imagen != null)
                {
                    alumno.UrlImagen = GuardarImagen(imagen);
                }

                _alumnosBL.GuardarAlumno(alumno);

                return RedirectToAction("Index");
            }

           ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
            ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");
            bolsaDeVista();
            return View(alumno);
        }

        public void bolsaDeVista()
        {
            var grados = _gradosBL.ObtenerGrados();
            var jornadas = _jornadasBL.ObtenerJornadas();

            ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion");
            ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion");
        }

        public ActionResult Editar(int id)
        {
            var alumno = _alumnosBL.ObtenerAlumno(id);
            var grados = _gradosBL.ObtenerGrados();
            var jornadas = _jornadasBL.ObtenerJornadas();

            ViewBag.GradoId = new SelectList(grados, "Id", "Descripcion", alumno.GradoId);
            ViewBag.JornadaId = new SelectList(jornadas, "Id", "Descripcion", alumno.JornadaId);

            return View(alumno);
        }

        [HttpPost]
        public ActionResult Editar(Alumno alumno)
        {

            if (ModelState.IsValid)
            {
                if (alumno.Nombre != alumno.Nombre.Trim())
                {
                    ModelState.AddModelError("Nombre", "No debe haber espacios al inicio o al final");
                    bolsaDeVista();
                    return View(alumno);
                }

                if (alumno.GradoId == 0 || alumno.JornadaId == 0)
                {
                    if (alumno.GradoId == 0)
                    {
                        ModelState.AddModelError("Grado", "Seleccione un grado");
                    }

                    if (alumno.JornadaId == 0)
                    {
                        ModelState.AddModelError("Jornada", "Seleccione una Jornada");
                    }

                    bolsaDeVista();

                    return View(alumno);
                }

                _alumnosBL.GuardarAlumno(alumno);

                return RedirectToAction("Index");
            }

            bolsaDeVista();
            return View(alumno);
        }

        public ActionResult Detalle(int id)
        {
            var alumno = _alumnosBL.ObtenerAlumno(id);

            return View(alumno);
        }

        public ActionResult Eliminar(int id)
        {
            var alumno = _alumnosBL.ObtenerAlumno(id);

            return View(alumno);
        }

        [HttpPost]
        public ActionResult Eliminar(Alumno alumno)
        {
            _alumnosBL.EliminarAlumno(alumno.Id);
            return RedirectToAction("Index");
        }

        public string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }
    }
}