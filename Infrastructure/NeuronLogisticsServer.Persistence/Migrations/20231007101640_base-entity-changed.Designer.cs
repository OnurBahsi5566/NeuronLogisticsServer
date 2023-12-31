﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NeuronLogisticsServer.Persistence.Contexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NeuronLogisticsServer.Persistence.Migrations
{
    [DbContext(typeof(NeuronLogisticsServerDbContext))]
    [Migration("20231007101640_base-entity-changed")]
    partial class baseentitychanged
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NeuronLogisticsServer.Domain.Entities.Definitions.CargoContainer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Teu")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("VesselId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VesselId");

                    b.ToTable("CargoContainers");
                });

            modelBuilder.Entity("NeuronLogisticsServer.Domain.Entities.Definitions.Vessel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FlagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Imo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("YearOfConstruction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Vessels");
                });

            modelBuilder.Entity("NeuronLogisticsServer.Domain.Entities.Definitions.Voyage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Voyages");
                });

            modelBuilder.Entity("VesselVoyage", b =>
                {
                    b.Property<Guid>("VesselsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VoyagesId")
                        .HasColumnType("uuid");

                    b.HasKey("VesselsId", "VoyagesId");

                    b.HasIndex("VoyagesId");

                    b.ToTable("VesselVoyage");
                });

            modelBuilder.Entity("NeuronLogisticsServer.Domain.Entities.Definitions.CargoContainer", b =>
                {
                    b.HasOne("NeuronLogisticsServer.Domain.Entities.Definitions.Vessel", "Vessel")
                        .WithMany("CargoContainers")
                        .HasForeignKey("VesselId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vessel");
                });

            modelBuilder.Entity("VesselVoyage", b =>
                {
                    b.HasOne("NeuronLogisticsServer.Domain.Entities.Definitions.Vessel", null)
                        .WithMany()
                        .HasForeignKey("VesselsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NeuronLogisticsServer.Domain.Entities.Definitions.Voyage", null)
                        .WithMany()
                        .HasForeignKey("VoyagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NeuronLogisticsServer.Domain.Entities.Definitions.Vessel", b =>
                {
                    b.Navigation("CargoContainers");
                });
#pragma warning restore 612, 618
        }
    }
}
