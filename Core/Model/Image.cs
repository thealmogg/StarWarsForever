using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsForever.Core.Model
{
    [Table("Images")]
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FileName { get; set; }
        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }
    }
}