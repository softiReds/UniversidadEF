using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversidadEf.Models;
using UniversidadEF.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<UniversidadContext>(builder.Configuration.GetConnectionString("localConnection"));

var app = builder.Build();

#region GetAlumnos
app.MapGet("/", async ([FromServices] UniversidadContext context) =>
{
    context.Database.EnsureCreated();

    return Results.Ok();
});

app.MapGet("/get/alumnos", async ([FromServices] UniversidadContext context) =>
{
    return Results.Ok(context.Alumnos.Include(e => e.Persona));
});

app.MapGet("/get/alumnos/id/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Alumnos.Find(id));
});

app.MapGet("/get/alumnos/persona/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Alumnos.Where(e => e.PersonaId == id));
});
#endregion

#region GetAlumnoAsignaturas
app.MapGet("/get/alumnoasignaturas", async ([FromServices] UniversidadContext context) =>
{
    return Results.Ok(context.AlumnoAsignaturas.Include(e => e.Alumno).Include(e => e.Asignatura));
});

app.MapGet("/get/alumnoasignaturas/alumno/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.AlumnoAsignaturas.Where(e => e.AlumnoId == id).Include(e => e.Alumno).Include(e => e.Asignatura));
});

app.MapGet("/get/alumnoasignaturas/asignatura/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.AlumnoAsignaturas.Where(e => e.AsignaturaId == id).Include(e => e.Alumno).Include(e => e.Asignatura));
});

app.MapGet("/get/alumnoasignaturas/alumno/{idAlumno}/asignatura/{idAsignatura}", async ([FromServices] UniversidadContext context, [FromRoute] Guid idAlumno, [FromRoute] Guid idAsignatura) =>
{
    return Results.Ok(context.AlumnoAsignaturas.Where(e => e.AlumnoId == idAlumno && e.AsignaturaId == idAsignatura).Include(e => e.Alumno).Include(e => e.Asignatura));
});
#endregion

#region GetAsignaturas
app.MapGet("/get/asignaturas", async ([FromServices] UniversidadContext context) =>
{
    return Results.Ok(context.Asignaturas.Include(e => e.Profesor).Include(e => e.Carrera));
});

app.MapGet("/get/asignaturas/id/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Asignaturas.Where(e => e.AsignaturaId == id).Include(e => e.Profesor).Include(e => e.Carrera));
});

app.MapGet("/get/asignaturas/nombre/{nombre}", async ([FromServices] UniversidadContext context, [FromRoute] string nombre) =>
{
    return Results.Ok(context.Asignaturas.Where(e => e.AsignaturaNombre == nombre).Include(e => e.Profesor).Include(e => e.Carrera));
});

app.MapGet("/get/asignaturas/cred/{creditos}", async ([FromServices] UniversidadContext context, [FromRoute] int creditos) =>
{
    return Results.Ok(context.Asignaturas.Where(e => e.AsignaturaCreditos == creditos).Include(e => e.Profesor).Include(e => e.Carrera));
});

app.MapGet("/get/asignaturas/prof/{Id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Asignaturas.Where(e => e.ProfesorId == id).Include(e => e.Profesor).Include(e => e.Carrera));
});

app.MapGet("/get/asignaturas/carr/{Id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Asignaturas.Where(e => e.CarreraId == id).Include(e => e.Profesor).Include(e => e.Carrera));
});
#endregion

#region GetCarreras
app.MapGet("/get/carreras", async ([FromServices] UniversidadContext context) =>
{
    return Results.Ok(context.Carreras.Include(e => e.Facultad));
});

app.MapGet("/get/carreras/id/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Carreras.Where(e => e.CarreraId == id).Include(e => e.Facultad));
});

app.MapGet("/get/carreras/nombre/{nombre}", async ([FromServices] UniversidadContext context, [FromRoute] string nombre) =>
{
    return Results.Ok(context.Carreras.Where(e => e.CarreraNombre == nombre).Include(e => e.Facultad));
});

app.MapGet("/get/carreras/facu/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Carreras.Where(e => e.FacultadId == id).Include(e => e.Facultad));
});
#endregion

#region GetFacultad

app.MapGet("get/facultades", async ([FromServices] UniversidadContext context) =>
{
    return Results.Ok(context.Facultades);
});

app.MapGet("/get/facultades/id/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Facultades.Where(e => e.FacultadId == id));
});

app.MapGet("/get/facultades/nombre/{nombre}", async ([FromServices] UniversidadContext context, [FromRoute] string nombre) =>
{
    return Results.Ok(context.Facultades.Where(e => e.FacultadNombre == nombre));
});
#endregion

#region GetPersonas
app.MapGet("/get/personas", async ([FromServices] UniversidadContext context) =>
{
    return Results.Ok(context.Personas);
});

app.MapGet("/get/personas/doc/{documento}", async ([FromServices] UniversidadContext context, [FromRoute] int documento) =>
{
    return Results.Ok(context.Personas.Where(e => e.PersonaDocumento == documento));
});

app.MapGet("/get/personas/nombre/{nombre}", async ([FromServices] UniversidadContext context, [FromRoute] string nombre) =>
{
    return Results.Ok(context.Personas.Where(e => e.PersonaNombre == nombre));
});

app.MapGet("/get/personas/apellido/{apellido}", async ([FromServices] UniversidadContext context, [FromRoute] string apellido) =>
{
    return Results.Ok(context.Personas.Where(e => e.PersonaApellido == apellido));
});

app.MapGet("/get/personas/ciudad/{ciudad}", async ([FromServices] UniversidadContext context, [FromRoute] string ciudad) =>
{
    return Results.Ok(context.Personas.Where(e => e.PersonaCiudad == ciudad));
});

app.MapGet("/get/personas/tel/{telefono}", async ([FromServices] UniversidadContext context, [FromRoute] int telefono) =>
{
    return Results.Ok(context.Personas.Where(e => e.PersonaTelefono == telefono));
});

app.MapGet("/get/personas/correo/{correo}", async ([FromServices] UniversidadContext context, [FromRoute] string correo) =>
{
    return Results.Ok(context.Personas.Where(e => e.PersonaCorreo == correo));
});
#endregion

#region GetProfesores
app.MapGet("/get/profesores", async ([FromServices] UniversidadContext context) =>
{
    return Results.Ok(context.Profesores.Include(e => e.Persona));
});

app.MapGet("/get/profesores/id/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Profesores.Where(e => e.ProfesorId == id).Include(e => e.Persona));
});

app.MapGet("/get/profesores/persona/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Profesores.Where(e => e.PersonaId == id).Include(e => e.Persona));
});
#endregion

#region GetRectores
app.MapGet("/get/rectores", async ([FromServices] UniversidadContext context) =>
{
    return Results.Ok(context.Rectores.Include(e => e.Persona));
});

app.MapGet("/get/rectores/id/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Rectores.Where(e => e.RectorId == id).Include(e => e.Persona));
});

app.MapGet("/get/rectores/persona/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Rectores.Where(e => e.PersonaId == id).Include(e => e.Persona));
});
#endregion

#region GetSedes
app.MapGet("/get/sedes", async ([FromServices] UniversidadContext cotext) =>
{
    return Results.Ok(cotext.Sedes);
});

app.MapGet("/get/sedes/id/{id}", async ([FromServices] UniversidadContext cotext, [FromRoute] Guid id) =>
{
    return Results.Ok(cotext.Sedes.Where(e => e.SedeId == id));
});

app.MapGet("/get/sedes/nombre/{nombre}", async ([FromServices] UniversidadContext cotext, [FromRoute] string nombre) =>
{
    return Results.Ok(cotext.Sedes.Where(e => e.SedeNombre == nombre));
});

app.MapGet("/get/sedes/dir/{direccion}", async ([FromServices] UniversidadContext cotext, [FromRoute] string direccion) =>
{
    return Results.Ok(cotext.Sedes.Where(e => e.SedeDireccion == direccion));
});
#endregion

#region PostPersona
app.MapPost("/post/personas", async ([FromServices] UniversidadContext context, [FromBody] Persona persona) =>
{
    persona.PersonaId = Guid.NewGuid();

    await context.Personas.AddAsync(persona);
    await context.SaveChangesAsync();

    return Results.Ok();
});
#endregion

#region PostAlumno
app.MapPost("/post/alumnos", async ([FromServices] UniversidadContext context, [FromBody] Alumno alumno) =>
{
    alumno.AlumnoId = Guid.NewGuid();

    await context.Alumnos.AddAsync(alumno);
    await context.SaveChangesAsync();

    return Results.Ok();
});
#endregion

#region PostRector
app.MapPost("/post/rectores", async ([FromServices] UniversidadContext context, [FromBody] Rector rector) =>
{
    rector.RectorId = Guid.NewGuid();

    await context.Rectores.AddAsync(rector);
    await context.SaveChangesAsync();

    return Results.Ok();
});
#endregion

#region PostSede
app.MapPost("/post/sedes", async ([FromServices] UniversidadContext context, [FromBody] Sede sede) =>
{
    sede.SedeId = Guid.NewGuid();

    await context.Sedes.AddAsync(sede);
    await context.SaveChangesAsync();

    return Results.Ok();
});
#endregion

#region PostProfesor
app.MapPost("/post/profesores", async ([FromServices] UniversidadContext context, [FromBody] Profesor profesor) =>
{
    profesor.ProfesorId = Guid.NewGuid();

    await context.Profesores.AddAsync(profesor);
    await context.SaveChangesAsync();

    return Results.Ok();
});
#endregion

#region PostAsignatura
app.MapPost("/post/asignaturas", async ([FromServices] UniversidadContext context, [FromBody] Asignatura asignatura) =>
{
    asignatura.AsignaturaId = Guid.NewGuid();

    await context.Asignaturas.AddAsync(asignatura);
    await context.SaveChangesAsync();

    return Results.Ok();
});
#endregion

#region PostFacultad
app.MapPost("/post/facultades", async ([FromServices] UniversidadContext context, [FromBody] Facultad facultad) =>
{
    facultad.FacultadId = Guid.NewGuid();

    await context.Facultades.AddAsync(facultad);
    await context.SaveChangesAsync();

    return Results.Ok();
});
#endregion

#region PostCarrera
app.MapPost("/post/carreras", async ([FromServices] UniversidadContext context, [FromBody] Carrera carrera) =>
{
    carrera.CarreraId = Guid.NewGuid();

    await context.Carreras.AddAsync(carrera);
    await context.SaveChangesAsync();

    return Results.Ok();
});
#endregion

#region PostAlumnoAsignatura
app.MapPost("/post/alumnoasignaturas", async ([FromServices] UniversidadContext context, [FromBody] AlumnoAsignatura alumnoAsignatura) =>
{
    alumnoAsignatura.AlumnoAsignaturaId = Guid.NewGuid();

    await context.AlumnoAsignaturas.AddAsync(alumnoAsignatura);
    await context.SaveChangesAsync();

    return Results.Ok();
});
#endregion

#region PutPersona
app.MapPut("/put/personas/{id}", async ([FromServices] UniversidadContext context, [FromBody] Persona persona, [FromRoute] Guid id) =>
{
    Persona personaActual = context.Personas.Find(id);

    if (personaActual != null)
    {
        personaActual.PersonaDocumento = persona.PersonaDocumento;
        personaActual.PersonaNombre = persona.PersonaNombre;
        personaActual.PersonaApellido = persona.PersonaApellido;
        personaActual.PersonaCiudad = persona.PersonaCiudad;
        personaActual.PersonaTelefono = persona.PersonaTelefono;
        personaActual.PersonaCorreo = persona.PersonaCorreo;
        personaActual.PersonaFechaNacimiento = persona.PersonaFechaNacimiento;
        personaActual.PersonaGenero = persona.PersonaGenero;

        await context.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});
#endregion

#region PutAlumnoAsignatura
app.MapPut("/put/alumnoasignaturas/{id}", async ([FromServices] UniversidadContext context, [FromBody] AlumnoAsignatura alumnoAsignatura, [FromRoute] Guid id) =>
{
    AlumnoAsignatura alumnoAsignaturaActual = context.AlumnoAsignaturas.Find(id);

    if (alumnoAsignaturaActual != null)
    {
        alumnoAsignaturaActual.AsignaturaId = alumnoAsignatura.AsignaturaId;
        alumnoAsignaturaActual.Semestre = alumnoAsignatura.Semestre;

        await context.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});
#endregion

app.Run();