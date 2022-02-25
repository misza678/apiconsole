using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiconsole.Models.CollectionCentre;
using consolestoreapi.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImagesController(ConsoleStoreDbContext context,IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Images>>> GetImages()
        {
            return await _context.Images.ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Images>> GetImages(int id)
        {
            var images = await _context.Images.FindAsync(id);

            if (images == null)
            {
                return NotFound();
            }

            return images;
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImages(int id, Images images)
        {
            if (id != images.ImageID)
            {
                return BadRequest();
            }

            _context.Entry(images).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Images
        // To pro



        [HttpPost]
        public ActionResult<Images> PostImages([FromForm] CollectionImages Images)
        {
            try
            {


                foreach (IFormFile item in Images.Images)
                {
                    string stringFileName = UploadFile(item);
                    var productImage = new Images
                    {
                        ImageSrc = stringFileName,
                        CollectionItem = Images.CollectionItem
                    };
                    _context.Images.Add(productImage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            _context.SaveChanges();
            return NoContent();
        }

        private string UploadFile([FromForm]IFormFile file)
        {
            string fileName = null;
            if (file != null)
            {
                string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }
            }
            return fileName;
        }








        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImages(int id)
        {
            var images = await _context.Images.FindAsync(id);
            if (images == null)
            {
                return NotFound();
            }

            _context.Images.Remove(images);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImagesExists(int id)
        {
            return _context.Images.Any(e => e.ImageID == id);
        }
    }
}
