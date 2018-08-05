using StarWarsForever.Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsForever.Core.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Last { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsDisplayed { get; set; }
        [ForeignKey("ProfileImageId")]
        public Image ProfileImage { get; set; }
        public ICollection<Weapon> Weapons { get; set; }

        public Contact()
        {
            this.Weapons = new Collection<Weapon>();          
        }
        
    }
}