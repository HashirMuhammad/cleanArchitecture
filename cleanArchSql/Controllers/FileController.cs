using cleanArchSql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cleanArchSql.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FileController : ControllerBase
    {
        private readonly string UploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("File not selected");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var uploadedFile = new UploadedFile
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                FilePath = filePath // Assuming you want to save the file path in the database
            };


            return Content("File uploaded successfully");
        }

        [HttpGet]
        [Route("list")]
        public IActionResult ListFiles()
        {
            var files = Directory.GetFiles(UploadsDirectory)
                                .Select(Path.GetFileName)
                                .ToList();
            return Ok(files);
        }

        [HttpGet]
        [Route("download/{fileName}")]
        public IActionResult Download(string fileName)
        {
            var filePath = Path.Combine(UploadsDirectory, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/octet-stream", fileName);
        }



    }
}
