namespace UniversidadEf.Models;

public class Rector
{
    public int RectorId { get; set; }
    public int RectorDocumento { get; set; }

    public virtual Sede Sede { get; set; }
}