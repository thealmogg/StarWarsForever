using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsForever.Core;
using StarWarsForever.Core.Model;

namespace StarWarsForever.UnitOfWork.Repository
{
    public class WeaponRepo : IWeaponRepo
    {
        protected StarDbContext StarDbContext { get; }

        public WeaponRepo(StarDbContext starDbContext)
        {
            this.StarDbContext = starDbContext;

        }


        public async Task<Weapon> GetWeapon(int id, bool includeRelated = true)
        {
            if(includeRelated) {
                return await StarDbContext.Weapons
                .Include(w => w.Contact)
                .SingleOrDefaultAsync(w => w.Id == id);
            }
            return await StarDbContext.Weapons.FindAsync(id);
        }

        public async Task<IEnumerable<Weapon>> GetWeapons()
        {
            return await StarDbContext.Weapons
            .Include(w => w.Contact)
            .ToListAsync();
        }

        public void Add(Weapon weapon)
        {
            StarDbContext.Weapons.Add(weapon);
        }

        public void Remove(Weapon weapon)
        {
            StarDbContext.Weapons.Remove(weapon);
        }
    }
}