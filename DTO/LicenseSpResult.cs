namespace LabSoftwareLicense.DTO
{
    public class LicenseSpResult
    {
        public int LicenseId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CellNumber { get; set; }
        public bool isActive { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string SoftwareType { get; set; }
        public string ClientMessage { get; set; }
        public string ExpiryStatus { get; set; }
    }
}
