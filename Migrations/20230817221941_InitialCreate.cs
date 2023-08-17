using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversidadEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facultad",
                columns: table => new
                {
                    FacultadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultadNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultad", x => x.FacultadId);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    PersonaDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaNombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PersonaApellido = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PersonaCiudad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PersonaTelefono = table.Column<int>(type: "int", nullable: false),
                    PersonaCorreo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaFechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonaGenero = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.PersonaDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    CarreraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarreraNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.CarreraId);
                    table.ForeignKey(
                        name: "FK_Carrera_Facultad_FacultadId",
                        column: x => x.FacultadId,
                        principalTable: "Facultad",
                        principalColumn: "FacultadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    AlumnoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoDocumento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.AlumnoId);
                    table.ForeignKey(
                        name: "FK_Alumno_Persona_AlumnoDocumento",
                        column: x => x.AlumnoDocumento,
                        principalTable: "Persona",
                        principalColumn: "PersonaDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    ProfesorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorDocumento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.ProfesorId);
                    table.ForeignKey(
                        name: "FK_Profesor_Persona_ProfesorDocumento",
                        column: x => x.ProfesorDocumento,
                        principalTable: "Persona",
                        principalColumn: "PersonaDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rector",
                columns: table => new
                {
                    RectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RectorDocumento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rector", x => x.RectorId);
                    table.ForeignKey(
                        name: "FK_Rector_Persona_RectorDocumento",
                        column: x => x.RectorDocumento,
                        principalTable: "Persona",
                        principalColumn: "PersonaDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    AsignaturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AsignaturaNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AsignaturaCreditos = table.Column<int>(type: "int", nullable: false),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    CarreraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.AsignaturaId);
                    table.ForeignKey(
                        name: "FK_Asignatura_Carrera_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carrera",
                        principalColumn: "CarreraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignatura_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesor",
                        principalColumn: "ProfesorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sede",
                columns: table => new
                {
                    SedeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SedeNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SedeDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sede", x => x.SedeId);
                    table.ForeignKey(
                        name: "FK_Sede_Rector_RectorId",
                        column: x => x.RectorId,
                        principalTable: "Rector",
                        principalColumn: "RectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoAsignatura",
                columns: table => new
                {
                    AlumnoAsignaturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoId = table.Column<int>(type: "int", nullable: false),
                    AsignaturaId = table.Column<int>(type: "int", nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoAsignatura", x => x.AlumnoAsignaturaId);
                    table.ForeignKey(
                        name: "FK_AlumnoAsignatura_Alumno_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumno",
                        principalColumn: "AlumnoId");
                    table.ForeignKey(
                        name: "FK_AlumnoAsignatura_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignatura",
                        principalColumn: "AsignaturaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_AlumnoDocumento",
                table: "Alumno",
                column: "AlumnoDocumento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoAsignatura_AlumnoId",
                table: "AlumnoAsignatura",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoAsignatura_AsignaturaId",
                table: "AlumnoAsignatura",
                column: "AsignaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_CarreraId",
                table: "Asignatura",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_ProfesorId",
                table: "Asignatura",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrera_FacultadId",
                table: "Carrera",
                column: "FacultadId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_ProfesorDocumento",
                table: "Profesor",
                column: "ProfesorDocumento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rector_RectorDocumento",
                table: "Rector",
                column: "RectorDocumento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sede_RectorId",
                table: "Sede",
                column: "RectorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoAsignatura");

            migrationBuilder.DropTable(
                name: "Sede");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "Rector");

            migrationBuilder.DropTable(
                name: "Carrera");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Facultad");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
