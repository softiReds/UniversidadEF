using Microsoft.EntityFrameworkCore;
using UniversidadEf.Models;

namespace UniversidadEF.Context;

public class UniversidadContext : DbContext
{
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<AlumnoAsignatura> AlumnoAsignaturas { get; set; }
    public DbSet<Asignatura> Asignaturas { get; set; }
    public DbSet<Carrera> Carreras { get; set; }
    public DbSet<Facultad> Facultades { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Profesor> Profesores { get; set; }
    public DbSet<Rector> Rectores { get; set; }
    public DbSet<Sede> Sedes { get; set; }

    public UniversidadContext(DbContextOptions<UniversidadContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Alumno> alumnosInit = new List<Alumno>();
        alumnosInit.Add(new Alumno() { AlumnoId = Guid.Parse("5131973e-a517-4c5a-91d5-d2be6d4bac32"), AlumnoDocumento = 1921874154 });

        modelBuilder.Entity<Alumno>(alumno =>
        {
            alumno.ToTable("Alumno");

            alumno.HasKey(e => e.AlumnoId);

            alumno.HasOne(e => e.Persona).WithOne(e => e.Alumno).HasForeignKey<Alumno>(e => e.AlumnoDocumento);

            alumno.HasData(alumnosInit);
        });

        List<AlumnoAsignatura> alumnosAsignaturaInit = new List<AlumnoAsignatura>();
        alumnosAsignaturaInit.Add(new AlumnoAsignatura() { AlumnoAsignaturaId = Guid.Parse("2524e251-0885-4c16-b636-0f5616c59a06"), AlumnoId = Guid.Parse("5131973e-a517-4c5a-91d5-d2be6d4bac32"), AsignaturaId = Guid.Parse("ac3fc016-ade0-4772-92a3-85a61121878d"), Semestre = 3 });
        modelBuilder.Entity<AlumnoAsignatura>(alumnoAsignatura =>
        {
            alumnoAsignatura.ToTable("AlumnoAsignatura");

            alumnoAsignatura.HasKey(e => e.AlumnoAsignaturaId);

            alumnoAsignatura.HasOne(e => e.Asignatura).WithMany(e => e.AlumnoAsignaturas).HasForeignKey(e => e.AsignaturaId).OnDelete(DeleteBehavior.NoAction);
            alumnoAsignatura.HasOne(e => e.Alumno).WithMany(e => e.AlumnoAsignaturas).HasForeignKey(e => e.AlumnoId).OnDelete(DeleteBehavior.NoAction);
            alumnoAsignatura.Property(e => e.Semestre).IsRequired();

            alumnoAsignatura.HasData(alumnosAsignaturaInit);
        });

        List<Asignatura> asignaturasInit = new List<Asignatura>();
        asignaturasInit.Add(new Asignatura() { AsignaturaId = Guid.Parse("ac3fc016-ade0-4772-92a3-85a61121878d"), AsignaturaNombre = "Programación Orientada a Objetos", AsignaturaCreditos = 3, ProfesorId = Guid.Parse("920e874c-9eec-4c08-9507-485a9175b31c"), CarreraId = Guid.Parse("40d1e0cd-e84c-4011-947e-58173a596bc8") });
        modelBuilder.Entity<Asignatura>(asignatura =>
        {
            asignatura.ToTable("Asignatura");

            asignatura.HasKey(e => e.AsignaturaId);

            asignatura.HasOne(e => e.Profesor).WithMany(e => e.Asignaturas).HasForeignKey(e => e.ProfesorId);
            asignatura.HasOne(e => e.Carrera).WithMany(e => e.Asignaturas).HasForeignKey(e => e.CarreraId);
            asignatura.Property(e => e.AsignaturaNombre).IsRequired();
            asignatura.Property(e => e.AsignaturaCreditos).IsRequired();

            asignatura.HasData(asignaturasInit);
        });

        List<Carrera> carrerasInit = new List<Carrera>();
        carrerasInit.Add(new Carrera() { CarreraId = Guid.Parse("40d1e0cd-e84c-4011-947e-58173a596bc8"), CarreraNombre = "Ingeniería de Software", FacultadId = Guid.Parse("a461d44b-14b6-4284-bc57-2270af9d8d85") });
        modelBuilder.Entity<Carrera>(carrera =>
        {
            carrera.ToTable("Carrera");

            carrera.HasKey(e => e.CarreraId);

            carrera.HasOne(e => e.Facultad).WithMany(e => e.Carreras).HasForeignKey(e => e.FacultadId);

            carrera.Property(e => e.CarreraNombre).IsRequired();

            carrera.HasData(carrerasInit);
        });

        List<Facultad> facultadesInit = new List<Facultad>();
        facultadesInit.Add(new Facultad() { FacultadId = Guid.Parse("a461d44b-14b6-4284-bc57-2270af9d8d85"), FacultadNombre = "Facultad de Ingeniería de Sistemas" });
        modelBuilder.Entity<Facultad>(facultad =>
        {
            facultad.ToTable("Facultad");

            facultad.HasKey(e => e.FacultadId);

            facultad.Property(e => e.FacultadNombre).IsRequired();

            facultad.HasData(facultadesInit);
        });

        List<Persona> personasInit = new List<Persona>();
        personasInit.Add(new Persona() { PersonaDocumento = 1921874154, PersonaNombre = "Santiago", PersonaApellido = "Rojas", PersonaCiudad = "Bogotá", PersonaTelefono = 300900400, PersonaCorreo = "srojas@uan.edu.co", PersonaFechaNacimiento = Convert.ToDateTime("14/05/2005 00:00:00 AM"), PersonaGenero = 'M' });
        personasInit.Add(new Persona() { PersonaDocumento = 58132098, PersonaNombre = "Juan", PersonaApellido = "Martinez", PersonaCiudad = "Bogotá", PersonaTelefono = 300900401, PersonaCorreo = "jcmartinezd@uan.edu.co", PersonaFechaNacimiento = Convert.ToDateTime("11/10/1976 00:00:00 AM"), PersonaGenero = 'M' });
        personasInit.Add(new Persona() { PersonaDocumento = 78234085, PersonaNombre = "Andrea", PersonaApellido = "Sarmiento", PersonaCiudad = "Bogotá", PersonaTelefono = 300900402, PersonaCorreo = "asarmiento@uan.edu.co", PersonaFechaNacimiento = Convert.ToDateTime("11/10/1976 00:00:00 AM"), PersonaGenero = 'F' });

        modelBuilder.Entity<Persona>(persona =>
        {
            persona.ToTable("Persona");

            persona.HasKey(e => e.PersonaDocumento);

            persona.Property(e => e.PersonaNombre).IsRequired().HasMaxLength(150);
            persona.Property(e => e.PersonaApellido).IsRequired().HasMaxLength(150);
            persona.Property(e => e.PersonaCiudad).IsRequired().HasMaxLength(80);
            persona.Property(e => e.PersonaTelefono).IsRequired();
            persona.Property(e => e.PersonaCorreo).IsRequired();
            persona.Property(e => e.PersonaFechaNacimiento).IsRequired();
            persona.Property(e => e.PersonaGenero).IsRequired();

            persona.HasData(personasInit);
        });

        List<Profesor> profesoresInit = new List<Profesor>();
        profesoresInit.Add(new Profesor() { ProfesorId = Guid.Parse("920e874c-9eec-4c08-9507-485a9175b31c"), ProfesorDocumento = 58132098 });
        modelBuilder.Entity<Profesor>(profesor =>
        {
            profesor.ToTable("Profesor");

            profesor.HasKey(e => e.ProfesorId);

            profesor.HasOne(e => e.Persona).WithOne(e => e.Profesor).HasForeignKey<Profesor>(e => e.ProfesorDocumento);

            profesor.HasData(profesoresInit);
        });

        List<Rector> rectoresInit = new List<Rector>();
        rectoresInit.Add(new Rector() { RectorId = Guid.Parse("531d2123-2836-4720-8d15-313c4aeda145"), RectorDocumento = 78234085 });
        modelBuilder.Entity<Rector>(rector =>
        {
            rector.ToTable("Rector");

            rector.HasKey(e => e.RectorId);

            rector.HasOne(e => e.Persona).WithOne(e => e.Rector).HasForeignKey<Rector>(e => e.RectorDocumento);

            rector.HasData(rectoresInit);
        });

        List<Sede> sedesInit = new List<Sede>();
        sedesInit.Add(new Sede() { SedeId = Guid.Parse("7b82b004-1f75-4226-8b91-f7d68b2534ea"), SedeNombre = "Sede Sur", SedeDireccion = "CARRERA 38 #58A-77", RectorId = Guid.Parse("531d2123-2836-4720-8d15-313c4aeda145") });
        modelBuilder.Entity<Sede>(sede =>
        {
            sede.ToTable("Sede");

            sede.HasKey(e => e.SedeId);

            sede.HasOne(e => e.Rector).WithOne(e => e.Sede).HasForeignKey<Sede>(e => e.RectorId);

            sede.Property(e => e.SedeNombre).IsRequired();
            sede.Property(e => e.SedeDireccion).IsRequired();

            sede.HasData(sedesInit);
        });

    }
}