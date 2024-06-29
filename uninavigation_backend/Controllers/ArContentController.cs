using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using uninavigation_backend.Data;
using uninavigation_backend.Logic.Classes;
using uninavigation_backend.Logic.Interfaces;
using uninavigation_backend.Models;
using uninavigation_backend.Models.DTOs;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace uninavigation_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArContentController : Controller
    {
        private readonly IArContentLogic _logic;
        private readonly ApplicationDbContext _context;

        public ArContentController(IArContentLogic logic, ApplicationDbContext context)
        {
            _logic = logic;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Ar_content>> GetAllContentsAsync()
        {
            return await _logic.GetAllContentsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ar_content>> GetContent(int id)
        {
            var item = await _logic.GetContentByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Ar_content>> CreateContent([FromBody] Ar_content content)
        {
            if (ModelState.IsValid)
            {
                await _logic.CreateContentAsync(content);
                return Ok(new { message = "Created" });
            }

            return BadRequest();
        }


        [HttpPut]
        public async Task<ActionResult<Ar_content>> PostContent([FromBody] Ar_content content)
        {
            if (ModelState.IsValid)
            {
                await _logic.UpdateContentAsync(content);
                return Ok(new { message = "Updated" });
            }

            return BadRequest();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContent(int id)
        {
            var item = await _logic.GetContentByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            await _logic.DeleteContentAsync(id);

            return NoContent();
        }

        [HttpGet("elevation/{elevation}")]
        public ContentResult GetArView(int elevation)
        {
            var arContents = _context.Ar_Contents.Select(ar => ar).Where(c => c.Elevation == elevation).ToList();

            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine("<!DOCTYPE html>");
            htmlBuilder.AppendLine("<html>");
            htmlBuilder.AppendLine("<head>");
            htmlBuilder.AppendLine("<script src=\"https://aframe.io/releases/1.3.0/aframe.min.js\"></script>");
            htmlBuilder.AppendLine("<script src=\"https://unpkg.com/aframe-look-at-component@0.8.0/dist/aframe-look-at-component.min.js\"></script>");
            htmlBuilder.AppendLine("<script type='text/javascript' src='https://raw.githack.com/AR-js-org/AR.js/master/three.js/build/ar-threex-location-only.js'></script>");
            htmlBuilder.AppendLine("<script type='text/javascript' src='https://raw.githack.com/AR-js-org/AR.js/master/aframe/build/aframe-ar.js'></script>");
            htmlBuilder.AppendLine("</head>");
            htmlBuilder.AppendLine("<body style='margin: 0px; overflow: hidden;'>");
            htmlBuilder.AppendLine(@"<a-scene vr-mode-ui=""enabled: false"" arjs=""sourceType: webcam; videoTexture: true; debugUIEnabled: false"" renderer=""antialias: true; alpha: true"">");
            htmlBuilder.AppendLine(@"<a-camera gps-new-camera rotation-reader></a-camera>");

            foreach (var content in arContents)
            {
                if (content.Content != "" && content.ContentName != "")
                {
                    htmlBuilder.AppendLine($@"<a-image src=""{content.Content}"" look-at=""[gps-new-camera]"" scale=""10 10 10"" " +
                $@"gps-new-entity-place=""latitude: {content.Latitude}; longitude: {content.Longitude}""></a-image></a-entity>");
                }
            }

            htmlBuilder.AppendLine("</a-scene>");
            htmlBuilder.AppendLine("</body>");
            htmlBuilder.AppendLine("</html>");

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 200,
                Content = htmlBuilder.ToString()
            };
        }

    }
}


