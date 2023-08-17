﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversidadEF.Context;

#nullable disable

namespace UniversidadEF.Migrations
{
    [DbContext(typeof(UniversidadContext))]
    [Migration("20230817221941_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UniversidadEf.Models.Alumno", b =>
                {
                    b.Property<int>("AlumnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlumnoId"));

                    b.Property<int>("AlumnoDocumento")
                        .HasColumnType("int");

                    b.HasKey("AlumnoId");

                    b.HasIndex("AlumnoDocumento")
                        .IsUnique();

                    b.ToTable("Alumno", (string)null);
                });

            modelBuilder.Entity("UniversidadEf.Models.AlumnoAsignatura", b =>
                {
                    b.Property<int>("AlumnoAsignaturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlumnoAsignaturaId"));

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<int>("AsignaturaId")
                        .HasColumnType("int");

                    b.Property<int>("Semestre")
                        .HasColumnType("int");

                    b.HasKey("AlumnoAsignaturaId");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("AsignaturaId");

                    b.ToTable("AlumnoAsignatura", (string)null);
                });

            modelBuilder.Entity("UniversidadEf.Models.Asignatura", b =>
                {
                    b.Property<int>("AsignaturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AsignaturaId"));

                    b.Property<int>("AsignaturaCreditos")
                        .HasColumnType("int");

                    b.Property<string>("AsignaturaNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarreraId")
                        .HasColumnType("int");

                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.HasKey("AsignaturaId");

                    b.HasIndex("CarreraId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("Asignatura", (string)null);
                });

            modelBuilder.Entity("UniversidadEf.Models.Carrera", b =>
                {
                    b.Property<int>("CarreraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarreraId"));

                    b.Property<string>("CarreraNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacultadId")
                        .HasColumnType("int");

                    b.HasKey("CarreraId");

                    b.HasIndex("FacultadId");

                    b.ToTable("Carrera", (string)null);
                });

            modelBuilder.Entity("UniversidadEf.Models.Facultad", b =>
                {
                    b.Property<int>("FacultadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacultadId"));

                    b.Property<string>("FacultadNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultadId");

                    b.ToTable("Facultad", (string)null);
                });

            modelBuilder.Entity("UniversidadEf.Models.Persona", b =>
                {
                    b.Property<int>("PersonaDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonaDocumento"));

                    b.Property<string>("PersonaApellido")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PersonaCiudad")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("PersonaCorreo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PersonaFechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("PersonaGenero")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("PersonaNombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PersonaTelefono")
                        .HasColumnType("int");

                    b.HasKey("PersonaDocumento");

                    b.ToTable("Persona", (string)null);
                });

            modelBuilder.Entity("UniversidadEf.Models.Profesor", b =>
                {
                    b.Property<int>("ProfesorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfesorId"));

                    b.Property<int>("ProfesorDocumento")
                        .HasColumnType("int");

                    b.HasKey("ProfesorId");

                    b.HasIndex("ProfesorDocumento")
                        .IsUnique();

                    b.ToTable("Profesor", (string)null);
                });

            modelBuilder.Entity("UniversidadEf.Models.Rector", b =>
                {
                    b.Property<int>("RectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RectorId"));

                    b.Property<int>("RectorDocumento")
                        .HasColumnType("int");

                    b.HasKey("RectorId");

                    b.HasIndex("RectorDocumento")
                        .IsUnique();

                    b.ToTable("Rector", (string)null);
                });

            modelBuilder.Entity("UniversidadEf.Models.Sede", b =>
                {
                    b.Property<int>("SedeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SedeId"));

                    b.Property<int>("RectorId")
                        .HasColumnType("int");

                    b.Property<string>("SedeDireccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SedeNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SedeId");

                    b.HasIndex("RectorId")
                        .IsUnique();

                    b.ToTable("Sede", (string)null);
                });

            modelBuilder.Entity("UniversidadEf.Models.Alumno", b =>
                {
                    b.HasOne("UniversidadEf.Models.Persona", "Persona")
                        .WithOne("Alumno")
                        .HasForeignKey("UniversidadEf.Models.Alumno", "AlumnoDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("UniversidadEf.Models.AlumnoAsignatura", b =>
                {
                    b.HasOne("UniversidadEf.Models.Alumno", "Alumno")
                        .WithMany("AlumnoAsignaturas")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("UniversidadEf.Models.Asignatura", "Asignatura")
                        .WithMany("AlumnoAsignaturas")
                        .HasForeignKey("AsignaturaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Asignatura");
                });

            modelBuilder.Entity("UniversidadEf.Models.Asignatura", b =>
                {
                    b.HasOne("UniversidadEf.Models.Carrera", "Carrera")
                        .WithMany("Asignaturas")
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversidadEf.Models.Profesor", "Profesor")
                        .WithMany("Asignaturas")
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("UniversidadEf.Models.Carrera", b =>
                {
                    b.HasOne("UniversidadEf.Models.Facultad", "Facultad")
                        .WithMany("Carreras")
                        .HasForeignKey("FacultadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facultad");
                });

            modelBuilder.Entity("UniversidadEf.Models.Profesor", b =>
                {
                    b.HasOne("UniversidadEf.Models.Persona", "Persona")
                        .WithOne("Profesor")
                        .HasForeignKey("UniversidadEf.Models.Profesor", "ProfesorDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("UniversidadEf.Models.Rector", b =>
                {
                    b.HasOne("UniversidadEf.Models.Persona", "Persona")
                        .WithOne("Rector")
                        .HasForeignKey("UniversidadEf.Models.Rector", "RectorDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("UniversidadEf.Models.Sede", b =>
                {
                    b.HasOne("UniversidadEf.Models.Rector", "Rector")
                        .WithOne("Sede")
                        .HasForeignKey("UniversidadEf.Models.Sede", "RectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rector");
                });

            modelBuilder.Entity("UniversidadEf.Models.Alumno", b =>
                {
                    b.Navigation("AlumnoAsignaturas");
                });

            modelBuilder.Entity("UniversidadEf.Models.Asignatura", b =>
                {
                    b.Navigation("AlumnoAsignaturas");
                });

            modelBuilder.Entity("UniversidadEf.Models.Carrera", b =>
                {
                    b.Navigation("Asignaturas");
                });

            modelBuilder.Entity("UniversidadEf.Models.Facultad", b =>
                {
                    b.Navigation("Carreras");
                });

            modelBuilder.Entity("UniversidadEf.Models.Persona", b =>
                {
                    b.Navigation("Alumno")
                        .IsRequired();

                    b.Navigation("Profesor")
                        .IsRequired();

                    b.Navigation("Rector")
                        .IsRequired();
                });

            modelBuilder.Entity("UniversidadEf.Models.Profesor", b =>
                {
                    b.Navigation("Asignaturas");
                });

            modelBuilder.Entity("UniversidadEf.Models.Rector", b =>
                {
                    b.Navigation("Sede")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
