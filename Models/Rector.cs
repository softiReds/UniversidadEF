namespace UniversidadEf.Models;

public class Rector
{
    public Guid RectorId { get; set; }
    public int RectorDocumento { get; set; }

    public virtual Sede Sede { get; set; }
    public virtual Persona Persona { get; set; }
}