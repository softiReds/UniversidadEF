using System.Text.Json.Serialization;

namespace UniversidadEf.Models;

public class Persona
{
    public int PersonaDocumento { get; set; }
    public string PersonaNombre { get; set; }
    public string PersonaApellido { get; set; }
    public string PersonaCiudad { get; set; }
    public int PersonaTelefono { get; set; }
    public string PersonaCorreo { get; set; }
    public DateTime PersonaFechaNacimiento { get; set; }
    public char PersonaGenero { get; set; }

    [JsonIgnore]
    public virtual Alumno Alumno { get; set; }
    [JsonIgnore]
    public virtual Profesor Profesor { get; set; }
    [JsonIgnore]
    public virtual Rector Rector { get; set; }
}