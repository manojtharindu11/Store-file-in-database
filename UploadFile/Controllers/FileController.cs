using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using UploadFile.Data;
using UploadFile.Models;

namespace UploadFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public FileController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] FileDTO fileDto)
        {
            if (fileDto.File == null || fileDto.File.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using var memoryStream = new MemoryStream();
            await fileDto.File.CopyToAsync(memoryStream);

            var userFile = new UserFile
            {
                FileName = fileDto.File.FileName,
                ContentType = fileDto.File.ContentType,
                FileData = memoryStream.ToArray()
            };

            _appDbContext.userFiles.Add(userFile);
            await _appDbContext.SaveChangesAsync();

            return Ok(new { Message = "File uploaded successfully", FileId = userFile.Id });
        }
    }
}
