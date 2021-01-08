﻿// <auto-generated />
using System;
using CasaBoxAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CasaBoxAPI.Migrations
{
    [DbContext(typeof(CasaBoxContext))]
    [Migration("20210107211049_Version2")]
    partial class Version2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CasaBoxAPI.Models.Booking", b =>
                {
                    b.Property<int>("BoxNummer")
                        .HasColumnType("int");

                    b.Property<DateTime>("Bestillingstidspunkt")
                        .HasColumnType("datetime2");

                    b.Property<string>("BookingId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mailadresse")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BoxNummer");

                    b.HasIndex("Mailadresse");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.CasaBox", b =>
                {
                    b.Property<int>("BoxNummer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Beskrivelse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Ledig")
                        .HasColumnType("bit");

                    b.Property<int>("M2")
                        .HasColumnType("int");

                    b.Property<int>("M3")
                        .HasColumnType("int");

                    b.Property<int>("Pris")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BoxNummer");

                    b.ToTable("CasaBoxes");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.Person", b =>
                {
                    b.Property<string>("Mailadresse")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuldeNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefonnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Mailadresse");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.Booking", b =>
                {
                    b.HasOne("CasaBoxAPI.Models.CasaBox", "CasaBox")
                        .WithMany("Bookinger")
                        .HasForeignKey("BoxNummer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CasaBoxAPI.Models.Person", "Person")
                        .WithMany("Bookinger")
                        .HasForeignKey("Mailadresse");

                    b.Navigation("CasaBox");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.CasaBox", b =>
                {
                    b.Navigation("Bookinger");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.Person", b =>
                {
                    b.Navigation("Bookinger");
                });
#pragma warning restore 612, 618
        }
    }
}
