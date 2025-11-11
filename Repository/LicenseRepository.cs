using LabSoftwareLicense.Data;
using LabSoftwareLicense.DTO;
using LabSoftwareLicense.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSoftwareLicense.Repository
{
    public class LicenseRepository
    {
        private readonly LicenseDbContext _context;

        public LicenseRepository(LicenseDbContext context)
        {
            _context = context;
        }

        // ✅ Get all active licenses
        public async Task<List<License>> GetAllLicensesAsync()
        {
            return await _context.Licenses
                                 .Where(l => l.isActive)
                                 .ToListAsync();
        }

        // ✅ Get specific company licenses
        public async Task<List<LicenseSpResult>> GetSpecificCompanyLicensesAsync(string companyName, string softwareType)
        {
              return await _context.LicenseSpResults
                            .FromSqlRaw("EXEC sp_GetSpecficCompanyLicense @CompanyName={0}, @SoftwareType={1}", companyName, softwareType)
                            .ToListAsync();
        }

        // ✅ Optional: Add or Update License
        public async Task AddOrUpdateAsync(License license)
        {
            if (license.LicenseId == 0)
                _context.Licenses.Add(license);
            else
                _context.Licenses.Update(license);

            await _context.SaveChangesAsync();
        }
    }
}
