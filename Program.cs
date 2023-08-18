using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

app.MapGet("/get/alumnos/doc/{documento}", async ([FromServices] UniversidadContext context, [FromRoute] int documento) =>
{
    return Results.Ok(context.Alumnos.Where(e => e.AlumnoDocumento == documento));
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

#region GetCarrera
app.MapGet("/get/carrera", async ([FromServices] UniversidadContext context) =>
{
    return Results.Ok(context.Carreras.Include(e => e.Facultad));
});

app.MapGet("/get/carrera/id/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
{
    return Results.Ok(context.Carreras.Where(e => e.CarreraId == id).Include(e => e.Facultad));
});

app.MapGet("/get/carrera/nombre/{nombre}", async ([FromServices] UniversidadContext context, [FromRoute] string nombre) =>
{
    return Results.Ok(context.Carreras.Where(e => e.CarreraNombre == nombre).Include(e => e.Facultad));
});

app.MapGet("/get/carrera/facu/{id}", async ([FromServices] UniversidadContext context, [FromRoute] Guid id) =>
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

app.Run();
