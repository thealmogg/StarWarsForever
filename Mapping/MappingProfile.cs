using System.Linq;
using AutoMapper;
using StarWarsForever.Controllers.Resources;
using StarWarsForever.Core.Model;

namespace StarWarsForever.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactResource, Contact>()
            .ForMember(c => c.ProfileImage, opt => opt.Ignore())
            .ForMember(c => c.Weapons, opt => opt.Ignore());
            // .AfterMap((cr, c) => {
            //     var removedWeapons = c.Weapons.Where(weapon => cr.Weapons.FirstOrDefault(w => w.Id == weapon.Id) == null);
            //     foreach(var weapon in removedWeapons.ToList()) {
            //         c.Weapons.Remove(weapon);
            //     }

            //     var addedWeapons = cr.Weapons.Where(wr => c.Weapons.Any(w => w.Id == wr.Id)).Select(wr => new Weapon() {Name = wr.Name});
            //     foreach(var weapon in addedWeapons) {
            //         c.Weapons.Add(weapon);
            //     }
            // });
            CreateMap<WeaponResource, Weapon>();
            CreateMap<Image, ImageResource>();
        }
    }
}