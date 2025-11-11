using LabSoftwareLicense.DTO;
using LabSoftwareLicense.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LicenseController : ControllerBase
{
    private readonly LicenseRepository _repo;

    public LicenseController(LicenseRepository repo)
    {
        _repo = repo;
    }

    [HttpPost("GetCompanyLicense")]
    public async Task<IActionResult> GetCompanyLicense([FromBody] LicenseRequest request)
    {
        var licenses = await _repo.GetSpecificCompanyLicensesAsync(request.CompanyName, request.SoftwareType);
        return Ok(licenses);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var all = await _repo.GetAllLicensesAsync();
        return Ok(all);
    }
}
