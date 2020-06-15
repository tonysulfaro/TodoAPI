using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using TodoAPI.Models;

namespace TodoAPI.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class UploadController : ControllerBase {

        private readonly Models.TodoDBContext _context;

        public UploadController(TodoDBContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetTodoItems() {
            return await _context.Document.ToListAsync();
        }

        [HttpPost]
        public string Upload(IFormFile file) {
            // Extract file name from whatever was posted by browser
            var fileName = System.IO.Path.GetFileName(file.FileName);

            string folderPath = Directory.GetCurrentDirectory()+"\\Files";


            // If file with same name exists delete it
            if (System.IO.File.Exists(folderPath+"\\"+fileName)) {
                System.IO.File.Delete(folderPath+ "\\" + fileName);
            }

            // Create new local file and copy contents of uploaded file
            using (var localFile = System.IO.File.OpenWrite(folderPath + "\\" + fileName))
            using (var uploadedFile = file.OpenReadStream()) {
                uploadedFile.CopyTo(localFile);
            }

            var db_file = new Document() {RelativePath=fileName, OriginalName =fileName, MimeType="jpg"};
            _context.Document.Add(db_file);

            return "File successfully uploaded";
        }
    }
}
