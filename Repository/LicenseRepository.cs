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
                string query = "SELECT * FROM tbl_License Where isActive = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var license = new Model.License
                    {
                        LicenseId =  Convert.ToInt32(reader["Id"]),
                        CompanyName = reader["Company"] != DBNull.Value ? reader["Company"].ToString() : string.Empty,
                        Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : string.Empty,
                        CellNumber = reader["Mobile"] != DBNull.Value ? reader["Mobile"].ToString() : string.Empty,
                     };

                    licenses.Add(license);
                }
            }

            return licenses;
        }
    }
}
