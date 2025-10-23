using Microsoft.EntityFrameworkCore;

namespace LabSoftwareLicense.Data
{
    public class LicenseDbContext : DbContext
    {
        public LicenseDbContext(DbContextOptions<LicenseDbContext> options) : base(options)
        {
        }
        public DbSet<Model.License> Licenses { get; set; }

    }
}
