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
            modelBuilder.Entity<PlaneType>()
                .HasMany(pt => pt.Planes)
                .WithOne(p => p.PlaneType)
                .OnDelete(DeleteBehavior.ClientSetNull); // TODO: Set null to PlaneType on Plane when PlaneType Deleted

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

            modelBuilder.Entity<Crew>()
                .HasOne(pt => pt.Pilot)
                .WithMany(p => p.Crews)
                .OnDelete(DeleteBehavior.ClientSetNull); // TODO: Set null to PlaneType on Plane when PlaneType Deleted

            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Member>()
            //    .HasOne(m => (Team)m.Team)
            //    .WithMany(t => (ICollection<Member>)t.Members)
            //    .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Plane> Planes { get; set; }

        public DbSet<PlaneType> PlaneTypes { get; set; }

        public DbSet<Stewardess> Stewardesses { get; set; }

        public DbSet<Pilot> Pilots { get; set; }

        public DbSet<Crew> Crews { get; set; }

        public DbSet<Departure> Departures { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Flight> Flights { get; set; }
    }
}
