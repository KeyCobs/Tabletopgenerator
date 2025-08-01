using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabletopgenerator.Models.Entity
{
    public class FirstName : FirstNameDefault
    {
        public SettingType? SettingType { get; set; }
        public Race? Race { get; set; }
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
