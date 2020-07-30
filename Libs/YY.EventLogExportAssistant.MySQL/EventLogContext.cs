﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YY.EventLogExportAssistant.MySQL.Models;

namespace YY.EventLogExportAssistant.MySQL
{
    public class EventLogContext : DbContext
    {
        #region Public Properties

        public DbSet<InformationSystems> InformationSystems { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<Computers> Computers { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Metadata> Metadata { get; set; }
        public DbSet<PrimaryPorts> PrimaryPorts { get; set; }
        public DbSet<RowData> RowsData { get; set; }
        public DbSet<SecondaryPorts> SecondaryPorts { get; set; }
        public DbSet<Severities> Severities { get; set; }
        public DbSet<TransactionStatuses> TransactionStatuses { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<WorkServers> WorkServers { get; set; }
        public DbSet<LogFiles> LogFiles { get; set; }

        #endregion

        #region Constructor

        public EventLogContext()
        {
            Database.EnsureCreated();
            AdditionalInitializationActions();
        }
        public EventLogContext(DbContextOptions<EventLogContext> options) : base(options)
        {
            Database.EnsureCreated();
            AdditionalInitializationActions();
        }

        #endregion

        #region Private Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                string connectinString = Configuration.GetConnectionString("EventLogDatabase");
                optionsBuilder.UseMySql(connectinString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InformationSystems>()
                .HasKey(b => new { b.Id });
            modelBuilder.Entity<InformationSystems>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Applications>()
                .HasKey(b => new { b.InformationSystemId, b.Id });
            modelBuilder.Entity<Applications>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Computers>()
                .HasKey(b => new { b.InformationSystemId, b.Id });
            modelBuilder.Entity<Computers>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Events>()
                .HasKey(b => new { b.InformationSystemId, b.Id });
            modelBuilder.Entity<Events>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Metadata>()
                .HasKey(b => new { b.InformationSystemId, b.Id });
            modelBuilder.Entity<Metadata>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PrimaryPorts>()
                .HasKey(b => new { b.InformationSystemId, b.Id });
            modelBuilder.Entity<PrimaryPorts>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SecondaryPorts>()
                .HasKey(b => new { b.InformationSystemId, b.Id });
            modelBuilder.Entity<SecondaryPorts>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Severities>()
                .HasKey(b => new { b.InformationSystemId, b.Id });
            modelBuilder.Entity<Severities>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TransactionStatuses>()
                .HasKey(b => new { b.InformationSystemId, b.Id });
            modelBuilder.Entity<TransactionStatuses>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Users>()
                .HasKey(b => new { b.InformationSystemId, b.Id });
            modelBuilder.Entity<Users>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<WorkServers>()
                .HasKey(b => new { b.InformationSystemId, b.Id });
            modelBuilder.Entity<WorkServers>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<LogFiles>()
                .HasKey(b => new { b.InformationSystemId, b.FileName, b.CreateDate, b.Id });
            modelBuilder.Entity<LogFiles>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RowData>()
                .HasKey(b => new { b.InformationSystemId, b.Period, b.Id });
            modelBuilder.Entity<RowData>()
                .HasIndex(i => new { i.InformationSystemId, i.UserId, i.Period });
            modelBuilder.Entity<RowData>()
                .HasIndex(i => new { i.InformationSystemId, i.DataUUID });
        }
        private void AdditionalInitializationActions()
        {
            Database.ExecuteSqlRaw(
                @"CREATE OR REPLACE VIEW vw_EventLog
                AS
                SELECT
                    RD.InformationSystemId AS InformationSystemId,
                    INFS.Name AS InformationSystemName,
                    RD.Period,
                    RD.Id AS RowId,
                    RD.SeverityId AS SeverityId,
                    SV.Name AS SeverityName,
                    RD.ConnectId AS Connection,
                    RD.Session,
                    RD.TransactionStatusId,
                    RD.TransactionDate,
                    RD.TransactionId,
                    RD.UserId AS UserId,
                    USR.Name AS UserName,
                    USR.Uuid AS UserUUID,
                    RD.ComputerId AS ComputerId,
                    CMP.Name ASComputerName,
                    RD.Data,
                    RD.DataUUID,
                    RD.DataPresentation,
                    RD.Comment,
                    RD.ApplicationId AS ApplicationId,
                    APPS.Name AS ApplicationName,
                    RD.EventId AS EventId,
                    EVNT.Name AS EventName,
                    RD.MetadataId AS MetadataId,
                    META.Name AS MetadataName,
                    META.Uuid AS MetadataUUID,
                    RD.WorkServerId AS WorkServerId,
                    WSRV.Name AS WorkServerName,
                    RD.PrimaryPortId AS PrimaryPortId,
                    PPRT.Name AS PrimaryPortName,
                    RD.SecondaryPortId AS SecondaryPortId,
                    SPRT.Name AS SecondaryPortName
                FROM RowsData AS RD
                    LEFT JOIN InformationSystems AS INFS
                        ON RD.InformationSystemId = INFS.Id
                    LEFT JOIN Severities AS SV
                        ON RD.InformationSystemId = SV.InformationSystemId
                            AND RD.SeverityId = SV.Id
                    LEFT JOIN Users AS USR
                        ON RD.InformationSystemId = USR.InformationSystemId
                            AND RD.UserId = USR.Id
                    LEFT JOIN Computers AS CMP
                        ON RD.InformationSystemId = CMP.InformationSystemId
                            AND RD.ComputerId = CMP.Id
                    LEFT JOIN Applications AS APPS
                        ON RD.InformationSystemId = APPS.InformationSystemId
                            AND RD.ApplicationId = APPS.Id
                    LEFT JOIN Events AS EVNT
                        ON RD.InformationSystemId = EVNT.InformationSystemId
                            AND RD.EventId = EVNT.Id
                    LEFT JOIN Metadata AS META
                        ON RD.InformationSystemId = META.InformationSystemId
                            AND RD.MetadataId = META.Id
                    LEFT JOIN WorkServers AS WSRV
                        ON RD.InformationSystemId = WSRV.InformationSystemId
                            AND RD.WorkServerId = WSRV.Id
                    LEFT JOIN PrimaryPorts AS PPRT
                        ON RD.InformationSystemId = PPRT.InformationSystemId
                            AND RD.PrimaryPortId = PPRT.Id
                    LEFT JOIN SecondaryPorts AS SPRT
                        ON RD.InformationSystemId = SPRT.InformationSystemId
                            AND RD.SecondaryPortId = SPRT.Id");
        }

        #endregion
    }
}