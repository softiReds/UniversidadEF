using System.Text.Json.Serialization;

namespace UniversidadEf.Models;

public class Asignatura
{
    public int AsignaturaId { get; set; }
    public string AsignaturaNombre { get; set; }
    public int AsignaturaCreditos { get; set; }
    public int ProfesorId { get; set; }

    public int CarreraId { get; set; }

    public virtual Profesor Profesor { get; set; }
    public virtual Carrera Carrera { get; set; }

    [JsonIgnore]
    public virtual ICollection<AlumnoAsignatura> AlumnoAsignaturas { get; set; }
}