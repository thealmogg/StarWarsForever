using System.Threading.Tasks;

namespace StarWarsForever.Core
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}