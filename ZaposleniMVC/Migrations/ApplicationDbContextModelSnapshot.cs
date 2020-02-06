﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZaposleniMVC.Models;

namespace ZaposleniMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZaposleniMVC.Models.Administrator", b =>
                {
                    b.Property<int>("AdministratorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojTelefona");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.Property<int?>("KompanijaID");

                    b.Property<string>("Prezime")
                        .IsRequired();

                    b.Property<string>("Sifra")
                        .IsRequired();

                    b.HasKey("AdministratorID");

                    b.HasIndex("KompanijaID");

                    b.ToTable("Administratori");
                });

            modelBuilder.Entity("ZaposleniMVC.Models.Kompanija", b =>
                {
                    b.Property<int>("KompanijaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("Delatnost");

                    b.Property<string>("MaticniBroj");

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.HasKey("KompanijaID");

                    b.ToTable("Kompanija");
                });

            modelBuilder.Entity("ZaposleniMVC.Models.Obavestenja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<string>("Naslov");

                    b.Property<string>("Tekst");

                    b.HasKey("Id");

                    b.ToTable("Obavestenja");
                });

            modelBuilder.Entity("ZaposleniMVC.Models.Raspored", b =>
                {
                    b.Property<int>("RasporedID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdministratorID");

                    b.Property<DateTime>("Datum");

                    b.Property<bool>("Kasni");

                    b.Property<string>("Obavestenje");

                    b.Property<string>("Smena")
                        .IsRequired();

                    b.Property<DateTime>("VremePrijave");

                    b.Property<int?>("ZaposleniOsobaID");

                    b.HasKey("RasporedID");

                    b.HasIndex("AdministratorID");

                    b.HasIndex("ZaposleniOsobaID");

                    b.ToTable("Raspored");
                });

            modelBuilder.Entity("ZaposleniMVC.Models.Zaposleni", b =>
                {
                    b.Property<int>("OsobaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("BrojTelefona");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.Property<int?>("KompanijaID");

                    b.Property<string>("Pozicija");

                    b.Property<string>("Prezime")
                        .IsRequired();

                    b.Property<string>("Sifra")
                        .IsRequired();

                    b.HasKey("OsobaID");

                    b.HasIndex("KompanijaID");

                    b.ToTable("Zaposleni");
                });

            modelBuilder.Entity("ZaposleniMVC.Models.Administrator", b =>
                {
                    b.HasOne("ZaposleniMVC.Models.Kompanija", "Kompanija")
                        .WithMany()
                        .HasForeignKey("KompanijaID");
                });

            modelBuilder.Entity("ZaposleniMVC.Models.Raspored", b =>
                {
                    b.HasOne("ZaposleniMVC.Models.Administrator", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorID");

                    b.HasOne("ZaposleniMVC.Models.Zaposleni", "Zaposleni")
                        .WithMany()
                        .HasForeignKey("ZaposleniOsobaID");
                });

            modelBuilder.Entity("ZaposleniMVC.Models.Zaposleni", b =>
                {
                    b.HasOne("ZaposleniMVC.Models.Kompanija", "Kompanija")
                        .WithMany()
                        .HasForeignKey("KompanijaID");
                });
#pragma warning restore 612, 618
        }
    }
}
