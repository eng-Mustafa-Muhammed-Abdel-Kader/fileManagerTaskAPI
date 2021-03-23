using fileManagerTaskAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace fileManagerTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class checkAndUploadFilesController : ControllerBase
    {
        private readonly IWebHostEnvironment hosting;

        public checkAndUploadFilesController(IWebHostEnvironment _hosting)
        {
            hosting = _hosting;
        }

        [HttpPost, Route("checkFile")]
        public IActionResult ValidateofImage([FromBody] reseveString reseve)
        {

            var FolderName = Path.Combine(hosting.WebRootPath, "Resources");
            var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);
            var fullPath = Path.Combine(PathToSave, reseve.fileName);
            if (publicHelper.checkFile(fullPath))
            {
                return Ok(new
                {
                    status = 0,
                    message = "this File has be Uploaded as Same time please choose another file",
                    data = "empty"
                });
            }
            else
            {
                return Ok(new
                {
                    status = 1,
                    message = "you Can Uploaded File",
                    data = "empty"
                });
            }
        }

        [HttpPost("uploadFile"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            var File = Request.Form.Files[0];
            var FolderName = Path.Combine(hosting.WebRootPath, "Resources");
            var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);

            if (File.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(File.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(PathToSave, fileName);
                var dbPath = Path.Combine(FolderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    File.CopyTo(stream);
                }

                return Ok(new
                {
                    status = 1,
                    message = "upload Success",
                    data = dbPath
                });
            }
            else
            {
                return Ok(new
                {
                    status = 0,
                    message = "I don't have any file to Upload",
                    data = "empty"
                });
            }
        }
    }

    public class reseveString
    {
        public string fileName { get; set; }
    }
}
