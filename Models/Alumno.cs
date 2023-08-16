using System.Text.Json.Serialization;

namespace UniversidadEf.Models;

public class Alumno
{
    public int AlumnoId { get; set; }
    public int AlumnoDocumento { get; set; }

    [JsonIgnore]
    public ICollection<AlumnoAsignatura> AlumnoAsignaturas { get; set; }
}