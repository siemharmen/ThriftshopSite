using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ThriftshopSite.Controllers
{
    public class FileController : Controller
    {
        private IConfiguration Configuration;

        public FileController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile postedFile)
        {
            string fileName = Path.GetFileName(postedFile.FileName);
            string contentType = postedFile.ContentType;
            using (MemoryStream ms = new MemoryStream())
            {
                postedFile.CopyTo(ms);
                string constr = this.Configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "INSERT INTO Files VALUES (@Name, @ContentType, @Data,@ProductId)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Name", fileName);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        cmd.Parameters.AddWithValue("@Data", ms.ToArray());
                        cmd.Parameters.AddWithValue("@ProductId", DBNull.Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ShowFile(int id)
        {
            byte[] bytes;
            string fileName, contentType;
            string constr = this.Configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Name, Data, ContentType FROM Files WHERE Id=" + id;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["Name"].ToString();
                    }
                    con.Close();
                }
            }
            return File(bytes, contentType, fileName);
        }
    }
}
