﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZaposleniMVC.Models;

namespace ZaposleniMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200127171343_Create")]
    partial class Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZaposleniMVC.Models.Osoba", b =>
                {
                    b.Property<int>("OsobaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("BrojTelefona");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.Property<string>("Prezime")
                        .IsRequired();

                    b.Property<string>("Sifra")
                        .IsRequired();

                    b.HasKey("OsobaID");

                    b.ToTable("Osobe");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Osoba");
                });

            modelBuilder.Entity("ZaposleniMVC.Models.Raspored", b =>
                {
                    b.Property<DateTime>("Datum");

                    b.Property<int?>("AdministratorOsobaID");

                    b.Property<bool>("Kasni");

                    b.Property<string>("Obavestenje");

                    b.Property<string>("Smena")
                        .IsRequired();

                    b.Property<DateTime>("VremePrijave");

                    b.Property<int?>("ZaposleniOsobaID");

                    b.HasKey("Datum");

                    b.HasIndex("AdministratorOsobaID");

                    b.HasIndex("ZaposleniOsobaID");

                    b.ToTable("Raspored");
                });

            modelBuilder.Entity("ZaposleniMVC.Models.Administrator", b =>
                {
                    b.HasBaseType("ZaposleniMVC.Models.Osoba");


                    b.ToTable("Administrator");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("ZaposleniMVC.Models.Zaposleni", b =>
                {
                    b.HasBaseType("ZaposleniMVC.Models.Osoba");

                    b.Property<string>("Pozicija");

                    b.ToTable("Zaposleni");

                    b.HasDiscriminator().HasValue("Zaposleni");
                });

            modelBuilder.Entity("ZaposleniMVC.Models.Raspored", b =>
                {
                    b.HasOne("ZaposleniMVC.Models.Administrator", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorOsobaID");

                    b.HasOne("ZaposleniMVC.Models.Zaposleni", "Zaposleni")
                        .WithMany()
                        .HasForeignKey("ZaposleniOsobaID");
                });
#pragma warning restore 612, 618
        }
    }
}
