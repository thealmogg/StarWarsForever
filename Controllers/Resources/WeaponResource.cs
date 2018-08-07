using System.ComponentModel.DataAnnotations;

namespace StarWarsForever.Controllers.Resources
{
    public class WeaponResource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int ContactId { get; set; }
    }
}