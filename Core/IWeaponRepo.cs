using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsForever.Core.Model;

namespace StarWarsForever.Core
{
    public interface IWeaponRepo
    {
        Task<Weapon> GetWeapon(int id, bool includeRelated = true);
         Task<IEnumerable<Weapon>> GetWeapons();
         void Add(Weapon weapon);
         void Remove(Weapon weapon);
    }
}