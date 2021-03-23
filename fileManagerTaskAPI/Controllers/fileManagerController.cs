using fileManagerTaskAPI.Models;
using fileManagerTaskAPI.Models.fileManagerRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace fileManagerTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class fileManagerController : ControllerBase
    {
        private readonly IfileManagerRepository repo;
        private readonly IWebHostEnvironment hosting;

        public fileManagerController(IfileManagerRepository rep, IWebHostEnvironment _hosting)
        {
            repo = rep;
            hosting = _hosting;
        }

        [HttpGet, Route("getAllFiles")]
        public async Task<ActionResult> GetFilesData() {
            IEnumerable<fileManager> files = await repo.GetFilesData();
            foreach (var item in files)
            {
                string[] arrString = item.DocumentURL.Split('/');
                var FolderName = Path.Combine(hosting.WebRootPath, "Resources");
                var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);
                var fullPath = Path.Combine(PathToSave, arrString[2]);
                //data:image/png;base64,

                byte[] bytes = System.IO.File.ReadAllBytes(fullPath);
                String fileConvert = Convert.ToBase64String(bytes);
                if (item.fileType.Contains("pdf"))
                {
                    item.DocumentURL = $"data:application/pdf;base64,{fileConvert}";
                }
            }
            return Ok(new
            {
                status = 1,
                message = "operation success",
                data = files
            });
        }

        [HttpPost, Route("addNewFiles")]
        public async Task<ActionResult> add([FromBody] fileManager _file)
        {
            fileManager file = await repo.add(_file);
            return Ok(new
            {
                status = 1,
                message = "operation success",
                data = file
            });
        }
    }
}
