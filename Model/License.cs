namespace LabSoftwareLicense.Model
{
    public class License
    {
        public int LicenseId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CellNumber { get; set; }
        public bool isActive { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public DateTime ExpiryDate { get; set; }

        public License()
        {
            CompanyName = string.Empty;
            Address = string.Empty;
            CellNumber = string.Empty;
            Created_By = string.Empty;
        }

    }
}
