﻿// <auto-generated />
using System;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.Migrations
{
    [DbContext(typeof(FireContext))]
    partial class FireContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Backend.Entities.Classification", b =>
                {
                    b.Property<int>("ClassificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("classificationid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClassificationArt")
                        .IsRequired()
                        .HasColumnName("classificationart")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ClassificationType")
                        .IsRequired()
                        .HasColumnName("classificationtype")
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.HasKey("ClassificationId");

                    b.ToTable("classification");
                });

            modelBuilder.Entity("Backend.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("clientid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnName("clientname")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ClientPasswordHash")
                        .IsRequired()
                        .HasColumnName("clientpasswordhash")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ClientPasswordSalt")
                        .IsRequired()
                        .HasColumnName("clientpasswordsalt")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<int?>("ClientPosition")
                        .HasColumnName("clientposition")
                        .HasColumnType("integer");

                    b.Property<string>("ClientPrename")
                        .IsRequired()
                        .HasColumnName("clientprename")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("ClientRole")
                        .HasColumnName("clientrole")
                        .HasColumnType("integer");

                    b.Property<string>("ClientSurname")
                        .IsRequired()
                        .HasColumnName("clientsurname")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("ClientId");

                    b.ToTable("client");
                });

            modelBuilder.Entity("Backend.Entities.Crew", b =>
                {
                    b.Property<int>("CrewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("crewid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CrewValue")
                        .IsRequired()
                        .HasColumnName("crewvalue")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.HasKey("CrewId");

                    b.ToTable("crew");
                });

            modelBuilder.Entity("Backend.Entities.Engine", b =>
                {
                    b.Property<int>("EngineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("engineid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClassificationId")
                        .HasColumnName("ClassificationId")
                        .HasColumnType("integer");

                    b.Property<int>("CrewId")
                        .HasColumnName("crewid")
                        .HasColumnType("integer");

                    b.Property<string>("EngineBody")
                        .HasColumnName("enginebody")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("EngineCapacityCcm")
                        .HasColumnName("enginecapacityccm")
                        .HasColumnType("integer");

                    b.Property<string>("EngineChassis")
                        .HasColumnName("enginechassis")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("EngineConstructionYear")
                        .HasColumnName("engineconstructionyear")
                        .HasColumnType("integer");

                    b.Property<int?>("EngineCylinder")
                        .HasColumnName("enginecylinder")
                        .HasColumnType("integer");

                    b.Property<int>("EngineHight")
                        .HasColumnName("enginehight")
                        .HasColumnType("integer");

                    b.Property<bool>("EngineIsDeprecated")
                        .HasColumnName("engineisdeprecated")
                        .HasColumnType("boolean");

                    b.Property<int>("EngineLength")
                        .HasColumnName("enginelength")
                        .HasColumnType("integer");

                    b.Property<string>("EngineLicensePlate")
                        .IsRequired()
                        .HasColumnName("enginelicenseplate")
                        .HasColumnType("character varying(12)")
                        .HasMaxLength(12);

                    b.Property<string>("EngineNumber")
                        .HasColumnName("enginenumber")
                        .HasColumnType("character varying(7)")
                        .HasMaxLength(7);

                    b.Property<int?>("EnginePs")
                        .HasColumnName("engineps")
                        .HasColumnType("integer");

                    b.Property<string>("EngineRadioCall")
                        .HasColumnName("engineradiocall")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("EngineWidth")
                        .HasColumnName("enginewidth")
                        .HasColumnType("integer");

                    b.HasKey("EngineId");

                    b.HasIndex("ClassificationId");

                    b.HasIndex("CrewId");

                    b.ToTable("engine");
                });

            modelBuilder.Entity("Backend.Entities.Engine", b =>
                {
                    b.HasOne("Backend.Entities.Classification", "Classification")
                        .WithMany("Engines")
                        .HasForeignKey("ClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Entities.Crew", "Crew")
                        .WithMany("Engines")
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
