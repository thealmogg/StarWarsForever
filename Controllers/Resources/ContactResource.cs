using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StarWarsForever.Core.Model;

namespace StarWarsForever.Controllers.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Last { get; set; }
        public DateTime? BirthDate { get; set; }
        public Image ProfileImage { get; set; }
        public bool IsDisplayed { get; set; }
        public ICollection<WeaponResource> Weapons { get; set; }
    }
}