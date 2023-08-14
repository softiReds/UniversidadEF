namespace UniversidadEf.Models;

public class AlumnoAsignatura
{
    public int AlumnoId { get; set; }
    public int AsignaturaId { get; set; }
    public int Semestre { get; set; }

    public virtual Alumno Alumno { get; set; }
    public virtual Asignatura Asignatura { get; set; }
}