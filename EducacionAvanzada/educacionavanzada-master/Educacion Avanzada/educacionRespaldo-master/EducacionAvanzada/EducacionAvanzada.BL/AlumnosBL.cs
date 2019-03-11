﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
    public class AlumnosBL
    {
        Contexto _contexto;

        public List<Alumno> ListadeAlumnos { get; set; }

        public AlumnosBL()
        {
            _contexto = new Contexto();
            ListadeAlumnos = new List<Alumno>();
        }

        public List<Alumno> ObtenerAlumnos()
        {
            ListadeAlumnos = _contexto.Alumnos
                .Include("Grado")
                .Include("Jornada")
                .ToList();

            return ListadeAlumnos;
        }

        public void GuardarAlumno(Alumno alumno)
        {
            if (alumno.Id == 0)
            {
                _contexto.Alumnos.Add(alumno);
            }
            else
            {
                var alumnoExistente = _contexto.Alumnos.Find(alumno.Id);
                alumnoExistente.Nombre = alumno.Nombre;
                alumnoExistente.GradoId = alumno.GradoId;
                alumnoExistente.JornadaId = alumno.JornadaId;
                alumnoExistente.Seccion = alumno.Seccion;
                alumnoExistente.UrlImagen = alumno.UrlImagen;
            }

            _contexto.SaveChanges();
        }

        public Alumno ObtenerAlumno(int id)
        {
            //var alumno = _contexto.Alumnos.Find(id);

            var alumno = _contexto.Alumnos
                .Include("Grado")
                .Include("Jornada")
                .FirstOrDefault(p => p.Id == id);

            return alumno;
        }

        public void EliminarAlumno(int id)
        {
            var alumno = _contexto.Alumnos.Find(id);
            
            _contexto.Alumnos.Remove(alumno);
            _contexto.SaveChanges();
        }
    }
}
