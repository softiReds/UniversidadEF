using System.Text.Json.Serialization;

namespace UniversidadEf.Models;

public class Profesor
{
    public Guid ProfesorId { get; set; }
    public int ProfesorDocumento { get; set; }

    public virtual Persona Persona { get; set; }

    [JsonIgnore]
    public ICollection<Asignatura> Asignaturas { get; set; }
}