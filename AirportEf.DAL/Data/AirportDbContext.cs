namespace AirportEf.DAL.Data
{
    using AirportEf.DAL.Entities;

    using Microsoft.EntityFrameworkCore;

    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class AirportDbContext : DbContext
    {
        public AirportDbContext(DbContextOptions<AirportDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plane>()
                .HasOne(pt => pt.PlaneType)
                .WithMany(p => p.Planes)
                .OnDelete(DeleteBehavior.SetNull); // TODO: Set null to PlaneTypeId on Plane when PlaneType Deleted

            // =======================================================================================

            modelBuilder.Entity<Crew>()
                .HasOne(pt => pt.Pilot)
                .WithMany(p => p.Crews)
                .OnDelete(DeleteBehavior.SetNull); // TODO: Set null to PilotId on Crew when Pilot Deleted

            // =======================================================================================

            modelBuilder.Entity<Departure>()
                .HasOne(pt => pt.Plane)
                .WithMany(p => p.Departures)
                .OnDelete(DeleteBehavior.SetNull); // TODO: Set null to PlaneId on Departure when Plane Deleted

            modelBuilder.Entity<Departure>()
                .HasOne(pt => pt.Crew)
                .WithMany(p => p.Departures)
                .OnDelete(DeleteBehavior.SetNull); // TODO: Set null to CrewId on Departure when Crew Deleted

            modelBuilder.Entity<Departure>()
                .HasOne(pt => pt.Flight)
                .WithMany(p => p.Departures)
                .OnDelete(DeleteBehavior.SetNull); // TODO: Set null to FlightNumber on Departure when Flight Deleted

            // =======================================================================================

            modelBuilder.Entity<Ticket>()
                .HasOne(pt => pt.Flight)
                .WithMany(p => p.Tickets)
                .OnDelete(DeleteBehavior.SetNull); // TODO: Set null to FlightNumber on Ticket when Flight Deleted

            // =======================================================================================

            modelBuilder.Entity<CrewStewardess>()
                .HasKey(bc => new { bc.CrewId, bc.StewardessId });

            modelBuilder.Entity<CrewStewardess>()
                .HasOne(bc => bc.Crew)
                .WithMany(b => b.CrewStewardess)
                .HasForeignKey(bc => bc.CrewId);

            modelBuilder.Entity<CrewStewardess>()
                .HasOne(bc => bc.Stewardess)
                .WithMany(c => c.CrewStewardess)
                .HasForeignKey(bc => bc.StewardessId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Plane> Planes { get; set; } // +

        public DbSet<PlaneType> PlaneTypes { get; set; } // +

        public DbSet<Stewardess> Stewardesses { get; set; } // +

        public DbSet<Pilot> Pilots { get; set; } // +

        public DbSet<Crew> Crews { get; set; } // +

        public DbSet<Departure> Departures { get; set; } // +

        public DbSet<Ticket> Tickets { get; set; } // +

        public DbSet<Flight> Flights { get; set; } // +
    }
}
