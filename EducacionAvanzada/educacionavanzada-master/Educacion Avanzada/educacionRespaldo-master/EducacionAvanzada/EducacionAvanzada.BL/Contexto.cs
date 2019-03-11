using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EducacionAvanzada.BL
{
    public class Contexto: DbContext
    {
        public Contexto() : base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=" +
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\EducacionAvanzadaDB.mdf")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<materia> Materia { get; set; }
        public DbSet<seccion> Seccion { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<NotasDetalle> NotasDetalle { get; set; }
    }
    

}
