using LabSoftwareLicense.DTO;
using Microsoft.EntityFrameworkCore;

namespace LabSoftwareLicense.Data
{
    public class LicenseDbContext : DbContext
    {
        public LicenseDbContext(DbContextOptions<LicenseDbContext> options) : base(options)
        {
        }
        public DbSet<Model.License> Licenses { get; set; }


        // DTO 
        public DbSet<LicenseSpResult> LicenseSpResults { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.License>()
                .ToTable("License") // DB table name
                .HasKey(l => l.LicenseId);

            // telling its DTO
            modelBuilder.Entity<LicenseSpResult>().HasNoKey();
        }

    }
}
