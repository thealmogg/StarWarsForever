using System.ComponentModel.DataAnnotations;

namespace StarWarsForever.Core.Model
{
    public class Weapon
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}