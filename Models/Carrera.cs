namespace UniversidadEf.Models;

public class Carrera
{
    public int CarreraId { get; set; }
    public string CarreraNombre { get; set; }
    public int FacultadId { get; set; }

    public virtual Facultad Facultad { get; set; }
}