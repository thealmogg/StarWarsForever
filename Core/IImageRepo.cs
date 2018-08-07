using System.Threading.Tasks;
using StarWarsForever.Core.Model;

namespace StarWarsForever.Core
{
    public interface IImageRepo
    {
         Image UploadImage(Contact contact, string fileName);
         Image GetPhoto(int contactId);
    }
}