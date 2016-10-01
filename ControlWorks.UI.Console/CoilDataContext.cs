namespace ControlWorks.UI.Console
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CoilDataContext : DbContext
    {
        public CoilDataContext()
            : base("name=CoilDataContext")
        {
        }

        public virtual DbSet<CoilData> CoilDatas { get; set; }
        public virtual DbSet<LengthData> LengthDatas { get; set; }
        public virtual DbSet<RmrData> RmrDatas { get; set; }
        public virtual DbSet<SensorData> SensorDatas { get; set; }
        public virtual DbSet<SensorReport> SensorReports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoilData>()
                .Property(e => e.MaterialThickness)
                .HasPrecision(9, 5);

            modelBuilder.Entity<CoilData>()
                .Property(e => e.CoilWidth)
                .HasPrecision(9, 5);

            modelBuilder.Entity<CoilData>()
                .Property(e => e.TolerancePlus)
                .HasPrecision(9, 5);

            modelBuilder.Entity<CoilData>()
                .Property(e => e.ToleranceMinus)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.Good)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.ThicknessScrap)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.ThicknessReclass)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.Blisters)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.Contamination)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.Gas)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.Holes)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.Lumps)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.PaperBreaks)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.PaperSplice)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.Shiny)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.SlitterDefect)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.TapeInCoil)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.Wrinkles)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.Width)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.Other)
                .HasPrecision(9, 5);

            modelBuilder.Entity<LengthData>()
                .Property(e => e.Salvage)
                .HasPrecision(9, 5);

            modelBuilder.Entity<SensorData>()
                .Property(e => e.Position)
                .HasPrecision(9, 5);

            modelBuilder.Entity<SensorData>()
                .Property(e => e.SensorData0)
                .HasPrecision(9, 5);

            modelBuilder.Entity<SensorData>()
                .Property(e => e.SensorData1)
                .HasPrecision(9, 5);

            modelBuilder.Entity<SensorData>()
                .Property(e => e.SensorData2)
                .HasPrecision(9, 5);

            modelBuilder.Entity<SensorData>()
                .Property(e => e.SensorData3)
                .HasPrecision(9, 5);

            modelBuilder.Entity<SensorData>()
                .Property(e => e.SensorData4)
                .HasPrecision(9, 5);

            modelBuilder.Entity<SensorReport>()
                .Property(e => e.SensorMeasurement)
                .HasPrecision(9, 5);

            modelBuilder.Entity<SensorReport>()
                .Property(e => e.MeasurementCount)
                .HasPrecision(9, 5);
        }
    }
}
