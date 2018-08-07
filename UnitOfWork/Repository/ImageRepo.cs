using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StarWarsForever.Core;
using StarWarsForever.Core.Model;

namespace StarWarsForever.UnitOfWork.Repository
{
    public class ImageRepo : IImageRepo
    {
        protected StarDbContext StarDbContext { get; }

        public ImageRepo(StarDbContext starDbContext)
        {
            this.StarDbContext = starDbContext;

        }
        public Image GetPhoto(int contactId)
        {
            return StarDbContext.Contacts.SingleOrDefault(c => c.Id == contactId).ProfileImage;
        }

        public Image UploadImage(Contact contact, string fileName)
        {
            Image image = new Image() { FileName = fileName, Contact = contact };
            contact.ProfileImage = image;

            return contact.ProfileImage;      
        }
    }
}