using System.ComponentModel.DataAnnotations;

namespace Tabletopgenerator.Models.Entity
{
    public class Race : RaceDetail
    {
    }

    public class RaceDetail
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
