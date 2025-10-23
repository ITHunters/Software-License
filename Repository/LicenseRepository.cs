using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Data.SqlClient;

namespace LabSoftwareLicense.Repository
{
    public class LicenseRepository
    {
        private readonly string _connectionString;
        public LicenseRepository(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // ✅ Get all licenses
        [Obsolete]
        public List<Model.License> GetAllLicenses()
        {
            var licenses = new List<Model.License>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM [dbo].[License] Where isActive = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var license = new Model.License
                    {
                        LicenseId =  Convert.ToInt32(reader["LicenseId"]),
                        CompanyName = reader["CompanyName"] != DBNull.Value ? reader["CompanyName"].ToString() : string.Empty,
                        Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : string.Empty,
                        CellNumber = reader["CellNumber"] != DBNull.Value ? reader["CellNumber"].ToString() : string.Empty,
                     };

                    licenses.Add(license);
                }
            }

            return licenses;
        }

        // ✅ Get Specific Company licenses
        [Obsolete]
        public List<Model.License> GetSpecificCompanyLicenses(String CompanyName, String SoftwareType)
        {
            var licenses = new List<Model.License>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "sp_GetSpecficCompanyLicense'" + CompanyName +"', '"+ SoftwareType +"'";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var license = new Model.License
                    {
                        LicenseId = Convert.ToInt32(reader["LicenseId"]),

                        CompanyName = reader["CompanyName"] != DBNull.Value ? reader["CompanyName"].ToString() : string.Empty,

                        Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : string.Empty,

                        CellNumber = reader["CellNumber"] != DBNull.Value ? reader["CellNumber"].ToString() : string.Empty,

                        ClientMessage = reader["ClientMessage"] != ssDBNull.Value ? reader["ClientMessage"].ToString() : string.Empty,

                        SoftwareType = reader["SoftwareType"] != DBNull.Value ? reader["SoftwareType"].ToString() : string.Empty,

                        ExpiryStatus = reader["ExpiryStatus"] != DBNull.Value ? reader["ExpiryStatus"].ToString() : string.Empty,

                        isActive = Convert.ToBoolean(reader["isActive"].ToString())
                    };

                    licenses.Add(license);
                }
            }

            return licenses;
        }
    }
}
