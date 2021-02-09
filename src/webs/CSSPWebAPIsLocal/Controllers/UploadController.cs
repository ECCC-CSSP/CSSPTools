using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CSSPWebAPIsLocal.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    public class UploadController : Controller
    {

        public UploadController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];

                string folderName = Path.Combine("Resources", "Images");
                string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim();
                    string fullPath = Path.Combine(pathToSave, fileName);

                    FileInfo fi = new FileInfo(fullPath);
                    DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
                    if (!di.Exists)
                    {
                        di.Create();
                    }
                    //string dbPath = Path.Combine(folderName, fileName);

                    using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    string allDone = "All done...";

                    return await Task.FromResult(Ok(new { allDone }));

                }
                else
                {
                    return await Task.FromResult(BadRequest("This is a bad request"));
                }


            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(500, $"Internal server error: {ex}"));
            }
        }
    }
}