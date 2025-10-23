using LabSoftwareLicense.DTO;
using LabSoftwareLicense.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LabSoftwareLicense.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LicenseController : ControllerBase
    {
        private readonly LicenseRepository _licenseRepository;

        public LicenseController(LicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }

        [HttpGet]
        public ActionResult<List<Model.License>> GetAll()
        {
            var licenses = _licenseRepository.GetAllLicenses();
            return Ok(licenses);
        }

        [HttpPost("GetCompanyLicense")]
        public ActionResult<List<Model.License>> GetCompanyLicense([FromBody] LicenseRequest request)
        {
            var licenses = _licenseRepository.GetSpecificCompanyLicenses(request.CompanyName, request.SoftwareType);
            return Ok(licenses);
        }
    }
}   
