namespace UniversidadEf.Models;

public class Persona
{
    public int PersonaDocumento { get; set; }
    public string PersonaNombre { get; set; }
    public string PersonaApellido { get; set; }
    public string PersonaCiudad { get; set; }
    public int PersonaTelefono { get; set; }
    public DateTime PersonaFechaNacimiento { get; set; }
    public char Genero { get; set; }
}