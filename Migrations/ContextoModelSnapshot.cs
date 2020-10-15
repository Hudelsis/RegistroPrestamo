﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroPrestamos.DAL;

namespace RegistroPrestamos.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("RegistroPrestamos.Entidades.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Balance")
                        .HasColumnType("REAL");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RegistroPrestamos.Entidades.Moras", b =>
                {
                    b.Property<int>("MoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<float>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("MoraId");

                    b.ToTable("Moras");
                });

            modelBuilder.Entity("RegistroPrestamos.Entidades.MorasDetalle", b =>
                {
                    b.Property<int>("MoraDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoraId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("MoraDetalleId");

                    b.HasIndex("MoraId");

                    b.HasIndex("PrestamoId");

                    b.ToTable("MorasDetalle");
                });

            modelBuilder.Entity("RegistroPrestamos.Entidades.Prestamos", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Balance")
                        .HasColumnType("REAL");

                    b.Property<string>("Cliente")
                        .HasColumnType("TEXT");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<float>("Monto")
                        .HasColumnType("REAL");

                    b.Property<int>("PersonaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PrestamoId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("RegistroPrestamos.Entidades.MorasDetalle", b =>
                {
                    b.HasOne("RegistroPrestamos.Entidades.Moras", null)
                        .WithMany("Detalle")
                        .HasForeignKey("MoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroPrestamos.Entidades.Prestamos", null)
                        .WithMany("Detalle")
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
