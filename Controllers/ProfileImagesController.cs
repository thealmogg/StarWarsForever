using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StarWarsForever.Controllers.Resources;
using StarWarsForever.Core;
using StarWarsForever.Core.Model;

namespace StarWarsForever.Controllers
{
    [Route("/api/contacts/{contactId}/image")]
    public class ProfileImagesController : Controller
    {
        public IHostingEnvironment host { get; }
        public IContactRepo ContactRepo { get; }
        public IImageRepo ImageRepo { get; }
        public IUnitOfWork unitOfWork { get; }
        public IMapper mapper { get; }
        private readonly ImageSettings imageSettings;
        public ProfileImagesController(IMapper mapper,
        IHostingEnvironment host,
        IContactRepo contactRepo,
        IImageRepo imageRepo,
        IUnitOfWork unitOfWork,
        IOptionsSnapshot<ImageSettings> options)
        {
            this.imageSettings = options.Value;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.ContactRepo = contactRepo;
            ImageRepo = imageRepo;
            this.host = host;

        }
        // for batch images IFormCollection
        [HttpPost]
        public async Task<IActionResult> Upload(int contactId, [FromForm] IFormFile file)
        {
            var contact = await ContactRepo.GetContact(contactId, includeRelated: false);
            if (contact == null)
            {
                return NotFound();
            }
            if(file == null) return BadRequest("Null file");
            if(file.Length == 0) return BadRequest("Empty file");
            if(file.Length > imageSettings.MaxBytes) return BadRequest("Maximum file size exceeded");
            if(!imageSettings.IsSupportedFile(file.FileName)) return BadRequest("Invalid file type");
            
            string uploadPath = Path.Combine(host.WebRootPath, "profile-images");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Generating different file name so user can't trick the frontend
            // with Request manipulations
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(uploadPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            // TODO : Create Thumbnail

            var image = ImageRepo.UploadImage(contact, fileName);

            await unitOfWork.CompleteAsync();
            return Ok(mapper.Map<Image, ImageResource>(image));
        }
        [HttpGet]
        public ImageResource GetImage(int contactId)
        {
            var image = ImageRepo.GetPhoto(contactId);
            return mapper.Map<Image, ImageResource>(image);
        }
    }
}