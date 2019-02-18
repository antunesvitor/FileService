using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FileService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FileService.Controllers
{   
    [Route("file")]
    public class FileController: Controller
    {
        private  AppSettings  appSettings {get;set;}
        public FileController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }
        [HttpPost]
        public async Task<IActionResult> SaveFile(){
            var file = Request.Form.Files[0];

            var basePath = appSettings.DirectoryPath;

            if(file == null || file.Length == 0)
                return Content ("file not selected");
           
            var path = basePath + "\\" + file.FileName;
                       
            using (var stream = new FileStream(path, FileMode.Create)){
                    await file.CopyToAsync(stream);    
            }

            return Ok();
        }
    }
}