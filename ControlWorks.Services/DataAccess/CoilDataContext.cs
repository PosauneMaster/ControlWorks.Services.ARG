namespace ControlWorks.Services
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

        public virtual DbSet<CoilType> CoilTypes { get; set; }
        public virtual DbSet<CoilMeasurement> CoilMeasurements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoilType>()
                .Property(e => e.ToleranceMinus)
                .HasPrecision(9, 4);

            modelBuilder.Entity<CoilType>()
                .Property(e => e.TolerancePlus)
                .HasPrecision(9, 4);

            modelBuilder.Entity<CoilType>()
                .Property(e => e.ChangeNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CoilType>()
                .Property(e => e.Inspector)
                .IsUnicode(false);

            modelBuilder.Entity<CoilType>()
                .Property(e => e.BatchNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CoilType>()
                .Property(e => e.MaterialType)
                .IsUnicode(false);

            modelBuilder.Entity<CoilType>()
                .Property(e => e.MaterialThk)
                .HasPrecision(9, 4);

            modelBuilder.Entity<CoilType>()
                .Property(e => e.Length)
                .HasPrecision(9, 4);

            modelBuilder.Entity<CoilType>()
                .Property(e => e.Data)
                .IsUnicode(false);

            modelBuilder.Entity<CoilType>()
                .Property(e => e.Nom)
                .HasPrecision(9, 4);

            modelBuilder.Entity<CoilType>()
                .Property(e => e.Mean)
                .HasPrecision(9, 4);

            modelBuilder.Entity<CoilMeasurement>()
                .Property(e => e.Measurement)
                .HasPrecision(9, 4);
        }
    }
}
