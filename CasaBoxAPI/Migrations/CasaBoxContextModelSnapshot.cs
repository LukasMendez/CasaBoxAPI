﻿// <auto-generated />
using System;
using CasaBoxAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CasaBoxAPI.Migrations
{
    [DbContext(typeof(CasaBoxContext))]
    partial class CasaBoxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BoxNummer");

                    b.HasIndex("Mailadresse");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.BookingHistorik", b =>
                {
                    b.Property<string>("BookingId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Bestillingstidspunkt")
                        .HasColumnType("datetime2");

                    b.Property<int>("BoxNummer")
                        .HasColumnType("int");

                    b.Property<string>("Mailadresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingId");

                    b.HasIndex("BoxNummer");

                    b.ToTable("BookingHistorik");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.CasaBox", b =>
                {
                    b.Property<int>("BoxNummer")
                        .HasColumnType("int");

                    b.Property<bool>("Ledig")
                        .HasColumnType("bit");

                    b.Property<double>("M2")
                        .HasColumnType("float");

                    b.Property<double>("M3")
                        .HasColumnType("float");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BoxNummer");

                    b.HasIndex("M2", "M3", "Type");

                    b.ToTable("CasaBoxes");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.CasaBoxType", b =>
                {
                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Type");

                    b.ToTable("CasaBoxType");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.CasaBoxVariant", b =>
                {
                    b.Property<double>("M2")
                        .HasColumnType("float");

                    b.Property<double>("M3")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Beskrivelse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pris")
                        .HasColumnType("int");

                    b.HasKey("M2", "M3", "Type");

                    b.HasIndex("Type");

                    b.ToTable("CasaBoxVariant");
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
                        .HasForeignKey("Mailadresse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CasaBox");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.BookingHistorik", b =>
                {
                    b.HasOne("CasaBoxAPI.Models.CasaBox", "CasaBox")
                        .WithMany("BookingHistorik")
                        .HasForeignKey("BoxNummer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CasaBox");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.CasaBox", b =>
                {
                    b.HasOne("CasaBoxAPI.Models.CasaBoxVariant", "CasaBoxVariant")
                        .WithMany("CasaBoxes")
                        .HasForeignKey("M2", "M3", "Type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CasaBoxVariant");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.CasaBoxVariant", b =>
                {
                    b.HasOne("CasaBoxAPI.Models.CasaBoxType", "CasaBoxType")
                        .WithMany("CasaBoxVarianter")
                        .HasForeignKey("Type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CasaBoxType");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.CasaBox", b =>
                {
                    b.Navigation("Bookinger");

                    b.Navigation("BookingHistorik");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.CasaBoxType", b =>
                {
                    b.Navigation("CasaBoxVarianter");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.CasaBoxVariant", b =>
                {
                    b.Navigation("CasaBoxes");
                });

            modelBuilder.Entity("CasaBoxAPI.Models.Person", b =>
                {
                    b.Navigation("Bookinger");
                });
#pragma warning restore 612, 618
        }
    }
}
