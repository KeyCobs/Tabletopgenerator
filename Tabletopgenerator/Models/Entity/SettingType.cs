using System.ComponentModel.DataAnnotations;

namespace Tabletopgenerator.Models.Entity
{
    public class SettingType : SettingTypeDetail
    {
        public IEnumerable<FirstName>? FirstNames { get; set; }
        public IEnumerable<LastName>? LastNames { get; set; }
    }

    public class SettingTypeDetail
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
