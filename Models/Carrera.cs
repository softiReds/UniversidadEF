using System.Text.Json.Serialization;

namespace UniversidadEf.Models;

public class Carrera
{
    public Guid CarreraId { get; set; }
    public string CarreraNombre { get; set; }
    public Guid FacultadId { get; set; }

    public virtual Facultad Facultad { get; set; }

    [JsonIgnore]
    public virtual ICollection<Asignatura> Asignaturas { get; set; }
}