﻿// <auto-generated />
using System;
using CitasMedicas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CitasMedicas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CitasMedicas.Entidades.Citas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DocId")
                        .HasColumnType("int");

                    b.Property<int?>("DoctoresId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("hora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("pacientesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctoresId");

                    b.HasIndex("pacientesId");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("CitasMedicas.Entidades.Doctores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("consultorio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("especialidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("CitasMedicas.Entidades.Pacientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("telefono")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("CitasMedicas.Entidades.Citas", b =>
                {
                    b.HasOne("CitasMedicas.Entidades.Doctores", "Doctores")
                        .WithMany("CitasM")
                        .HasForeignKey("DoctoresId");

                    b.HasOne("CitasMedicas.Entidades.Pacientes", "pacientes")
                        .WithMany("CitasP")
                        .HasForeignKey("pacientesId");

                    b.Navigation("Doctores");

                    b.Navigation("pacientes");
                });

            modelBuilder.Entity("CitasMedicas.Entidades.Doctores", b =>
                {
                    b.Navigation("CitasM");
                });

            modelBuilder.Entity("CitasMedicas.Entidades.Pacientes", b =>
                {
                    b.Navigation("CitasP");
                });
#pragma warning restore 612, 618
        }
    }
}
