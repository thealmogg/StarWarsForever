using System.IO;
using System.Linq;

namespace StarWarsForever.Core
{
    public class ImageSettings
    {
        public int MaxBytes { get; set; }
        public string[] AcceptedFileTypes { get; set; }

        public bool IsSupportedFile(string fileName)
        {
            return AcceptedFileTypes.Any(s => s.Equals(Path.GetExtension(fileName).ToLower()));

        }
    }
}