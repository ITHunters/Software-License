using Microsoft.AspNetCore.Mvc;
using LabSoftwareLicense.Repository;

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
    }
}   
