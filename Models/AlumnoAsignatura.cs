namespace UniversidadEf.Models;

public class AlumnoAsignatura
{
    public Guid AlumnoAsignaturaId { get; set; }
    public Guid AlumnoId { get; set; }
    public Guid AsignaturaId { get; set; }
    public int Semestre { get; set; }

    public virtual Alumno Alumno { get; set; }
    public virtual Asignatura Asignatura { get; set; }
}