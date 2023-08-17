using System.Text.Json.Serialization;

namespace UniversidadEf.Models;

public class Facultad
{
    public Guid FacultadId { get; set; }
    public string FacultadNombre { get; set; }

    [JsonIgnore]
    public ICollection<Carrera> Carreras { get; set; }
}