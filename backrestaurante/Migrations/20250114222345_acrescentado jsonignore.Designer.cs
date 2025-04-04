﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backrestaurante.Context;

#nullable disable

namespace ProjetoRestaurante.Migrations
{
    [DbContext(typeof(RestauranteContext))]
    [Migration("20250114222345_acrescentado jsonignore")]
    partial class acrescentadojsonignore
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("backrestaurante.Entity.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("backrestaurante.Entity.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("NomeRua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroRua")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("backrestaurante.Entity.Marmita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Guarnicoes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Misturas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RetiradaEntrega")
                        .HasColumnType("int");

                    b.Property<int>("Tamanho")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Marmitas");
                });

            modelBuilder.Entity("backrestaurante.Entity.Endereco", b =>
                {
                    b.HasOne("backrestaurante.Entity.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("backrestaurante.Entity.Endereco", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("backrestaurante.Entity.Marmita", b =>
                {
                    b.HasOne("backrestaurante.Entity.Cliente", "Cliente")
                        .WithMany("Marmitas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("backrestaurante.Entity.Cliente", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Marmitas");
                });
#pragma warning restore 612, 618
        }
    }
}
