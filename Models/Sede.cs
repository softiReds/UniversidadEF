using System.Text.Json.Serialization;

namespace UniversidadEf.Models;

public class Sede
{
    public int SedeId { get; set; }
    public string SedeNombre { get; set; }
    public string SedeDireccion { get; set; }
    public int RectorId { get; set; }

    public virtual Rector Rector { get; set; }

    [JsonIgnore]
    public virtual ICollection<Facultad> Facultades { get; set; }
}