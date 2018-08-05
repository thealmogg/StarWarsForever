using System.Threading.Tasks;
using StarWarsForever.Core;

namespace StarWarsForever.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public StarDbContext StarDbContext { get; }
        public UnitOfWork(StarDbContext StarDbContext)
        {
            this.StarDbContext = StarDbContext;

        }
        public async Task CompleteAsync()
        {
            await StarDbContext.SaveChangesAsync();
        }
    }
}