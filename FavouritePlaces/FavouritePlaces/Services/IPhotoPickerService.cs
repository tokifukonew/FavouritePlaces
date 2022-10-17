using System.IO;
using System.Threading.Tasks;

namespace FavouritePlaces
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}