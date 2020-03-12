﻿// <auto-generated />
using System;
using DonorCentar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DonorCentar.Migrations
{
    [DbContext(typeof(BazaPodataka))]
    [Migration("20191225143914_ObavijestiFixed")]
    partial class ObavijestiFixed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DonorCentar.Models.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("DonorCentar.Models.Donacija", b =>
                {
                    b.Property<int>("DonacijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DonorId")
                        .HasColumnType("int");

                    b.Property<int?>("InformacijeId")
                        .HasColumnType("int");

                    b.Property<int>("JedinicaMjere")
                        .HasColumnType("int");

                    b.Property<decimal>("Kolicina")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrimalacId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("TipDonacijeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TransportId")
                        .HasColumnType("int");

                    b.Property<int>("VrstaDonacijeId")
                        .HasColumnType("int");

                    b.HasKey("DonacijaId");

                    b.HasIndex("DonorId");

                    b.HasIndex("InformacijeId");

                    b.HasIndex("PrimalacId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TipDonacijeId");

                    b.HasIndex("TransportId");

                    b.HasIndex("VrstaDonacijeId");

                    b.ToTable("Donacija");
                });

            modelBuilder.Entity("DonorCentar.Models.Donor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRegistracije")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Donor");
                });

            modelBuilder.Entity("DonorCentar.Models.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KantonId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KantonId");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("DonorCentar.Models.InformacijeTransporta", b =>
                {
                    b.Property<int>("InformacijeTransportaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InformacijeTransportaId");

                    b.ToTable("InformacijeTransporta");
                });

            modelBuilder.Entity("DonorCentar.Models.Kanton", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kanton");
                });

            modelBuilder.Entity("DonorCentar.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GradId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("LicniPodaciId")
                        .HasColumnType("int");

                    b.Property<int>("LoginPodaciId")
                        .HasColumnType("int");

                    b.Property<int?>("TipKorisnikaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.HasIndex("LicniPodaciId");

                    b.HasIndex("LoginPodaciId");

                    b.HasIndex("TipKorisnikaId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("DonorCentar.Models.LicniPodaci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("LicniPodaci");
                });

            modelBuilder.Entity("DonorCentar.Models.LoginPodaci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoginPodaci");
                });

            modelBuilder.Entity("DonorCentar.Models.Obavijest", b =>
                {
                    b.Property<int>("ObavijestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OdKorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("TipKorisnikaId")
                        .HasColumnType("int");

                    b.Property<int>("TipObavijestiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Vrijeme")
                        .HasColumnType("datetime2");

                    b.Property<int>("ZaKorisnikId")
                        .HasColumnType("int");

                    b.HasKey("ObavijestId");

                    b.HasIndex("OdKorisnikId");

                    b.HasIndex("TipObavijestiId");

                    b.HasIndex("ZaKorisnikId");

                    b.ToTable("Obavijest");
                });

            modelBuilder.Entity("DonorCentar.Models.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRegistracije")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Partner");
                });

            modelBuilder.Entity("DonorCentar.Models.Primalac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRegistracije")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<bool>("Verifikovan")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Primalac");
                });

            modelBuilder.Entity("DonorCentar.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("DonorCentar.Models.TipDonacije", b =>
                {
                    b.Property<int>("TipDonacijeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipDonacijeId");

                    b.ToTable("TipDonacije");
                });

            modelBuilder.Entity("DonorCentar.Models.TipKorisnika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipKorisnika");
                });

            modelBuilder.Entity("DonorCentar.Models.TipObavijesti", b =>
                {
                    b.Property<int>("TipObavijestiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Obavijest")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipObavijestiId");

                    b.ToTable("TipObavijesti");
                });

            modelBuilder.Entity("DonorCentar.Models.VrstaDonacije", b =>
                {
                    b.Property<int>("VrstaDonacijeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Vrsta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VrstaDonacijeId");

                    b.ToTable("VrstaDonacije");
                });

            modelBuilder.Entity("DonorCentar.Models.Administrator", b =>
                {
                    b.HasOne("DonorCentar.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DonorCentar.Models.Donacija", b =>
                {
                    b.HasOne("DonorCentar.Models.Korisnik", "Donor")
                        .WithMany()
                        .HasForeignKey("DonorId");

                    b.HasOne("DonorCentar.Models.InformacijeTransporta", "Informacije")
                        .WithMany()
                        .HasForeignKey("InformacijeId");

                    b.HasOne("DonorCentar.Models.Korisnik", "Primalac")
                        .WithMany()
                        .HasForeignKey("PrimalacId");

                    b.HasOne("DonorCentar.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DonorCentar.Models.TipDonacije", "TipDonacije")
                        .WithMany()
                        .HasForeignKey("TipDonacijeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DonorCentar.Models.Korisnik", "Transport")
                        .WithMany()
                        .HasForeignKey("TransportId");

                    b.HasOne("DonorCentar.Models.VrstaDonacije", "VrstaDonacije")
                        .WithMany()
                        .HasForeignKey("VrstaDonacijeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DonorCentar.Models.Donor", b =>
                {
                    b.HasOne("DonorCentar.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DonorCentar.Models.Grad", b =>
                {
                    b.HasOne("DonorCentar.Models.Kanton", "Kanton")
                        .WithMany()
                        .HasForeignKey("KantonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DonorCentar.Models.Korisnik", b =>
                {
                    b.HasOne("DonorCentar.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DonorCentar.Models.LicniPodaci", "LicniPodaci")
                        .WithMany()
                        .HasForeignKey("LicniPodaciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DonorCentar.Models.LoginPodaci", "LoginPodaci")
                        .WithMany()
                        .HasForeignKey("LoginPodaciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DonorCentar.Models.TipKorisnika", "TipKorisnika")
                        .WithMany()
                        .HasForeignKey("TipKorisnikaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DonorCentar.Models.Obavijest", b =>
                {
                    b.HasOne("DonorCentar.Models.Korisnik", "OdKorisnik")
                        .WithMany()
                        .HasForeignKey("OdKorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DonorCentar.Models.TipObavijesti", "TipObavijesti")
                        .WithMany()
                        .HasForeignKey("TipObavijestiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DonorCentar.Models.Korisnik", "ZaKorisnik")
                        .WithMany()
                        .HasForeignKey("ZaKorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DonorCentar.Models.Partner", b =>
                {
                    b.HasOne("DonorCentar.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DonorCentar.Models.Primalac", b =>
                {
                    b.HasOne("DonorCentar.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
