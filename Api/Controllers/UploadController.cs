using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.Photos;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UploadController : BaseController
    {
        // [HttpPost]
        // public async Task<ActionResult<Unit>> Create (Create.Command command)
        // {
        //     // return await Mediator.Send(command);
        //     var activity = await Mediator.Send(command);
        //     return Ok(activity);
        // }
        [HttpPost]
        public async Task<ActionResult<Photo>> Add([FromForm]Add.Command command)
        {
            var photo = await Mediator.Send(command);
            return Ok(photo);
        }
        // [HttpPost, DisableRequestSizeLimit]
        // public IActionResult Upload()
        // {
        // try
        // {
        // var file = Request.Form.Files[0];
        // var folderName = Path.Combine("Resources", "Images");
        // var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        // if (file.Length > 0)
        // {
        //     var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //     var fullPath = Path.Combine(pathToSave, fileName);
        //     var dbPath = Path.Combine(folderName, fileName);
        //     using (var stream = new FileStream(fullPath, FileMode.Create))
        //     {
        //         file.CopyTo(stream);
        //     }
        //     return Ok(new { dbPath });
        //     }
        //     else
        //     {
        //     return BadRequest();
        //     }
        // }
        // catch (Exception ex)
        // {
        //     return StatusCode(500, $"Internal server error: {ex}");
        //     }
        // }
    }
}