using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tabletopgenerator.Models.Entity.Login
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public bool IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
