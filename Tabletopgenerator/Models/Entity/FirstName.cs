using System.ComponentModel.DataAnnotations;

namespace Tabletopgenerator.Models.Entity
{
    public class FirstName : FirstNameDefault
    {
        //Keys etc,...
    }
    public class FirstNameDefault
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? TypeId { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public int? RaceId { get; set; }
    }
}
