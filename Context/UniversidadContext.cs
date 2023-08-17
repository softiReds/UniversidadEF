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
        modelBuilder.Entity<Alumno>(alumno =>
        {
            alumno.ToTable("Alumno");

            alumno.HasKey(e => e.AlumnoId);

            alumno.Property(e => e.AlumnoDocumento).IsRequired();
        });

        modelBuilder.Entity<AlumnoAsignatura>(alumnoAsignatura =>
        {
            alumnoAsignatura.ToTable("AlumnoAsignatura");

            alumnoAsignatura.HasOne(e => e.Asignatura).WithMany(e => e.AlumnoAsignaturas).HasForeignKey(e => e.AsignaturaId);
            alumnoAsignatura.HasOne(e => e.Alumno).WithMany(e => e.AlumnoAsignaturas).HasForeignKey(e => e.AlumnoId);
            alumnoAsignatura.Property(e => e.Semestre).IsRequired();
        });

        modelBuilder.Entity<Asignatura>(asignatura =>
        {
            asignatura.ToTable("Asignatura");

            asignatura.HasKey(e => e.AsignaturaId);

            asignatura.HasOne(e => e.Profesor).WithMany(e => e.Asignaturas).HasForeignKey(e => e.ProfesorId);

            asignatura.Property(e => e.AsignaturaNombre).IsRequired();
            asignatura.Property(e => e.AsignaturaCreditos).IsRequired();
        });

        modelBuilder.Entity<Carrera>(carrera =>
        {
            carrera.ToTable("Carrera");

            carrera.HasKey(e => e.CarreraId);

            carrera.HasOne(e => e.Facultad).WithMany(e => e.Carreras).HasForeignKey(e => e.FacultadId);

            carrera.Property(e => e.CarreraNombre).IsRequired();
        });

        modelBuilder.Entity<Facultad>(facultad =>
        {
            facultad.ToTable("Facultad");

            facultad.HasKey(e => e.FacultadId);

            facultad.Property(e => e.FacultadNombre).IsRequired();
        });

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
        });

        modelBuilder.Entity<Profesor>(profesor =>
        {
            profesor.ToTable("Profesor");

            profesor.HasKey(e => e.ProfesorId);

            profesor.Property(e => e.ProfesorDocumento).IsRequired();
        });

        modelBuilder.Entity<Rector>(rector =>
        {
            rector.ToTable("Rector");

            rector.HasKey(e => e.RectorId);

            rector.Property(e => e.RectorDocumento).IsRequired();
        });

        modelBuilder.Entity<Sede>(sede =>
        {
            sede.ToTable("Sede");

            sede.HasKey(e => e.SedeId);

            sede.HasOne(e => e.Rector).WithOne(e => e.Sede).HasForeignKey<Sede>(e => e.RectorId);

            sede.Property(e => e.SedeNombre).IsRequired();
            sede.Property(e => e.SedeDireccion).IsRequired();
        });

    }
}