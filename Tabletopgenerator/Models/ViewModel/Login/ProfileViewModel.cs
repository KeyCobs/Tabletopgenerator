namespace Tabletopgenerator.Models.ViewModel.Login
{
    public class ProfileViewModel
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

    }
}
