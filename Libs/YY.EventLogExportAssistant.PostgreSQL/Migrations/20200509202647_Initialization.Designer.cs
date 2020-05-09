﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using YY.EventLogExportAssistant.PostgreSQL;

namespace YY.EventLogExportAssistant.PostgreSQL.Migrations
{
    [DbContext(typeof(EventLogContext))]
    [Migration("20200509202647_Initialization")]
    partial class Initialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.Applications", b =>
                {
                    b.Property<long>("InformationSystemId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("InformationSystemId", "Id");

                    b.HasIndex("InformationSystemId", "Id")
                        .IsUnique();

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.Computers", b =>
                {
                    b.Property<long>("InformationSystemId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("InformationSystemId", "Id");

                    b.HasIndex("InformationSystemId", "Id")
                        .IsUnique();

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.Events", b =>
                {
                    b.Property<long>("InformationSystemId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("InformationSystemId", "Id");

                    b.HasIndex("InformationSystemId", "Id")
                        .IsUnique();

                    b.ToTable("Events");
                });

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.InformationSystems", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("InformationSystems");
                });

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.LogFiles", b =>
                {
                    b.Property<long>("InformationSystemId")
                        .HasColumnType("bigint");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LastCurrentFileData")
                        .HasColumnType("text");

                    b.Property<string>("LastCurrentFileReferences")
                        .HasColumnType("text");

                    b.Property<long>("LastEventNumber")
                        .HasColumnType("bigint");

                    b.Property<long?>("LastStreamPosition")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("InformationSystemId", "FileName", "CreateDate", "Id");

                    b.HasIndex("InformationSystemId", "FileName", "CreateDate", "Id")
                        .IsUnique();

                    b.ToTable("LogFiles");
                });

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.Metadata", b =>
                {
                    b.Property<long>("InformationSystemId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid");

                    b.HasKey("InformationSystemId", "Id");

                    b.HasIndex("InformationSystemId", "Id")
                        .IsUnique();

                    b.ToTable("Metadata");
                });

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.PrimaryPorts", b =>
                {
                    b.Property<long>("InformationSystemId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("InformationSystemId", "Id");

                    b.HasIndex("InformationSystemId", "Id")
                        .IsUnique();

                    b.ToTable("PrimaryPorts");
                });

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.RowData", b =>
                {
                    b.Property<long>("InformationSystemId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("Period")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("ApplicationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<long?>("ComputerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ConnectId")
                        .HasColumnType("bigint");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<string>("DataPresentation")
                        .HasColumnType("text");

                    b.Property<string>("DataUUID")
                        .HasColumnType("text");

                    b.Property<long?>("EventId")
                        .HasColumnType("bigint");

                    b.Property<long?>("MetadataId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PrimaryPortId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SecondaryPortId")
                        .HasColumnType("bigint");

                    b.Property<long?>("Session")
                        .HasColumnType("bigint");

                    b.Property<long?>("SeverityId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("TransactionId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TransactionStatusId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("WorkServerId")
                        .HasColumnType("bigint");

                    b.HasKey("InformationSystemId", "Period", "Id");

                    b.HasIndex("InformationSystemId", "DataUUID");

                    b.HasIndex("InformationSystemId", "Period", "Id")
                        .IsUnique();

                    b.HasIndex("InformationSystemId", "UserId", "Period");

                    b.ToTable("RowsData");
                });

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.SecondaryPorts", b =>
                {
                    b.Property<long>("InformationSystemId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("InformationSystemId", "Id");

                    b.HasIndex("InformationSystemId", "Id")
                        .IsUnique();

                    b.ToTable("SecondaryPorts");
                });

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.Severities", b =>
                {
                    b.Property<long>("InformationSystemId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("InformationSystemId", "Id");

                    b.HasIndex("InformationSystemId", "Id")
                        .IsUnique();

                    b.ToTable("Severities");
                });

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.TransactionStatuses", b =>
                {
                    b.Property<long>("InformationSystemId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("InformationSystemId", "Id");

                    b.HasIndex("InformationSystemId", "Id")
                        .IsUnique();

                    b.ToTable("TransactionStatuses");
                });

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.Users", b =>
                {
                    b.Property<long>("InformationSystemId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid");

                    b.HasKey("InformationSystemId", "Id");

                    b.HasIndex("InformationSystemId", "Id")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("YY.EventLogExportAssistant.PostgreSQL.Models.WorkServers", b =>
                {
                    b.Property<long>("InformationSystemId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("InformationSystemId", "Id");

                    b.HasIndex("InformationSystemId", "Id")
                        .IsUnique();

                    b.ToTable("WorkServers");
                });
#pragma warning restore 612, 618
        }
    }
}