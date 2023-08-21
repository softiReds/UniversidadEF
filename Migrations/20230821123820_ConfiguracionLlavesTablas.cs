using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversidadEF.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguracionLlavesTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Persona_AlumnoDocumento",
                table: "Alumno");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesor_Persona_ProfesorDocumento",
                table: "Profesor");

            migrationBuilder.DropForeignKey(
                name: "FK_Rector_Persona_RectorDocumento",
                table: "Rector");

            migrationBuilder.DropIndex(
                name: "IX_Rector_RectorDocumento",
                table: "Rector");

            migrationBuilder.DropIndex(
                name: "IX_Profesor_ProfesorDocumento",
                table: "Profesor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_AlumnoDocumento",
                table: "Alumno");

            migrationBuilder.DeleteData(
                table: "Persona",
                keyColumn: "PersonaDocumento",
                keyValue: 58132098);

            migrationBuilder.DeleteData(
                table: "Persona",
                keyColumn: "PersonaDocumento",
                keyValue: 78234085);

            migrationBuilder.DeleteData(
                table: "Persona",
                keyColumn: "PersonaDocumento",
                keyValue: 1921874154);

            migrationBuilder.DropColumn(
                name: "RectorDocumento",
                table: "Rector");

            migrationBuilder.DropColumn(
                name: "ProfesorDocumento",
                table: "Profesor");

            migrationBuilder.DropColumn(
                name: "AlumnoDocumento",
                table: "Alumno");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonaId",
                table: "Rector",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PersonaId",
                table: "Profesor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "PersonaDocumento",
                table: "Persona",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonaId",
                table: "Persona",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PersonaId",
                table: "Alumno",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "PersonaId");

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "AlumnoId",
                keyValue: new Guid("5131973e-a517-4c5a-91d5-d2be6d4bac32"),
                column: "PersonaId",
                value: new Guid("ec4edb8d-4f84-4aea-aebc-a60f98810c43"));

            migrationBuilder.InsertData(
                table: "Persona",
                columns: new[] { "PersonaId", "PersonaApellido", "PersonaCiudad", "PersonaCorreo", "PersonaDocumento", "PersonaFechaNacimiento", "PersonaGenero", "PersonaNombre", "PersonaTelefono" },
                values: new object[,]
                {
                    { new Guid("4b75643d-6fdc-49a8-97b6-897e9452c0fc"), "Sarmiento", "Bogotá", "asarmiento@uan.edu.co", 78234085, new DateTime(1976, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "F", "Andrea", 300900402 },
                    { new Guid("9505c0e7-2707-4f5e-a760-2cad68c82cd4"), "Martinez", "Bogotá", "jcmartinezd@uan.edu.co", 58132098, new DateTime(1976, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "M", "Juan", 300900401 },
                    { new Guid("ec4edb8d-4f84-4aea-aebc-a60f98810c43"), "Rojas", "Bogotá", "srojas@uan.edu.co", 1921874154, new DateTime(2005, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "M", "Santiago", 300900400 }
                });

            migrationBuilder.UpdateData(
                table: "Profesor",
                keyColumn: "ProfesorId",
                keyValue: new Guid("920e874c-9eec-4c08-9507-485a9175b31c"),
                column: "PersonaId",
                value: new Guid("9505c0e7-2707-4f5e-a760-2cad68c82cd4"));

            migrationBuilder.UpdateData(
                table: "Rector",
                keyColumn: "RectorId",
                keyValue: new Guid("531d2123-2836-4720-8d15-313c4aeda145"),
                column: "PersonaId",
                value: new Guid("4b75643d-6fdc-49a8-97b6-897e9452c0fc"));

            migrationBuilder.CreateIndex(
                name: "IX_Rector_PersonaId",
                table: "Rector",
                column: "PersonaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_PersonaId",
                table: "Profesor",
                column: "PersonaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_PersonaId",
                table: "Alumno",
                column: "PersonaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Persona_PersonaId",
                table: "Alumno",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesor_Persona_PersonaId",
                table: "Profesor",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rector_Persona_PersonaId",
                table: "Rector",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Persona_PersonaId",
                table: "Alumno");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesor_Persona_PersonaId",
                table: "Profesor");

            migrationBuilder.DropForeignKey(
                name: "FK_Rector_Persona_PersonaId",
                table: "Rector");

            migrationBuilder.DropIndex(
                name: "IX_Rector_PersonaId",
                table: "Rector");

            migrationBuilder.DropIndex(
                name: "IX_Profesor_PersonaId",
                table: "Profesor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_PersonaId",
                table: "Alumno");

            migrationBuilder.DeleteData(
                table: "Persona",
                keyColumn: "PersonaId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("4b75643d-6fdc-49a8-97b6-897e9452c0fc"));

            migrationBuilder.DeleteData(
                table: "Persona",
                keyColumn: "PersonaId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("9505c0e7-2707-4f5e-a760-2cad68c82cd4"));

            migrationBuilder.DeleteData(
                table: "Persona",
                keyColumn: "PersonaId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("ec4edb8d-4f84-4aea-aebc-a60f98810c43"));

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Rector");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Profesor");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Alumno");

            migrationBuilder.AddColumn<int>(
                name: "RectorDocumento",
                table: "Rector",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfesorDocumento",
                table: "Profesor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PersonaDocumento",
                table: "Persona",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AlumnoDocumento",
                table: "Alumno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "PersonaDocumento");

            migrationBuilder.UpdateData(
                table: "Alumno",
                keyColumn: "AlumnoId",
                keyValue: new Guid("5131973e-a517-4c5a-91d5-d2be6d4bac32"),
                column: "AlumnoDocumento",
                value: 1021669017);

            migrationBuilder.InsertData(
                table: "Persona",
                columns: new[] { "PersonaDocumento", "PersonaApellido", "PersonaCiudad", "PersonaCorreo", "PersonaFechaNacimiento", "PersonaGenero", "PersonaNombre", "PersonaTelefono" },
                values: new object[,]
                {
                    { 58132098, "Martinez", "Bogotá", "jcmartinezd@uan.edu.co", new DateTime(1976, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "M", "Juan", 300900401 },
                    { 78234085, "Sarmiento", "Bogotá", "asarmiento@uan.edu.co", new DateTime(1976, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "F", "Andrea", 300900402 },
                    { 1921874154, "Rojas", "Bogotá", "srojas@uan.edu.co", new DateTime(2005, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "M", "Santiago", 300900400 }
                });

            migrationBuilder.UpdateData(
                table: "Profesor",
                keyColumn: "ProfesorId",
                keyValue: new Guid("920e874c-9eec-4c08-9507-485a9175b31c"),
                column: "ProfesorDocumento",
                value: 58132098);

            migrationBuilder.UpdateData(
                table: "Rector",
                keyColumn: "RectorId",
                keyValue: new Guid("531d2123-2836-4720-8d15-313c4aeda145"),
                column: "RectorDocumento",
                value: 78234085);

            migrationBuilder.CreateIndex(
                name: "IX_Rector_RectorDocumento",
                table: "Rector",
                column: "RectorDocumento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_ProfesorDocumento",
                table: "Profesor",
                column: "ProfesorDocumento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_AlumnoDocumento",
                table: "Alumno",
                column: "AlumnoDocumento",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Persona_AlumnoDocumento",
                table: "Alumno",
                column: "AlumnoDocumento",
                principalTable: "Persona",
                principalColumn: "PersonaDocumento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesor_Persona_ProfesorDocumento",
                table: "Profesor",
                column: "ProfesorDocumento",
                principalTable: "Persona",
                principalColumn: "PersonaDocumento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rector_Persona_RectorDocumento",
                table: "Rector",
                column: "RectorDocumento",
                principalTable: "Persona",
                principalColumn: "PersonaDocumento",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
