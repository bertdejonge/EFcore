﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkDataLayer;

#nullable disable

namespace ParkDataLayer.Migrations
{
    [DbContext(typeof(ParkDbContext))]
    partial class ParkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkDataLayer.Model.HuurperiodeEF", b =>
                {
                    b.Property<int>("HuurperiodeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HuurperiodeID"));

                    b.Property<int>("Aantaldagen")
                        .HasColumnType("int");

                    b.Property<DateTime>("EindDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("HuurperiodeID");

                    b.ToTable("Huurdperiodes");
                });

            modelBuilder.Entity("ParkDataLayer.Models.HuisEF", b =>
                {
                    b.Property<int>("HuisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HuisID"));

                    b.Property<bool>("Actief")
                        .HasColumnType("bit");

                    b.Property<int>("Nummer")
                        .HasColumnType("int");

                    b.Property<string>("ParkID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Straat")
                        .HasColumnType("NVARCHAR(250)");

                    b.HasKey("HuisID");

                    b.HasIndex("ParkID");

                    b.ToTable("Huizen");
                });

            modelBuilder.Entity("ParkDataLayer.Models.HuurcontractEF", b =>
                {
                    b.Property<string>("HuurcontractId")
                        .HasColumnType("NVARCHAR(25)");

                    b.Property<int?>("HuisID")
                        .HasColumnType("int");

                    b.Property<int?>("HuurderID")
                        .HasColumnType("int");

                    b.Property<int>("HuurperiodeID")
                        .HasColumnType("int");

                    b.HasKey("HuurcontractId");

                    b.HasIndex("HuisID");

                    b.HasIndex("HuurderID");

                    b.HasIndex("HuurperiodeID");

                    b.ToTable("HuurContracten");
                });

            modelBuilder.Entity("ParkDataLayer.Models.HuurderEF", b =>
                {
                    b.Property<int>("HuurderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HuurderID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HuurderID");

                    b.ToTable("Huurders");
                });

            modelBuilder.Entity("ParkDataLayer.Models.ParkEF", b =>
                {
                    b.Property<string>("ParkID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Locatie")
                        .HasColumnType("NVARCHAR(500)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(250)");

                    b.HasKey("ParkID");

                    b.ToTable("Parken");
                });

            modelBuilder.Entity("ParkDataLayer.Models.HuisEF", b =>
                {
                    b.HasOne("ParkDataLayer.Models.ParkEF", "Park")
                        .WithMany("Huis")
                        .HasForeignKey("ParkID");

                    b.Navigation("Park");
                });

            modelBuilder.Entity("ParkDataLayer.Models.HuurcontractEF", b =>
                {
                    b.HasOne("ParkDataLayer.Models.HuisEF", "Huis")
                        .WithMany("HuurContracten")
                        .HasForeignKey("HuisID");

                    b.HasOne("ParkDataLayer.Models.HuurderEF", "Huurder")
                        .WithMany()
                        .HasForeignKey("HuurderID");

                    b.HasOne("ParkDataLayer.Model.HuurperiodeEF", "Huurperiode")
                        .WithMany()
                        .HasForeignKey("HuurperiodeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Huis");

                    b.Navigation("Huurder");

                    b.Navigation("Huurperiode");
                });

            modelBuilder.Entity("ParkDataLayer.Models.HuisEF", b =>
                {
                    b.Navigation("HuurContracten");
                });

            modelBuilder.Entity("ParkDataLayer.Models.ParkEF", b =>
                {
                    b.Navigation("Huis");
                });
#pragma warning restore 612, 618
        }
    }
}