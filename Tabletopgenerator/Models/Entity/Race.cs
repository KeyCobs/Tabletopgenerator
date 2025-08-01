using System.ComponentModel.DataAnnotations;

namespace Tabletopgenerator.Models.Entity
{
    public class Race : RaceDetail
    {
        public IEnumerable<FirstName>? FirstNames { get; set; }
        public IEnumerable<LastName>? LastNames { get; set; }
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
