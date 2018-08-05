using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StarWarsForever.Controllers.Resources;
using StarWarsForever.Core;
using StarWarsForever.Core.Model;

namespace StarWarsForever.Controllers
{
    [Route("/api/weapons")]
    public class WeaponsController : Controller
    {
        public IUnitOfWork unitOfWork { get; }
        public IWeaponRepo weaponRepo { get; }
        public IMapper mapper { get; }
        public WeaponsController(IMapper mapper, IUnitOfWork unitOfWork, IWeaponRepo weaponRepo)
        {
            this.mapper = mapper;
            this.weaponRepo = weaponRepo;
            this.unitOfWork = unitOfWork;

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeapon(int id, [FromBody] WeaponResource weaponResource)
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var weapon = await weaponRepo.GetWeapon(id);
            if(weapon == null || weapon.Id != weaponResource.Id) {
                return NotFound();
            }
            mapper.Map<WeaponResource, Weapon>(weaponResource, weapon);

            await unitOfWork.CompleteAsync();

            weapon = await weaponRepo.GetWeapon(weapon.Id);
            return Ok(weapon);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeapon(int id)
        {
            var weapon =  await weaponRepo.GetWeapon(id, includeRelated: false);
            if(weapon == null) {
                return NotFound();
            }
            weaponRepo.Remove(weapon);

            await unitOfWork.CompleteAsync();
            return Ok(weapon);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeapon(int id)
        {
            var weapon = await weaponRepo.GetWeapon(id);
            if(weapon == null) {
                return NotFound();
            }

            return Ok(weapon);
        }

        [HttpGet]
        public async Task<IEnumerable<Weapon>> GetWeapons()
        {
            var weapons = await weaponRepo.GetWeapons();

            return weapons;
        }
    }
}