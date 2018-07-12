namespace AirportEf.DAL.Data
{
    using AirportEf.DAL.Entities;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Social Database context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class AirportDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirportDbContext" /> class.
        /// </summary>
        /// <param name="options">The db configuration options.</param>
        public AirportDbContext(DbContextOptions<AirportDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plane>().HasOne(p => p.PlaneType);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Member>()
            //    .HasOne(m => (Team)m.Team)
            //    .WithMany(t => (ICollection<Member>)t.Members)
            //    .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Plane> Planes { get; set; }
        public DbSet<PlaneType> PlaneTypes { get; set; }
    }
}
