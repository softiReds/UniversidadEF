using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversidadEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RectorId",
                table: "Sede",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "SedeId",
                table: "Sede",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "RectorId",
                table: "Rector",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfesorId",
                table: "Profesor",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "FacultadId",
                table: "Facultad",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "FacultadId",
                table: "Carrera",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarreraId",
                table: "Carrera",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfesorId",
                table: "Asignatura",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarreraId",
                table: "Asignatura",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "AsignaturaId",
                table: "Asignatura",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "AsignaturaId",
                table: "AlumnoAsignatura",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlumnoId",
                table: "AlumnoAsignatura",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlumnoAsignaturaId",
                table: "AlumnoAsignatura",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlumnoId",
                table: "Alumno",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Alumno",
                columns: new[] { "AlumnoId", "AlumnoDocumento" },
                values: new object[] { new Guid("5131973e-a517-4c5a-91d5-d2be6d4bac32"), 1021669017 });

            migrationBuilder.InsertData(
                table: "Facultad",
                columns: new[] { "FacultadId", "FacultadNombre" },
                values: new object[] { new Guid("a461d44b-14b6-4284-bc57-2270af9d8d85"), "Facultad de Ingeniería de Sistemas" });

            migrationBuilder.InsertData(
                table: "Persona",
                columns: new[] { "PersonaDocumento", "PersonaApellido", "PersonaCiudad", "PersonaCorreo", "PersonaFechaNacimiento", "PersonaGenero", "PersonaNombre", "PersonaTelefono" },
                values: new object[,]
                {
                    { 58132098, "Martinez", "Bogotá", "jcmartinezd@uan.edu.co", new DateTime(1976, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "M", "Juan", 300900401 },
                    { 78234085, "Sarmiento", "Bogotá", "asarmiento@uan.edu.co", new DateTime(1976, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "F", "Andrea", 300900402 },
                    { 1921874154, "Rojas", "Bogotá", "srojas@uan.edu.co", new DateTime(2005, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "M", "Santiago", 300900400 }
                });

            migrationBuilder.InsertData(
                table: "Carrera",
                columns: new[] { "CarreraId", "CarreraNombre", "FacultadId" },
                values: new object[] { new Guid("40d1e0cd-e84c-4011-947e-58173a596bc8"), "Ingeniería de Software", new Guid("a461d44b-14b6-4284-bc57-2270af9d8d85") });

            migrationBuilder.InsertData(
                table: "Profesor",
                columns: new[] { "ProfesorId", "ProfesorDocumento" },
                values: new object[] { new Guid("920e874c-9eec-4c08-9507-485a9175b31c"), 58132098 });

            migrationBuilder.InsertData(
                table: "Rector",
                columns: new[] { "RectorId", "RectorDocumento" },
                values: new object[] { new Guid("531d2123-2836-4720-8d15-313c4aeda145"), 78234085 });

            migrationBuilder.InsertData(
                table: "Asignatura",
                columns: new[] { "AsignaturaId", "AsignaturaCreditos", "AsignaturaNombre", "CarreraId", "ProfesorId" },
                values: new object[] { new Guid("ac3fc016-ade0-4772-92a3-85a61121878d"), 3, "Programación Orientada a Objetos", new Guid("40d1e0cd-e84c-4011-947e-58173a596bc8"), new Guid("920e874c-9eec-4c08-9507-485a9175b31c") });

            migrationBuilder.InsertData(
                table: "Sede",
                columns: new[] { "SedeId", "RectorId", "SedeDireccion", "SedeNombre" },
                values: new object[] { new Guid("7b82b004-1f75-4226-8b91-f7d68b2534ea"), new Guid("531d2123-2836-4720-8d15-313c4aeda145"), "CARRERA 38 #58A-77", "Sede Sur" });

            migrationBuilder.InsertData(
                table: "AlumnoAsignatura",
                columns: new[] { "AlumnoAsignaturaId", "AlumnoId", "AsignaturaId", "Semestre" },
                values: new object[] { new Guid("2524e251-0885-4c16-b636-0f5616c59a06"), new Guid("5131973e-a517-4c5a-91d5-d2be6d4bac32"), new Guid("ac3fc016-ade0-4772-92a3-85a61121878d"), 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AlumnoAsignatura",
                keyColumn: "AlumnoAsignaturaId",
                keyValue: new Guid("2524e251-0885-4c16-b636-0f5616c59a06"));

            migrationBuilder.DeleteData(
                table: "Persona",
                keyColumn: "PersonaDocumento",
                keyValue: 1921874154);

            migrationBuilder.DeleteData(
                table: "Sede",
                keyColumn: "SedeId",
                keyValue: new Guid("7b82b004-1f75-4226-8b91-f7d68b2534ea"));

            migrationBuilder.DeleteData(
                table: "Alumno",
                keyColumn: "AlumnoId",
                keyValue: new Guid("5131973e-a517-4c5a-91d5-d2be6d4bac32"));

            migrationBuilder.DeleteData(
                table: "Asignatura",
                keyColumn: "AsignaturaId",
                keyValue: new Guid("ac3fc016-ade0-4772-92a3-85a61121878d"));

            migrationBuilder.DeleteData(
                table: "Rector",
                keyColumn: "RectorId",
                keyValue: new Guid("531d2123-2836-4720-8d15-313c4aeda145"));

            migrationBuilder.DeleteData(
                table: "Carrera",
                keyColumn: "CarreraId",
                keyValue: new Guid("40d1e0cd-e84c-4011-947e-58173a596bc8"));

            migrationBuilder.DeleteData(
                table: "Persona",
                keyColumn: "PersonaDocumento",
                keyValue: 78234085);

            migrationBuilder.DeleteData(
                table: "Profesor",
                keyColumn: "ProfesorId",
                keyValue: new Guid("920e874c-9eec-4c08-9507-485a9175b31c"));

            migrationBuilder.DeleteData(
                table: "Facultad",
                keyColumn: "FacultadId",
                keyValue: new Guid("a461d44b-14b6-4284-bc57-2270af9d8d85"));

            migrationBuilder.DeleteData(
                table: "Persona",
                keyColumn: "PersonaDocumento",
                keyValue: 58132098);

            migrationBuilder.AlterColumn<int>(
                name: "RectorId",
                table: "Sede",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "SedeId",
                table: "Sede",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "RectorId",
                table: "Rector",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProfesorId",
                table: "Profesor",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "FacultadId",
                table: "Facultad",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "FacultadId",
                table: "Carrera",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "CarreraId",
                table: "Carrera",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProfesorId",
                table: "Asignatura",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "CarreraId",
                table: "Asignatura",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "AsignaturaId",
                table: "Asignatura",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "AsignaturaId",
                table: "AlumnoAsignatura",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "AlumnoId",
                table: "AlumnoAsignatura",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "AlumnoAsignaturaId",
                table: "AlumnoAsignatura",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "AlumnoId",
                table: "Alumno",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
