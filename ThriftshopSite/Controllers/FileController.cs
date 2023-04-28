using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ThriftshopSite.Data;
using ThriftshopSite.Models;

namespace ThriftshopSite.Controllers
{
    public class FileController : Controller
    {
        private IConfiguration Configuration;
        private readonly ApplicationDbContext _context;

        public FileController(IConfiguration _configuration, ApplicationDbContext context)
        {
            Configuration = _configuration;
            _context = context;
        }

        /// <summary>
        /// Uploads a file to the database with an empty pro
        /// </summary>
        /// <param name="postedFile"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UploadFile(IFormFile postedFile,Product product) 
        {
            string constr = this.Configuration.GetConnectionString("DefaultConnection");
            string fileName = Path.GetFileName(postedFile.FileName);
            string contentType = postedFile.ContentType;
            using (MemoryStream ms = new MemoryStream())
            {
                postedFile.CopyTo(ms);
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
            List<FileModel> files = new List<FileModel>();
            int newproductd = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandText = "SELECT Id FROM Files WHERE Name=@Name";
                    cmd.Parameters.AddWithValue("@Name", fileName);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();

                        newproductd = (int)sdr["Id"];
                    }
                    con.Close();
                }
            }
            List<int> list = new List<int>();
            List<FileModel> plist = new List<FileModel>();

            //list.Add(newproductd);

            //_context.Files.Where(f => f != null).ToList().ForEach(f => list.Add());

            //List<FileModel> plist1 = _context.Files.Where(f => f.Product.Name == product.Name).ToList();
            //foreach (FileModel file in product.Files)
            //{
            //   list.Add(file.Id);
            //..}
            //TempData["ProductsId"] = plist1;
            return RedirectToAction("Create", "Products");
                
        }

        /// <summary>
        /// Uploads a file to the database with an id based on the given product
        /// </summary>
        /// <param name="postedFile"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UploadFileWithId(IFormFile postedFile,Guid product)
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
                        cmd.Parameters.AddWithValue("@ProductId", product);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }

            return RedirectToAction("Add", "Products", new { id = product });
        }


        /// <summary>
        /// Shows a images based on the id of a file
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        //weg
        [HttpGet]
        public IActionResult ShowFileByProject(Guid id)
        {
            byte[] bytes;
            string fileName, contentType;
            string constr = this.Configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandText = "SELECT Name, Data, ContentType FROM Files WHERE ProductId=@ProductId";
                    cmd.Parameters.AddWithValue("@ProductId", id);
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


        /// <summary>
        /// shows a images from a file based on that files name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ShowFileByName(string Name)
        {
            byte[] bytes;
            string fileName, contentType;
            string constr = this.Configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandText = "SELECT Name, Data, ContentType FROM Files WHERE Name=@Name";
                    cmd.Parameters.AddWithValue("@Name", Name);
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


        /// <summary>
        /// shows a file based on data given
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="contentType"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public IActionResult ShowFileData(byte[] bytes,string contentType,string fileName)
        {
            return File(bytes, contentType, fileName);
        }


        /// <summary>
        /// gets all files with a connection to a spefic product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<FileModel> GetFiles(Guid id)
        {
            var countries = _context.Files.Where(a => a.Product.Id == id).ToList();
            return countries;
        }
    }
}
