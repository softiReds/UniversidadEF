using Microsoft.AspNetCore.Mvc;
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
    return context.Alumnos;
});

app.Run();
