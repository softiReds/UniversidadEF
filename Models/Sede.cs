using System.Text.Json.Serialization;

namespace UniversidadEf.Models;

public class Sede
{
    public Guid SedeId { get; set; }
    public string SedeNombre { get; set; }
    public string SedeDireccion { get; set; }

    public Guid RectorId { get; set; }

    public virtual Rector Rector { get; set; }
}