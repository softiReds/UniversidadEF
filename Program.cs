using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversidadEF.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<UniversidadContext>(builder.Configuration.GetConnectionString("localConnection"));

var app = builder.Build();

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

app.Run();
